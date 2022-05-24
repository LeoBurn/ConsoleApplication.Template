using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public class OrderInfo
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("SalesItemGroupId")]
        public string SalesItemGroupId { get; set; }

        [JsonProperty("ReservationQuantity")]
        public int ReservationQuantity { get; set; }
    }
}
