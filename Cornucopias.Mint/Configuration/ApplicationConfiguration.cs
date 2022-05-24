using Cornucopias.Mint.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Configuration
{
    public class ApplicationConfiguration
    {
        public TwoCaptchaConfiguration TwoCaptcha { get; set; }
        public CaptchaConfiguration ReCaptcha { get; set; }

        public CornucopiasConfiguration Cornucopias { get; set; }
        public SendAdaConfiguration SendAda { get; set; }
    }
}
