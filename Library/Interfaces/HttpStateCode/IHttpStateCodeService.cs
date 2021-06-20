using Library.Models.HttpStateCode;

namespace Library.Interfaces.HttpStateCode
{
    public interface IHttpStateCodeService
    {
        JsonFormatModel FormatHttpCode(FormatHttpCodeModel model);
    }
}
