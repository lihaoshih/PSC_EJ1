using Library.Interfaces.Network;
using Library.Models.Network;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Library.Services.Network
{
    /// <summary>
    /// 網路傳輸服務
    /// </summary>
    public class HttpWebResponseService : IHttpWebResponseService
    {
        /// <summary>
        /// 使用 GET 取得 String
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>String字串</returns>
        public string HttpWebRequestStringByGet(HttpRequestModel requestModel)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            CookieContainer cookieContainer = new CookieContainer();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestModel.TargetUrl);
            request.Method = "GET";
            request.Timeout = requestModel.Timeout;
            request.KeepAlive = true;
            request.CookieContainer = requestModel.Cookie;
            request.ContentType = requestModel.ContentType;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.ProtocolVersion = HttpVersion.Version10;
            request.Referer = requestModel.Referer;
            if (!string.IsNullOrWhiteSpace(requestModel.Authorization))
            {
                request.Headers[HttpRequestHeader.Authorization] = requestModel.Authorization;
            }

            return this.HttpWebRequestString(request, ref cookieContainer);
        }

        /// <summary>
        /// 使用 POST 取得 String
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>String字串</returns>
        public string HttpWebRequestStringByPost(HttpRequestPostStringModel requestModel)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            CookieContainer cookieContainer = new CookieContainer();
            UTF8Encoding encodeing = new UTF8Encoding();
            byte[] byteData = encodeing.GetBytes(requestModel.PostData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestModel.TargetUrl);
            request.Method = "POST";
            request.Timeout = requestModel.Timeout;
            request.KeepAlive = true;
            request.CookieContainer = requestModel.Cookie;
            request.ContentType = requestModel.ContentType;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.ProtocolVersion = HttpVersion.Version10;
            request.Referer = requestModel.Referer;
            request.ContentLength = byteData.Length;
            if (!string.IsNullOrWhiteSpace(requestModel.Authorization))
            {
                request.Headers[HttpRequestHeader.Authorization] = requestModel.Authorization;
            }
            request.GetRequestStream().Write(byteData, 0, byteData.Length);

            return this.HttpWebRequestString(request, ref cookieContainer);
        }

        /// <summary>
        /// 使用 GET 取得 Stream
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>Stream串流資料</returns>
        public Stream HttpWebRequestStreamByGet(HttpRequestModel requestModel)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            CookieContainer cookieContainer = new CookieContainer();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestModel.TargetUrl);
            request.Method = "GET";
            request.Timeout = requestModel.Timeout;
            request.KeepAlive = true;
            request.CookieContainer = requestModel.Cookie;
            request.ContentType = requestModel.ContentType;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.ProtocolVersion = HttpVersion.Version10;
            request.Referer = requestModel.Referer;
            if (!string.IsNullOrWhiteSpace(requestModel.Authorization))
            {
                request.Headers[HttpRequestHeader.Authorization] = requestModel.Authorization;
            }

            return this.HttpWebRequestStream(request, ref cookieContainer);
        }

        /// <summary>
        /// 使用 POST 取得 Stream
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>Stream串流資料</returns>
        public Stream HttpWebRequestStreamByPost(HttpRequestPostStringModel requestModel)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            CookieContainer cookieContainer = new CookieContainer();
            UTF8Encoding encodeing = new UTF8Encoding();
            byte[] byteData = encodeing.GetBytes(requestModel.PostData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestModel.TargetUrl);
            request.Method = "POST";
            request.Timeout = requestModel.Timeout;
            request.KeepAlive = true;
            request.CookieContainer = requestModel.Cookie;
            request.ContentType = requestModel.ContentType;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.ProtocolVersion = HttpVersion.Version10;
            request.Referer = requestModel.Referer;
            request.ContentLength = byteData.Length;
            if (!string.IsNullOrWhiteSpace(requestModel.Authorization))
            {
                request.Headers[HttpRequestHeader.Authorization] = requestModel.Authorization;
            }
            request.GetRequestStream().Write(byteData, 0, byteData.Length);

            return this.HttpWebRequestStream(request, ref cookieContainer);
        }

        /// <summary>
        /// 使用 POST 傳輸byte 取得 String
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public string HttpWebRequestBinaryByPost(HttpRequestPostBinaryModel requestModel)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            CookieContainer cookieContainer = new CookieContainer();
            UTF8Encoding encodeing = new UTF8Encoding();
            byte[] byteData = requestModel.PostDataByte;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestModel.TargetUrl);
            request.Method = "POST";
            request.Timeout = requestModel.Timeout;
            request.KeepAlive = true;
            request.CookieContainer = requestModel.Cookie;
            request.ContentType = requestModel.ContentType;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            request.ProtocolVersion = HttpVersion.Version10;
            request.Referer = requestModel.Referer;
            request.ContentLength = byteData.Length;
            if (!string.IsNullOrWhiteSpace(requestModel.Authorization))
            {
                request.Headers[HttpRequestHeader.Authorization] = requestModel.Authorization;
            }

            request.GetRequestStream().Write(byteData, 0, byteData.Length);

            return this.HttpWebRequestString(request, ref cookieContainer);
        }

        /// <summary>
        /// 設定Cookie，設定後要記得加回CookieContainer
        /// </summary>
        /// <param name="name">名子</param>
        /// <param name="value">數值</param>
        /// <param name="domain">Domain</param>
        /// <returns></returns>
        public Cookie SetCookie(string name, string value, string domain)
        {
            return new Cookie { Name = name, Value = value, Domain = domain };
        }

        /// <summary>
        /// WebRequest 傳輸模組(string)
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cookieContainer">cookieContainer</param>
        /// <returns>string</returns>
        private string HttpWebRequestString(HttpWebRequest request, ref CookieContainer cookieContainer)
        {
            HttpWebResponse httpWebResponse = this.GetHttpWebResponse(request, ref cookieContainer);
            if (httpWebResponse == null)
            {
                throw new Exception("拒絕連線，無法連上這個網站");
            }

            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string resualt = streamReader.ReadToEnd();
            streamReader.Close();

            return resualt;
        }

        /// <summary>
        /// WebRequest 傳輸模組(steam)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cookieContainer"></param>
        /// <returns>steam</returns>
        private Stream HttpWebRequestStream(HttpWebRequest request, ref CookieContainer cookieContainer)
        {
            HttpWebResponse httpWebResponse = this.GetHttpWebResponse(request, ref cookieContainer);
            if (httpWebResponse == null)
            {
                throw new Exception("拒絕連線，無法連上這個網站");
            }

            Stream resStream = httpWebResponse.GetResponseStream();

            return resStream;
        }

        /// <summary>
        /// 取得HttpWebResponse
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cookieContainer"></param>
        /// <returns></returns>
        private HttpWebResponse GetHttpWebResponse(HttpWebRequest request, ref CookieContainer cookieContainer)
        {
            HttpWebResponse response;

            try
            {
                //執行Request
                //若網站回應錯誤，就會在此引發WebException
                response = (HttpWebResponse)request.GetResponse();
                cookieContainer.Add(response.Cookies);
                return response;
            }
            catch (WebException e)
            {
                //網站回應錯誤,
                response = (HttpWebResponse)e.Response;
                return response;
            }
        }
    }
}