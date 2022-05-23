using Cornucopias.Mint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Contracts
{
    public interface ICornucopiasService
    {
        public Task<CornucopiasLoginResponse> Login(string email, string password, string recaptchaCode);
    }
}
