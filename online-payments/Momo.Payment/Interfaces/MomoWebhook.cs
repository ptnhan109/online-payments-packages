using Microsoft.AspNetCore.Mvc;
using Momo.Payment.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Momo.Payment.Interfaces
{
    public interface IMomoWebhook
    {
        Task<IActionResult> IpnMomo(MomoPaymentWebookRequest request);
    }
}
