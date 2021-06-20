using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.Helpers
{
    /// <summary>
    /// JsonHelper
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 物件轉JSON
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// JSON字串轉MODEL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T ToModel<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// JOBJECT轉JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public static T ToModel<T>(this JObject jsonObject)
        {
            return jsonObject.ToObject<T>();
        }
    }
}