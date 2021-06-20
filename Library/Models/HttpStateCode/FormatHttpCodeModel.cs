using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.HttpStateCode
{
    /// <summary>
    /// 輸出狀態碼及內容
    /// </summary>
    public class FormatHttpCodeModel : JsonMainModel
    {
        /// <summary>
        /// HttpContext
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// 細節
        /// </summary>
        public object Detail { get; set; } = null;
    }
}
