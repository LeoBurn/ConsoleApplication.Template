using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public  class CheckCanPlaceOrderRequest
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("OrderInfo")]
        public OrderInfo OrderInfo { get; set; }
    }
}
