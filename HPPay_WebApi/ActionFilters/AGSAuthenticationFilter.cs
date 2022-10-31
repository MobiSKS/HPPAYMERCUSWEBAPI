
using Dapper;
using HPPay.DataModel.AGS;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace HPPay_WebApi.ActionFilters
{
    //Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    public class AGSAuthenticationFilter: Attribute, IAuthorizationFilter
    {
        private readonly DapperContext _context;
        IConfiguration _configuration;


        public AGSAuthenticationFilter(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public class Root
        {
            public string Username;
            public string Password;
        }

        //  public bool AllowMultiple => throw new NotImplementedException();



        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // string authString;
            HttpRequest request = context.HttpContext.Request;
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var actionName = descriptor.ActionName;
            var controllerName = descriptor.ControllerName;

            // context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            context.HttpContext.Request.EnableBuffering();
            //StreamReader reader = new StreamReader(context.HttpContext.Request.Body);

            var bodyStr = "";
            var req = context.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            // req.EnableRewind();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
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

            //context.HttpContext.Request.Headers.TryGetValue("Username", out var OutUserName);
            //context.HttpContext.Request.Headers.TryGetValue("Password", out var OutPassword);

            bodyStr = bodyStr.Replace("'", "''");
            Root objObject = JsonConvert.DeserializeObject<Root>(bodyStr, settings);

            //string transactionId = objObject.TransactionId;

            if (string.IsNullOrEmpty(objObject.Username))
            {
                context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new AGSAPIAuthenticationFailureResult("Mandatory Field is missing: Username", request, actionName).Execute()
                     ));
            }
            else if (string.IsNullOrEmpty(objObject.Password))
            {
                context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new AGSAPIAuthenticationFailureResult("Mandatory Field is missing: Password", request, actionName).Execute()
                     ));
            }
            else
            {
                IEnumerable<AGSAPIValidateCredentialsModelOutput> Validation = new List<AGSAPIValidateCredentialsModelOutput>();

                var procedureName = "UspAGSAPIsValidateCredentials";
                var parameters = new DynamicParameters();
                parameters.Add("Username", objObject.Username, DbType.String, ParameterDirection.Input);
                parameters.Add("Password", objObject.Password, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();
                Validation = connection.Query<AGSAPIValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                foreach (var obj in Validation)
                {
                    if (obj.responseCode == 1)
                    {
                        context.Result = new JsonResult
                             (
                             new RouteValueDictionary(new AGSAPIAuthenticationFailureResult(obj.responseMessage, request, actionName).Execute()
                             ));
                    }
                    break;
                }
            }
        }


        public class AGSAPIAuthenticationFailureResult
        {
            public string ReasonPhrase = string.Empty;
            public string MethodName = string.Empty;
            public HttpRequest Request { get; set; }

            public AGSAPIAuthenticationFailureResult(string reasonphrase, HttpRequest request, string methodName)
            {
                MethodName = methodName;
                ReasonPhrase = reasonphrase;
                Request = request;
            }

            public AGSAPIReponseMessage Execute()
            {

                AGSAPIReponseMessage response = new AGSAPIReponseMessage
                {
                    responseCode = "1",
                    responseMessage = ReasonPhrase
                };
                return (response);

            }
        }

    }
}
