using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using HPPay.Infrastructure.Response;
using Microsoft.AspNetCore.Mvc.Filters;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using static HPPay.Infrastructure.CommonClass.StatusMessage;
using HPPay.Infrastructure.TokenManager;
using HPPay.Infrastructure.CommonClass;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;

namespace HPPay_WebApi.ActionFilters
{

    public class APINSecretKeyCheckFilter : Attribute, IAuthorizationFilter
    {
        IConfiguration _configuration;
        string API_Key_Check, Secret_Key_Check;
        public APINSecretKeyCheckFilter(IConfiguration configuration)
        {
            API_Key_Check = configuration.GetSection("TokenSettings:API_Key").Value;
            Secret_Key_Check = configuration.GetSection("TokenSettings:SecretKey").Value;
            _configuration = configuration;
        }

        public class Root
        {
            public string useragent;
            public string userip;
            public string userid;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // string authString;
            HttpRequest request = context.HttpContext.Request;
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var actionName = descriptor.ActionName;
            context.HttpContext.Request.Headers.TryGetValue("API_Key", out var HAPI_Key);
            string API_Key = HAPI_Key.ToString();
            context.HttpContext.Request.Headers.TryGetValue("SecretKey", out var HSecretKey);
            string SecretKey = HSecretKey.ToString();

            if (API_Key == "")
            {
                context.Result = new JsonResult
                  (
                  new RouteValueDictionary(new AuthenticationFailureResult("API Key is null.Please pass API Key", request, actionName).Execute()
                  ));
            }
            else if (SecretKey == "")
            {
                context.Result = new JsonResult
                  (
                  new RouteValueDictionary(new AuthenticationFailureResult("Secret Key is null.Please pass Secret Key", request, actionName).Execute()
                  ));
            }

            else
            {
                
                if (API_Key == API_Key_Check && SecretKey == Secret_Key_Check)
                {

                }
                else
                {
                    context.Result = new JsonResult
                (
                new RouteValueDictionary(new AuthenticationFailureResult("API and Secret key is invalid", request, actionName).Execute()
                ));
                }


            }
        }

        public class AuthenticationFailureResult
        {
            public string ReasonPhrase = string.Empty;
            public string MethodName = string.Empty;
            public HttpRequest Request { get; set; }

            public AuthenticationFailureResult(string reasonphrase, HttpRequest request, string methodName)
            {
                MethodName = methodName;
                ReasonPhrase = reasonphrase;
                Request = request;
            }

            public ApiResponseMessage Execute()
            {

                ApiResponseMessage response = new ApiResponseMessage
                {
                    Status_Code = (int)HttpStatusCode.Unauthorized,
                    Message = "Token Expired",
                    Success = false,
                    Method_Name = MethodName,
                    Data = new { Message = ReasonPhrase },
                    Internel_Status_Code = (int)StatusInformation.API_Key_Is_Secret_Key_Invalid,
                    Model_State = null
                };
                return (response);

            }
        }
    }


}