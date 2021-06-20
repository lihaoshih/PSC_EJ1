using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Library.Interfaces.HttpStateCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.HttpStateCode;

namespace ParallelComparison.Services
{
    public class BaseServices
    {
        protected IConfiguration Configuration;

        protected IHttpContextAccessor HttpContextAccessor;

        protected ISession Session => this.HttpContextAccessor.HttpContext.Session;

        protected IHttpStateCodeService HttpStateCodeService;

        protected JsonFormatModel PackageFormatHttpCode(HttpContext context, int statecode, string description = "", object detail = null)
        {
            FormatHttpCodeModel model = new FormatHttpCodeModel();
            model.HttpContext = context;
            model.Description = description;
            model.StateCode = statecode;
            model.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            model.Detail = detail;

            return this.HttpStateCodeService.FormatHttpCode(model);
        }

        protected JsonStatusDetailModel DefaultDetailFormat(bool state, string message, string redirectUri = "", object detail = null)
        {
            JsonStatusDetailModel model = new JsonStatusDetailModel();
            model.State = state;
            model.Message = message;
            model.Redirect = redirectUri;
            if (detail != null)
            {
                model.Detail = detail;
            }

            return model;
        }
    }
}
