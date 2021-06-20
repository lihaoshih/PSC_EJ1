using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.HttpStateCode
{
    /// <summary>
    /// 基礎細節格式
    /// </summary>
    public class JsonStatusDetailModel
    {
        /// <summary>
        /// 狀態碼
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 其他資訊
        /// </summary>
        public object Detail { get; set; }
        /// <summary>
        /// 要轉跳的頁面
        /// </summary>
        public string Redirect { get; set; }
    }
}
