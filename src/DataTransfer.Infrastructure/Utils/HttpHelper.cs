using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Infrastructure.Utils
{
    public static class HttpHelper
    {
        /// <summary>
        /// client
        /// </summary>
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// Get请求(返回string，自行解析)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static string GetAsyncStr(string url)
        {
            return client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T GetAsync<T>(string url)
        {
            var strRes = GetAsyncStr(url);
            return JsonConvert.DeserializeObject<T>(strRes);
        }

        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static string Post(string url, object data, Encoding encoding = null)
        {
            string body = (data is string) ? (string)data : JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(body);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var res = client.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
            return res;
        }

        public static string Put(string url, object data, Encoding encoding = null)
        {
            string body = (data is string) ? (string)data : JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(body);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var res = client.PutAsync(url, content).Result.Content.ReadAsStringAsync().Result;
            return res;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T PutAsync<T>(string url, object data)
        {
            var strRes = Put(url, data);
            return JsonConvert.DeserializeObject<T>(strRes);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T PostAsync<T>(string url, object data)
        {
            var strRes = Post(url, data);
            return JsonConvert.DeserializeObject<T>(strRes);
        }

        /// <summary>
        /// Post请求HttpContent
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpContent"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static string PostHttpContentStr(string url, HttpContent httpContent)
        {
            var res = client.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            return res;
        }

        /// <summary>
        /// Post请求HttpContent
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpContent"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T PostHttpContent<T>(string url, HttpContent httpContent)
        {
            var strRes = PostHttpContentStr(url, httpContent);
            return JsonConvert.DeserializeObject<T>(strRes);
        }
    }
}
