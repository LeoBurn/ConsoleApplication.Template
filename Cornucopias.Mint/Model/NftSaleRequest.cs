using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public class NftSaleRequest
    {
        [JsonProperty("$type")]
        public string Type { get; set; }
    }
}
