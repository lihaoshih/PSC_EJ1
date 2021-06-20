using Library.Helpers;
using Library.Interfaces.HttpStateCode;
using Library.Models.HttpStateCode;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Library.Caches;

namespace Library.Services.HttpStateCode
{
    /// <summary>
    /// HttpStateCode
    /// </summary>
    public class HttpStateCodeService : IHttpStateCodeService
    {
        /// <summary>
        /// 輸出狀態碼及內容JSON (統一輸出規格)
        /// </summary>
        /// <param name="code">HTTP狀態碼</param>
        /// <param name="description">狀態描述</param>
        /// <param name="detail">細節描述(可傳入物件型態)</param>
        public JsonFormatModel FormatHttpCode(FormatHttpCodeModel model)
        {
            //清除Response
            if (model.HttpContext != null)
            {
                model.HttpContext.Response.Clear();
                model.HttpContext.Response.ContentType = "application/json";
                model.HttpContext.Response.StatusCode = model.StateCode;
            }

            //當StateCode還沒讀入快取，則先讀入快取。
            if (LibraryCache.StateCode == null)
            {
                LibraryCache.StateCode = this.LoadingStateCode();
            }

            HttpStateCodeModel codeData = LibraryCache.StateCode.Find(x => x.Code == model.StateCode);
            JsonFormatModel resualt = new JsonFormatModel();
            resualt.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            if (codeData != null && string.IsNullOrWhiteSpace(model.Description))
            {
                resualt.StateCode = (int)codeData.Code;
                resualt.Description = codeData.Jp;
            }
            else
            {
                resualt.StateCode = model.StateCode;
                resualt.Description = model.Description;
            }

            if (model.Detail != null)
            {
                resualt.Detail = JObject.Parse(model.Detail.ToJson());
            }

            return resualt;
        }

        /// <summary>
        /// 讀取狀態碼表
        /// </summary>
        /// <param name="httpStateCode">回傳狀態表</param>
        /// <returns>回傳是否成功(目前一律成功)</returns>
        private List<HttpStateCodeModel> LoadingStateCode()
        {
            List<HttpStateCodeModel> httpStateCode = new List<HttpStateCodeModel>();
            httpStateCode.Add(new HttpStateCodeModel { Id = 1, Code = 100, Eng = "Continue", Jp = "継続。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 101, Eng = "Switching Protocols", Jp = "プロトコル切替え。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 102, Eng = "Processing", Jp = "処理中。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 103, Eng = "Early Hints", Jp = "早期のヒント。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 200, Eng = "OK", Jp = "OK。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 201, Eng = "Created", Jp = "作成。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 202, Eng = "Accepted", Jp = "受理。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 203, Eng = "Non-Authoritative Information", Jp = "信頼できない情報。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 204, Eng = "No Content", Jp = "内容なし。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 205, Eng = "Reset Content", Jp = "内容のリセット。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 206, Eng = "Partial Content", Jp = "部分的内容。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 207, Eng = "Multi-Status", Jp = "複数のステータス。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 208, Eng = "Already Reported", Jp = "既に報告。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 226, Eng = "IM Used", Jp = "IM使用。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 301, Eng = "Moved Permanently", Jp = "恒久的に移動した。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 302, Eng = "Found", Jp = "発見した。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 303, Eng = "See Other", Jp = "他を参照せよ。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 304, Eng = "Not Modified", Jp = "未更新。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 305, Eng = "Use Proxy", Jp = "プロキシを使用せよ。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 306, Eng = "(Unused)", Jp = "将来のために予約されている。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 307, Eng = "Temporary Redirect", Jp = "一時的リダイレクト。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 308, Eng = "Permanent Redirect", Jp = "恒久的リダイレクト。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 400, Eng = "Bad Request", Jp = "リクエストが不正である。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 401, Eng = "Unauthorized", Jp = "認証が必要である。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 402, Eng = "Payment Required", Jp = "支払いが必要である。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 403, Eng = "Forbidden", Jp = "禁止されている。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 404, Eng = "Not Found", Jp = "未検出。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 405, Eng = "Method Not Allowed", Jp = "許可されていないメソッド。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 406, Eng = "Not Acceptable", Jp = "受理できない。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 407, Eng = "Proxy Authentication Required", Jp = "プロキシ認証が必要である。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 408, Eng = "Request Timeout", Jp = "リクエストタイムアウト。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 409, Eng = "Conflict", Jp = "競合。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 410, Eng = "Gone", Jp = "消滅した。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 411, Eng = "Length Required", Jp = "長さが必要。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 412, Eng = "Precondition Failed", Jp = "前提条件で失敗した。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 413, Eng = "Payload Too Large", Jp = "ペイロードが大きすぎる。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 414, Eng = "URI Too Long", Jp = "URIが大きすぎる。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 415, Eng = "Unsupported Media Type", Jp = "サポートしていないメディアタイプ。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 416, Eng = "Range Not Satisfiable", Jp = "レンジは範囲外にある。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 417, Eng = "Expectation Failed", Jp = "Expectヘッダによる拡張が失敗。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 418, Eng = "I'm a teapot", Jp = "私はティーポット。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 421, Eng = "Misdirected Request", Jp = "誤ったリクエスト。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 422, Eng = "Unprocessable Entity", Jp = "処理できないエンティティ。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 423, Eng = "Locked", Jp = "ロックされている。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 424, Eng = "Failed Dependency", Jp = "依存関係で失敗。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 426, Eng = "Upgrade Required", Jp = "アップグレード要求。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 451, Eng = "Unavailable For Legal Reasons", Jp = "法的理由により利用不可。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 500, Eng = "Internal Server Error", Jp = "サーバ内部エラー。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 501, Eng = "Not Implemented", Jp = "実装されていない。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 502, Eng = "Bad Gateway", Jp = "不正なゲートウェイ。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 503, Eng = "Service Unavailable", Jp = "サービス利用不可。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 504, Eng = "Gateway Timeout", Jp = "ゲートウェイタイムアウト。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 505, Eng = "HTTP Version Not Supported", Jp = "サポートしていないHTTPバージョン。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 506, Eng = "Variant Also Negotiates", Jp = "Transparent Content Negotiation in HTTPで定義されている拡張ステータスコード。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 507, Eng = "Insufficient Storage", Jp = "容量不足。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 508, Eng = "Loop Detected", Jp = "ループを検出。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 509, Eng = "Bandwidth Limit Exceeded", Jp = "帯域幅制限超過。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 510, Eng = "Not Extended", Jp = "拡張できない。", Tw = "" });
            httpStateCode.Add(new HttpStateCodeModel { Id = 2, Code = 511, Eng = "Network Authentication Required", Jp = "ネットワークに対する認証が必要。", Tw = "" });

            return httpStateCode;
        }
    }
}
