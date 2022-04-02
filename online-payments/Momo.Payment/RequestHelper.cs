using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Momo.Payment
{
    public class RequestHelper
    {
        public static async Task<TResponse> PostAsync<TResponse>(WebRequestModel webRequestModel) where TResponse : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    if (webRequestModel.ListHeader != null)
                    {
                        foreach (DictionaryEntry item in webRequestModel.ListHeader)
                        {
                            client.DefaultRequestHeaders.Add(item.Key.ToString(), item.Value.ToString());
                        }
                    }

                    var content = new StringContent(webRequestModel.BodyJson == null ? "" : webRequestModel.BodyJson, Encoding.UTF8, "application/json");
                    var postTask = await client.PostAsync(webRequestModel.Url, content);

                    var msg = postTask.Content.ReadAsStringAsync().Result;

                    var result = JsonConvert.DeserializeObject<TResponse>(msg);

                    return result;
                }
            }
            catch (Exception)
            {
                return default(TResponse);
            }
        }

    }
}

    public class WebRequestModel
    {
        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public string ContentType { get; set; }
        public string BodyJson { get; set; }
        public ListDictionary ListHeader { get; set; }
    }

