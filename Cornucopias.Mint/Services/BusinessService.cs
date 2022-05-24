using Cornucopias.Mint.Configuration;
using Cornucopias.Mint.Contracts;
using Cornucopias.Mint.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Services
{
    public class BusinessService : IBusinessService
    {
        private ICornucopiasService _cornucopiasService;
        private ICaptchaService _captchaService;
        private ApplicationConfiguration _applicationConfiguration;
        private ILogger<BusinessService> _logger;

        public BusinessService(ICornucopiasService cornucopiasService, ICaptchaService captchaService, ApplicationConfiguration applicationConfiguration, ILogger<BusinessService> logger)
        {
            _cornucopiasService = cornucopiasService;
            _captchaService = captchaService;
            _applicationConfiguration = applicationConfiguration;
            _logger = logger;
        }

        public async Task MintAsync()
        {
            _logger.LogInformation("MintAsync");
            //If we don't have the token on configuration we need to login
            CornucopiasLoginResponse cornucopiasLoginResponse = new CornucopiasLoginResponse();
            string authToken = string.Empty;
            string userId = string.Empty;
            if (string.IsNullOrEmpty(_applicationConfiguration.Cornucopias.Token))
            {
                var token = await _captchaService.GetReCaptchaAsync();
                cornucopiasLoginResponse = await _cornucopiasService.Login(_applicationConfiguration.Cornucopias.Email, _applicationConfiguration.Cornucopias.Password, token);
                authToken = cornucopiasLoginResponse.Response.AccessToken;
                userId = cornucopiasLoginResponse.Response.DiscordStatus.UserId;
            }
            else if(!string.IsNullOrEmpty(_applicationConfiguration.Cornucopias.Token) && !string.IsNullOrEmpty(_applicationConfiguration.Cornucopias.UserId))
            {
                authToken = _applicationConfiguration.Cornucopias.Token;
                userId = _applicationConfiguration.Cornucopias.UserId;
            }

            var sales = await _cornucopiasService.GetNftSale(authToken);

            CheckCanPlaceOrderRequest checkCanPlaceOrderRequest = new CheckCanPlaceOrderRequest()
            {
                Type = Types.CHECK_CAN_PLACE_ORDER_TYPE,
                UserId = userId,
                OrderInfo = new OrderInfo()
                {
                    ReservationQuantity = 1, // HARDCODED for 1.
                    SalesItemGroupId = sales.SalesGroupId,
                    Type = Types.ORDER_TYPE,
                }
            };

            var checkCanPlaceOrder = await _cornucopiasService.CheckIfCanBuy(checkCanPlaceOrderRequest, authToken);

            //##################################### MISSING PART PPILOTO  #########################################
            //TODO: @ppiloto method to send tx
            SendAdaRequest sendAdaRequest = new SendAdaRequest()
            {
                Amount = sales.Price,
                Destination = checkCanPlaceOrder.AdaPaymentAddress,
                Wallet = _applicationConfiguration.SendAda.Wallet
            };

            //MakeRequest and Received The Response
            var sendAdaResponse = new SendAdaResponse()
            {
                Tx = new Tx()
                {
                    TxHash = "asdasdasda",
                    SignedTx = "asdasdasdasdasd"
                }
            };

            //##################################### MISSING PART PPILOTO  #########################################


            //Confirm order with cornucopias
            EnterOrderQueueRequest enterOrderQueueRequest = new EnterOrderQueueRequest()
            {
                OrderInfo = new OrderInfo()
                {
                    ReservationQuantity = 1, // HARDCODED,
                    SalesItemGroupId = sales.SalesGroupId,
                    Type = Types.PLACE_ORDER_TYPE
                },
                PaymentAddressId = checkCanPlaceOrder.PaymentAddressId,
                UserId = userId,
                Type = Types.ENTER_QUEUE_TYPE,
                SignedTransactionCborHex = sendAdaResponse.Tx.SignedTx,
                TransactionId = sendAdaResponse.Tx.TxHash
            };

            await _cornucopiasService.EnterOrderQueue(enterOrderQueueRequest, authToken);
        }
    }
}
