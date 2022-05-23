using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public  class CornucopiasLoginResponse
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("Response")]
        public Response Response { get; set; }

        [JsonProperty("HttpStatusCode")]
        public int HttpStatusCode { get; set; }
    }

    public class DiscordStatus
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("DiscordUsername")]
        public string DiscordUsername { get; set; }

        [JsonProperty("IsDiscordUsernameVerified")]
        public bool IsDiscordUsernameVerified { get; set; }

        [JsonProperty("VerificationCode")]
        public string VerificationCode { get; set; }
    }

    public class RefreshToken
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("RowVersion")]
        public RowVersion RowVersion { get; set; }
    }

    public class Response
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("RefreshToken")]
        public RefreshToken RefreshToken { get; set; }

        [JsonProperty("AccessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("DiscordStatus")]
        public DiscordStatus DiscordStatus { get; set; }
    }

    public class RowVersion
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("$value")]
        public string Value { get; set; }
    }


}
