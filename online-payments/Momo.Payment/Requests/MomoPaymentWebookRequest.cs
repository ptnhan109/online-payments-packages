﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment.Requests
{
    public class MomoPaymentWebookRequest
    {
        public string PartnerCode { get; set; }

        public string OrderId { get; set; }

        public string RequestId { get; set; }

        public long Amount { get; set; }

        public string OrderInfo { get; set; }

        public string OrderType { get; set; }

        public long TransId { get; set; }

        public int ResultCode { get; set; }

        public string Message { get; set; }

        public string PayType { get; set; }

        public long ResponseTime { get; set; }

        public string ExtraData { get; set; }

        public string Signature { get; set; }
    }
}
