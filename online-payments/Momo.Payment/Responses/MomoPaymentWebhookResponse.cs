using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment.Responses
{
    public class MomoPaymentWebhookResponse
    {
        public string PartnerCode { get; set; }

        public string RequestId { get; set; }

        public string OrderId { get; set; }

        public int ResultCode { get; set; }

        public string Message { get; set; }

        public long ResponseTime { get; set; }

        public string ExtraData { get; set; }

        public string Signature { get; set; }
    }
}
