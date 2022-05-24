using Cornucopias.Mint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Contracts
{
    public interface ICornucopiasService
    {
        public Task<CornucopiasLoginResponse> Login(string email, string password, string recaptchaCode);

        public Task<NftSaleResponse> GetNftSale(string authToken);

        public Task<CheckCanPlaceOrderResponse> CheckIfCanBuy(CheckCanPlaceOrderRequest request, string authToken);

        public Task EnterOrderQueue(EnterOrderQueueRequest request, string authToken);
    }
}
