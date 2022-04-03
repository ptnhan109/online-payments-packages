using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Momo.Payment;
using Momo.Payment.Interfaces;
using Momo.Payment.Models;
using Momo.Payment.Requests;
using Momo.Payment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase, IMomoWebhook
    {
        private readonly IMomoService _service;

        public WeatherForecastController(IMomoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> IpnMomo(MomoPaymentWebookRequest request)
        {
            await Task.Yield();
            var result = new MomoPaymentWebhookResponse();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Momo()
        {
            var request = new MomoCreatePayment()
            {
                Amout = 20000,
                OrderId = Guid.NewGuid().ToString(),
                OrderInfo = Guid.NewGuid().ToString(),
                RedirectUrl = "https://google.com"
            };
            var test = await _service.CreatePayment(request);

            return Ok(test);
        }
    }
}
