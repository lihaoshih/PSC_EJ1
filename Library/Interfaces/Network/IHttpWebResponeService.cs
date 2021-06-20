using Library.Models.Network;
using System.IO;
using System.Net;

namespace Library.Interfaces.Network
{
    /// <summary>
    /// 網路服務
    /// </summary>
    public interface IHttpWebResponseService
    {
        /// <summary>
        /// HttpWebRequest GET
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>String字串</returns>
        string HttpWebRequestStringByGet(HttpRequestModel requestModel);

        /// <summary>
        /// HttpWebRequest POST
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>String字串</returns>
        string HttpWebRequestStringByPost(HttpRequestPostStringModel requestModel);

        /// <summary>
        /// HttpWebRequest GET
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>Stream串流資料</returns>
        Stream HttpWebRequestStreamByGet(HttpRequestModel requestModel);

        /// <summary>
        /// HttpWebRequest POST
        /// </summary>
        /// <param name="requestModel">設定Client參數</param>
        /// <returns>Stream串流資料</returns>
        Stream HttpWebRequestStreamByPost(HttpRequestPostStringModel requestModel);

        /// <summary>
        /// 設定Cookie，設定後要記得加回CookieContainer
        /// </summary>
        /// <param name="name">名子</param>
        /// <param name="value">數值</param>
        /// <param name="domain">Domain</param>
        /// <returns></returns>
        Cookie SetCookie(string name, string value, string domain);
    }
}