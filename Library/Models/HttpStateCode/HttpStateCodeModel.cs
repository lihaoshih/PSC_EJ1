
namespace Library.Models.HttpStateCode
{
    /// <summary>
    /// HTTP 狀態碼
    /// </summary>
    public class HttpStateCodeModel
    {
        /// <summary>
        /// ID編號
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 狀態碼
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 英文
        /// </summary>
        public string Eng { get; set; }
        /// <summary>
        /// 日文
        /// </summary>
        public string Jp { get; set; }
        /// <summary>
        /// 繁體中文
        /// </summary>
        public string Tw { get; set; }
    }
}