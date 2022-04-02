using Momo.Payment.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment.Models
{
    public class MomoCreatePayment
    {
        public string OrderId { get; set; }

        public long Amout { get; set; }

        public string OrderInfo { get; set; }

        public string RedirectUrl { get; set; }
    }
}
