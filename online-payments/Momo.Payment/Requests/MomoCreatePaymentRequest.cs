using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment.Requests
{
    public class MomoCreatePaymentRequest
    {
        public string PartnerCode { get; set; }

        public string PartnerName { get; set; }

        public string StoreId { get; set; }

        public string RequestId { get; set; }

        public long Amount { get; set; }

        public string OrderId { get; set; }

        public string OrderInfo { get; set; }

        public bool AutoCapture { get; set; } = true;

        public string RedirectUrl { get; set; }

        public string IpnUrl { get; set; }

        public string RequestType { get; set; } = "captureWallet";

        public string ExtraData { get; set; } = string.Empty;

        public string Lang { get; set; } = "vi";

        public string Signature { get; set; }
    }
}
