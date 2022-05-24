using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public  class SendAdaRequest
    {
        [JsonProperty("wallet")]
        public string Wallet { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
