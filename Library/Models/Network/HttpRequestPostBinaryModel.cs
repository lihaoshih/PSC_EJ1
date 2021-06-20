
namespace Library.Models.Network
{
    /// <summary>
    /// HttpRequestBinaryModel
    /// </summary>
    public class HttpRequestPostBinaryModel : HttpRequestModel
    {
        /// <summary>
        /// 傳送的資料
        /// </summary>
        public byte[] PostDataByte { get; set; } = null;
    }
}