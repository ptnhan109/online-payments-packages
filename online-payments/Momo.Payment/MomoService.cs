using Microsoft.Extensions.Options;
using Momo.Payment.AppOptions;
using Momo.Payment.Models;
using Momo.Payment.Requests;
using Momo.Payment.Responses;
using Momo.Payment.Urls;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Momo.Payment
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponse> CreatePayment(MomoCreatePayment request);
    }

    public class MomoService : IMomoService
    {
        private readonly MomoSettings _options;

        public MomoService(IOptions<MomoSettings> options)
        {
            _options = options.Value;
        }
        public async Task<MomoCreatePaymentResponse> CreatePayment(MomoCreatePayment request)
        {
            var bodyRequest = new MomoCreatePaymentRequest()
            {
                Amount = request.Amout,
                RedirectUrl = request.RedirectUrl,
                OrderId = request.OrderId,
                OrderInfo = request.OrderInfo,
                AutoCapture = true,
                IpnUrl = _options.WebHookUrl,
                Lang = "vi",
                PartnerCode = _options.MomoCredential.PartnerCode,
                PartnerName = _options.MomoCredential.PartnerName,
                ExtraData = string.Empty,
                RequestType = "captureWallet",
                RequestId = Guid.NewGuid().ToString(),
                Signature = string.Empty,
                StoreId = _options.MomoCredential.PartnerName
            };

            bodyRequest.Signature = GenerateSignature(_options.MomoCredential.AccessKey, bodyRequest.Amount.ToString(),
                bodyRequest.ExtraData, bodyRequest.IpnUrl, bodyRequest.OrderId, bodyRequest.OrderInfo,
                bodyRequest.PartnerCode, bodyRequest.RedirectUrl, bodyRequest.RequestId, bodyRequest.RequestType);
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string body = JsonConvert.SerializeObject(bodyRequest,serializerSettings);
            var requestModel = new WebRequestModel()
            {
                BodyJson = body,
                Method = HttpMethod.Post,
                Url = Url.CreateSession,
                ContentType = "application/json",
                ListHeader = default
            };

            var result = await RequestHelper.PostAsync<MomoCreatePaymentResponse>(requestModel);

            return result;
        }

        private string GenerateSignature(string accessKey,string amount, string extraData, string ipnUrl,
            string orderId, string orderInfo, string partnerCode, string redirectUrl, string requestId, string requestType)
        {
            string plainText = $"accessKey={accessKey}&amount={amount}&extraData={extraData}&ipnUrl={ipnUrl}&orderId={orderId}" +
                $"&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={redirectUrl}&requestId={requestId}&requestType={requestType}";
            return plainText.ToSha256(_options.MomoCredential.SecretKey);
        }
    }
}
