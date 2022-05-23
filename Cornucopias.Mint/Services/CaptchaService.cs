using Cornucopias.Mint.Configuration;
using Cornucopias.Mint.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoCaptcha.Captcha;

namespace Cornucopias.Mint.Services
{
    public  class CaptchaService : ICaptchaService
    {
        private ILogger<CaptchaService> _logger;
        private ApplicationConfiguration _configuration;
        private TwoCaptcha.TwoCaptcha _solver;

        public CaptchaService(ApplicationConfiguration configuration, ILogger<CaptchaService> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _solver = new TwoCaptcha.TwoCaptcha(_configuration.TwoCaptcha.Key);
        }

        public async Task<string> GetReCaptchaAsync()
        {
            ReCaptcha captcha = new ReCaptcha();
            captcha.SetSiteKey(_configuration.ReCaptcha.Key);
            captcha.SetUrl("https://mapapi.cornucopias.io");

            _logger.LogInformation("Solving Recaptcha");
            await _solver.Solve(captcha);
            return captcha.Code ?? String.Empty;
        }
    }
}
