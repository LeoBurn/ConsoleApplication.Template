using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Contracts
{
    public interface ICaptchaService
    {
        Task<string> GetReCaptchaAsync();
    }
}
