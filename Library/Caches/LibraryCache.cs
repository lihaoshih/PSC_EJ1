using Library.Models.HttpStateCode;
using System.Collections.Generic;

namespace Library.Caches
{
    /// <summary>
    /// AppDataCache 全域快取 (僅限存放RyuukiLib模組的快取，供系統快速使用)
    /// </summary>
    public static class LibraryCache
    {
        /// <summary>
        /// Http狀態碼
        /// </summary>
        public static List<HttpStateCodeModel> StateCode { get; set; }

        /// <summary>
        /// LOG路徑
        /// </summary>
        public static string LogPath { get; set; } = @"D:/Working/logs/";
    }
}