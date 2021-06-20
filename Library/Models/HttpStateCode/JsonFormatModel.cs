using Newtonsoft.Json.Linq;

namespace Library.Models.HttpStateCode
{
    public class JsonFormatModel : JsonMainModel
    {
        public JObject Detail { get; set; }
    }
}
