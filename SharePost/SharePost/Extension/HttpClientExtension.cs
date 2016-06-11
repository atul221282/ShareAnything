using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Extension
{
    public static class HttpClientExtension
    {
        /// <summary>
        /// Post data as string
        /// </summary>
        /// <typeparam name="T">The model type</typeparam>
        /// <param name="client"></param>
        /// <param name="url">The api url</param>
        /// <param name="model">The specified model</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PostStringAsync<T>(this HttpClient client, string url, T model)
        {
            return client.PostAsync(url,
                new StringContent(model != null ? JsonConvert.SerializeObject(model) : "", Encoding.UTF8, "application/json"));
        }

    }
}
