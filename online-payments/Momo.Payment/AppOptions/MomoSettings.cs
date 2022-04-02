using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment.AppOptions
{
    public class MomoSettings
    {
        public MomoCredential MomoCredential { get; set; }

        public string WebHookUrl { get; set; }
    }

    public class MomoCredential
    {
        public string PartnerCode { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public string PublicKey { get; set; }

        public string PartnerName { get; set; }
    }
}
