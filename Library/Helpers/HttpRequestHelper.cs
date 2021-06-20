using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helpers
{
    /// <summary>
    /// HttpRequest擴充方法
    /// </summary>
    public static class HttpRequestHelper
    {
        /// <summary>
        /// 取得完整URL網址
        /// 參照 Microsoft.AspNetCore.Http.Extensions 的GetDisplayUrl方法
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetAbsoluteUri(this HttpRequest request)
        {
            if (request == null)
            {
                return string.Empty;
            }

            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }

        /// <summary>
        /// 取得UserAgent(瀏覽器資訊)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string UserAgent(this HttpRequest request)
        {
            if (request == null)
            {
                return string.Empty;
            }
            return request.Headers[HeaderNames.UserAgent].ToString();
        }

        /// <summary>
        /// 取得Post Form資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetForm(this HttpRequest request)
        {
            try
            {
                StringBuilder s = new StringBuilder();
                foreach (string key in request.Form.Keys)
                {
                    s.Append(key + "=" + request.Form[key] + "&");
                }

                return s.ToString().Substring(0, s.Length - 1);

            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<string> GetRawBodyStringFormater(this HttpRequest httpRequest, Encoding encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            using (StreamReader reader = new StreamReader(httpRequest.Body, encoding))
            {
                return await reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// 二进制
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<byte[]> GetRawBodyBinaryFormater(this HttpRequest httpRequest, Encoding encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            using (StreamReader reader = new StreamReader(httpRequest.Body, encoding))
            {
                using (var ms = new MemoryStream(2048))
                {
                    await httpRequest.Body.CopyToAsync(ms);
                    return ms.ToArray();  // returns base64 encoded string JSON result
                }
            }
        }
    }
}
