
namespace Library.Models.Network
{
    /// <summary>
    /// HttpRequestPostStringModel
    /// </summary>
    public class HttpRequestPostStringModel: HttpRequestModel
    {
        /// <summary>
        /// 傳送的資料
        /// </summary>
        public string PostData { get; set; } = "";
    }
}