using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornucopias.Mint.Model
{
    public class CheckCanPlaceOrderResponse
    {
        public string PaymentAddressId { get; set; }
        public string AdaPaymentAddress { get; set; }
    }
}
