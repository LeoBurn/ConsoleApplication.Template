using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public class SendAdaResponse
    {
        [JsonProperty("tx")]
        public Tx Tx { get; set; }
    }

    public class Tx
    {
        [JsonProperty("txHash")]
        public string TxHash { get; set; }
        [JsonProperty("signedTx")]
        public string SignedTx { get; set; }
    }
}
