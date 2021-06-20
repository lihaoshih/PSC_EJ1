using System.Net;

namespace Library.Models.Network
{
    /// <summary>
    /// HttpRequestModel
    /// </summary>
    public class HttpRequestModel
    {
        /// <summary>
        /// 目標網址
        /// </summary>
        public string TargetUrl { get; set; }

        /// <summary>
        /// Cookie
        /// </summary>
        public CookieContainer Cookie { get; set; } = new CookieContainer();

        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; } = "html/text";

        /// <summary>
        /// 驗證碼
        /// </summary>
        public string Authorization { get; set; } = "";

        /// <summary>
        /// 來源設定
        /// </summary>
        public string Referer { get; set; } = "";

        /// <summary>
        /// 逾時時間
        /// </summary>
        public int Timeout { get; set; } = 5000;
    }
}