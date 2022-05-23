using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public  class CornucopiasLoginRequest
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("RecaptchaResponse")]
        public string RecaptchaResponse { get; set; }
    }
}
