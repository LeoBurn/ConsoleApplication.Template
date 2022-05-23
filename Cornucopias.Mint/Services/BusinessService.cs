using Cornucopias.Mint.Configuration;
using Cornucopias.Mint.Contracts;
using Cornucopias.Mint.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Services
{
    public class BusinessService : IBusinessService
    {
        private ICornucopiasService _cornucopiasService;
        private ICaptchaService _captchaService;
        private ApplicationConfiguration _applicationConfiguration;
        private ILogger<BusinessService> _logger;

        public BusinessService(ICornucopiasService cornucopiasService, ICaptchaService captchaService, ApplicationConfiguration applicationConfiguration, ILogger<BusinessService> logger)
        {
            _cornucopiasService = cornucopiasService;
            _captchaService = captchaService;
            _applicationConfiguration = applicationConfiguration;
            _logger = logger;
        }

        public async Task MintAsync()
        {
            _logger.LogInformation("MintAsync");
            //If we don't have the token on configuration we need to login
            CornucopiasLoginResponse cornucopiasLoginResponse = new CornucopiasLoginResponse();
            if (string.IsNullOrEmpty(_applicationConfiguration.Cornucopias.Token))
            {
                var token = await _captchaService.GetReCaptchaAsync();
                cornucopiasLoginResponse = await _cornucopiasService.Login(_applicationConfiguration.Cornucopias.Email, _applicationConfiguration.Cornucopias.Password, token);
            }
            else
            {
                //TODO: Get discord roles and user with auth token
            }
            

        }
    }
}
