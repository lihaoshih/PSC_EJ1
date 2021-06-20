using Library.Helpers;
using Library.Interfaces.Encryption;
using Library.Interfaces.HttpStateCode;
using Library.Interfaces.Network;
using Library.Models.HttpStateCode;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ParallelComparison.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelComparison.Services
{
    public class ApiServices : BaseServices
    {
        private readonly IShaEncryptService _shaEncryptService;

        private readonly IHttpWebResponseService _httpWebResponseService;

        public ApiServices(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            IHttpStateCodeService httpStateCodeService,
            IShaEncryptService shaEncryptService,
            IHttpWebResponseService httpWebResponseService
            )
        {
            base.Configuration = configuration;
            base.HttpContextAccessor = httpContextAccessor;
            base.HttpStateCodeService = httpStateCodeService;
            this._shaEncryptService = shaEncryptService;
            this._httpWebResponseService = httpWebResponseService;
        }

        public JsonFormatModel PasswordSha256(HttpContext context, string password)
        {
            password = this._shaEncryptService.SHA256Encrypt(password);
            return base.PackageFormatHttpCode(context, 200, "", base.DefaultDetailFormat(true, password));
        }

        public JsonFormatModel GetAccountInfoInSession(HttpContext context)
        {
            AccountModel userData = base.Session.GetObjectFromJson<AccountModel>("UserData");
            return base.PackageFormatHttpCode(context, 200, "", userData);
        }

    }
}
