using Cornucopias.Mint.Contracts;
using Cornucopias.Mint.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Services
{
    public class CornucopiasService : ICornucopiasService
    {
        private HttpClient _httpClient;
        private ICaptchaService _captchaService;
        private JsonSerializerSettings _jsonSerializerSettings;
        private ILogger<CornucopiasService> _logger;
        private const int  MintingDeposit = 3;

        public CornucopiasService(HttpClient httpClient, ILogger<CornucopiasService> logger)
        {
            _httpClient = httpClient;
            //Setting of json serializer
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
            _logger = logger;
        }
        public async Task<CornucopiasLoginResponse> Login(string email, string password, string recaptchaCode)
        {
            var request = new CornucopiasLoginRequest()
            {
                Type = Types.LOGIN_COMMAND_TYPE,
                Email = email,
                Password = password,
                RecaptchaResponse = recaptchaCode
            };

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri("https://mapapi.cornucopias.io/api/SendMessage/LoginUserCommand")))
            {
                requestMessage.Headers.TryAddWithoutValidation("authority", "mapapi.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("scheme", "https");
                requestMessage.Headers.TryAddWithoutValidation("clientversion", "1.0.1.0");
                requestMessage.Headers.TryAddWithoutValidation("origin", "https://nft.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("request-context", "appId=cid-v1:b946ce22-9693-4cc3-aa4b-2526922923f9");
                requestMessage.Headers.TryAddWithoutValidation("request-id", "|d30f4304c97e431fab8747fad5f12988.c1d0393861b34c5b");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"101\", \"Google Chrome\";v=\"101\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-site", "same-site");
                requestMessage.Headers.TryAddWithoutValidation("traceparent", "00-d30f4304c97e431fab8747fad5f12988-c1d0393861b34c5b-01");

                requestMessage.Content = GetStringContent(request);

                //Make HttpRequest
                using (var response = await _httpClient.SendAsync(requestMessage))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var cornucopiasLoginResponse = JsonConvert.DeserializeObject<CornucopiasLoginResponse>(responseBody, _jsonSerializerSettings);
                    return cornucopiasLoginResponse;

                }
            }
    
        }

        public async Task<NftSaleResponse> GetNftSale(string authToken)
        {
            //var url = "https://mapapi.cornucopias.io/api/SendMessage/GetStandaloneNftSaleDataRequest";
            var url = "https://f2ae7d35-eda6-4f17-bbb4-3f6a224a7558.mock.pstmn.io/GetStandaloneNftSaleDataRequest";
            var request = new NftSaleRequest()
            {
                Type = Types.NFT_SALE_DATA_TYPE
            };

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(url)))
            {
                requestMessage.Headers.TryAddWithoutValidation("authorization", $"Bearer {authToken}");
                requestMessage.Headers.TryAddWithoutValidation("authority", "mapapi.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("scheme", "https");
                requestMessage.Headers.TryAddWithoutValidation("clientversion", "1.0.1.0");
                requestMessage.Headers.TryAddWithoutValidation("origin", "https://nft.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("request-context", "appId=cid-v1:b946ce22-9693-4cc3-aa4b-2526922923f9");
                requestMessage.Headers.TryAddWithoutValidation("request-id", "|d30f4304c97e431fab8747fad5f12988.c1d0393861b34c5b");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"101\", \"Google Chrome\";v=\"101\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-site", "same-site");
                requestMessage.Headers.TryAddWithoutValidation("traceparent", "00-d30f4304c97e431fab8747fad5f12988-c1d0393861b34c5b-01");

                requestMessage.Content = GetStringContent(request);

                //Make HttpRequest
                using (var response = await _httpClient.SendAsync(requestMessage))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var cornucopiasLoginResponse = (JObject)JsonConvert.DeserializeObject(responseBody);
                    return new NftSaleResponse()
                    {
                        SalesGroupId = cornucopiasLoginResponse.SelectToken("Response.SalesItemGroups.$values[0].Id").Value<string>(),
                        Price = (cornucopiasLoginResponse.SelectToken("Response.SalesItemGroups.$values[0].Price").Value<int>())+3,
                    };
                }
            }
        }

        public async Task<CheckCanPlaceOrderResponse> CheckIfCanBuy(CheckCanPlaceOrderRequest request, string authToken)
        {
            //var url = "https://mapapi.cornucopias.io/api/SendMessage/CheckCanPlaceInstantOrderRequest";
            var url = "https://f2ae7d35-eda6-4f17-bbb4-3f6a224a7558.mock.pstmn.io/CheckCanPlaceInstantOrderRequest";

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(url)))
            {
                requestMessage.Headers.TryAddWithoutValidation("authorization", $"Bearer {authToken}");
                requestMessage.Headers.TryAddWithoutValidation("authority", "mapapi.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("scheme", "https");
                requestMessage.Headers.TryAddWithoutValidation("clientversion", "1.0.1.0");
                requestMessage.Headers.TryAddWithoutValidation("origin", "https://nft.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("request-context", "appId=cid-v1:b946ce22-9693-4cc3-aa4b-2526922923f9");
                requestMessage.Headers.TryAddWithoutValidation("request-id", "|d30f4304c97e431fab8747fad5f12988.c1d0393861b34c5b");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"101\", \"Google Chrome\";v=\"101\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-site", "same-site");
                requestMessage.Headers.TryAddWithoutValidation("traceparent", "00-d30f4304c97e431fab8747fad5f12988-c1d0393861b34c5b-01");

                requestMessage.Content = GetStringContent(request);

                //Make HttpRequest
                using (var response = await _httpClient.SendAsync(requestMessage))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var cornucopiasLoginResponse = (JObject)JsonConvert.DeserializeObject(responseBody);
                    return new CheckCanPlaceOrderResponse()
                    {
                        PaymentAddressId = cornucopiasLoginResponse.SelectToken("Response.PaymentAddressId").Value<string>(),
                        AdaPaymentAddress = (cornucopiasLoginResponse.SelectToken("Response.AdaPaymentAddress").Value<string>()),
                    };
                }
            }
        }

        public async Task EnterOrderQueue(EnterOrderQueueRequest request, string authToken)
        {
            //var url = "https://mapapi.cornucopias.io/api/SendMessage/EnterOrderQueueCommand";
            var url = "https://f2ae7d35-eda6-4f17-bbb4-3f6a224a7558.mock.pstmn.io/CheckCanPlaceInstantOrderRequest";

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(url)))
            {
                requestMessage.Headers.TryAddWithoutValidation("authorization", $"Bearer {authToken}");
                requestMessage.Headers.TryAddWithoutValidation("authority", "mapapi.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("scheme", "https");
                requestMessage.Headers.TryAddWithoutValidation("clientversion", "1.0.1.0");
                requestMessage.Headers.TryAddWithoutValidation("origin", "https://nft.cornucopias.io");
                requestMessage.Headers.TryAddWithoutValidation("request-context", "appId=cid-v1:b946ce22-9693-4cc3-aa4b-2526922923f9");
                requestMessage.Headers.TryAddWithoutValidation("request-id", "|d30f4304c97e431fab8747fad5f12988.c1d0393861b34c5b");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"101\", \"Google Chrome\";v=\"101\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                requestMessage.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                requestMessage.Headers.TryAddWithoutValidation("sec-fetch-site", "same-site");
                requestMessage.Headers.TryAddWithoutValidation("traceparent", "00-d30f4304c97e431fab8747fad5f12988-c1d0393861b34c5b-01");

                requestMessage.Content = GetStringContent(request);

                //Make HttpRequest
                using (var response = await _httpClient.SendAsync(requestMessage))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var cornucopiasLoginResponse = (JObject)JsonConvert.DeserializeObject(responseBody);
                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Erro Submit Entrer Queue");
                }
            }
        }

        public StringContent GetStringContent(object request)
        {
            string contentString = JsonConvert.SerializeObject(request);
            return new StringContent(contentString, Encoding.UTF8, "application/json");
        }
    }
}
