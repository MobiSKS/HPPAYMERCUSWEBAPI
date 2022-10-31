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

    public class CustomAuthenticationFormFilter : Attribute, IAuthorizationFilter
    {
        IConfiguration _configuration;
        string API_Key_Check ;
        public CustomAuthenticationFormFilter(IConfiguration configuration)
        {
            API_Key_Check = configuration.GetSection("TokenSettings:API_Key").Value;
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

            string authorization = request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorization))
            {
                context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new AuthenticationFailureResult("Missing Authorization Header", request, actionName).Execute()
                     ));
            }

            if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                //string token = authorization.Substring("Bearer ".Length).Trim();
                string token = authorization["Bearer ".Length..].Trim();
                if (string.IsNullOrEmpty(token))
                {
                    context.Result = new JsonResult
                   (
                   new RouteValueDictionary(new AuthenticationFailureResult("Missing Token", request, actionName).Execute()
                   ));
                }
            }
            else
            {
                context.Result = new JsonResult
                  (
                  new RouteValueDictionary(new AuthenticationFailureResult("Invalid Authorization Scheme", request, actionName).Execute()
                  ));
            }

            context.HttpContext.Request.Headers.TryGetValue("API_Key", out var HAPI_Key);
            string API_Key = HAPI_Key.ToString();
            context.HttpContext.Request.Headers.TryGetValue("SecretKey", out _);
            //string SecretKey = HSecretKey.ToString();

            if (API_Key == "")
            {
                context.Result = new JsonResult
                  (
                  new RouteValueDictionary(new AuthenticationFailureResult("API Key is null.Please pass API Key", request, actionName).Execute()
                  ));
            }

            else
            {
               // context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                context.HttpContext.Request.EnableBuffering();
                //StreamReader reader = new StreamReader(context.HttpContext.Request.Body);

                var bodyStr = "";
                var req = context.HttpContext.Request;

                // Allows using several time the stream in ASP.Net Core
               // req.EnableRewind();

                // Arguments: Stream, Encoding, detect encoding, buffer size 
                // AND, the most important: keep stream opened
                using (StreamReader reader= new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = reader.ReadToEnd();
                }

                // Rewind, so the core is not lost when it looks the body for the request
                req.Body.Position = 0;


               // var body = reader.ReadToEnd();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                bodyStr = bodyStr.Replace("'", "''");
                Root objObject = JsonConvert.DeserializeObject<Root>(bodyStr, settings);

                if (API_Key == API_Key_Check)
                {
                    string token = authorization["Bearer ".Length..].Trim();
                    ClaimsPrincipal principal = new ClaimsPrincipal();
                    //principal = TokenManager.GetPrincipal(token, objObject.useragent, objObject.userip, objObject.userid);
                    principal = TokenManager.GetPrincipal(token, objObject.useragent, objObject.userid, objObject.userip);

                    if (principal == null)
                    {

                        context.Result = new JsonResult
                (
                new RouteValueDictionary(new AuthenticationFailureResult("Unauthorized Access", request, actionName).Execute()
                ));
                    }
                }
                else
                {
                    context.Result = new JsonResult
                (
                new RouteValueDictionary(new AuthenticationFailureResult("API key is invalid", request, actionName).Execute()
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