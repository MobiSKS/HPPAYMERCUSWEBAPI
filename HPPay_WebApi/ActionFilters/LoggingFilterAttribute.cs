using HPPay.DataModel;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;

namespace HPPay_WebApi.ActionFilters
{
    public class LoggingFilterAttribute : IActionFilter
    {
        private readonly ILogger<LoggingFilterAttribute> _logger;
        public LoggingFilterAttribute(ILogger<LoggingFilterAttribute> logger)
        {
            _logger = logger;
        }
        public class ObjClass
        {
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
            public string Username { get; set; }
        }

        public class Root
        {
            public ObjClass ObjClass { get; set; }
        }
        public static string StcjsonInput;

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var descriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            var actionName = descriptor.ActionName;
            var controllerName = descriptor.ControllerName;
            #region comment code
            //var aa = descriptor.Properties;
            //string json = JsonConvert.SerializeObject(countries, Formatting.Indented, new JsonSerializerSettings
            //{
            //    TraceWriter = new NLogTraceWriter()
            //});
            //NLogTraceWriter
            //NLogTraceWriter nLogTraceWriter = new NLogTraceWriter();
            //nLogTraceWriter.
            //NLogTraceWriter.
            //GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            //var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            #endregion
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            MappedDiagnosticsLogicalContext.Set("methodName", actionName);
            var jsonInput = JsonConvert.SerializeObject(filterContext.ActionArguments);
            StcjsonInput = jsonInput;
            string ReferenceNo = Variables.FunGenerateStaticStringUId();
            StaticClass.APIReferenceNo = ReferenceNo;
            Root objObject = JsonConvert.DeserializeObject<Root>(jsonInput, settings);

            if (controllerName == "CustomerAPI")
            {
                MappedDiagnosticsLogicalContext.Set("Useragent", "CustomerAPI");
                MappedDiagnosticsLogicalContext.Set("Userip", "100:100:100:100");
                MappedDiagnosticsLogicalContext.Set("Userid", objObject.ObjClass.Username);
            }
            else if (controllerName == "HLFL")
            {
                MappedDiagnosticsLogicalContext.Set("Useragent", "HLFL");
                MappedDiagnosticsLogicalContext.Set("Userip", "100:100:100:100");
                MappedDiagnosticsLogicalContext.Set("Userid", "HLFLAdmin");
            }

            else if (controllerName == "AGS")
            {
                MappedDiagnosticsLogicalContext.Set("Useragent", "AGS");
                MappedDiagnosticsLogicalContext.Set("Userip", "100:100:100:100");
                MappedDiagnosticsLogicalContext.Set("Userid", "AGSAdmin");
            }

            else if (controllerName == "EGVAPI")
            {
                MappedDiagnosticsLogicalContext.Set("Useragent", "EGVAPI");
                MappedDiagnosticsLogicalContext.Set("Userip", "100:100:100:100");
                MappedDiagnosticsLogicalContext.Set("Userid", "EGVAPIAdmin");
            }

            else if (controllerName == "TMFL")
            {
                MappedDiagnosticsLogicalContext.Set("Useragent", "TMFL");
                MappedDiagnosticsLogicalContext.Set("Userip", "100:100:100:100");
                MappedDiagnosticsLogicalContext.Set("Userid", "TMFLAdmin");
            }
            else
            {
                MappedDiagnosticsLogicalContext.Set("Useragent", objObject.ObjClass.Useragent);
                MappedDiagnosticsLogicalContext.Set("Userip", objObject.ObjClass.Userip);
                MappedDiagnosticsLogicalContext.Set("Userid", objObject.ObjClass.Userid);
            }

            //MappedDiagnosticsLogicalContext.Set("Useragent", objObject.ObjClass.Useragent);
            //MappedDiagnosticsLogicalContext.Set("Userip", objObject.ObjClass.Userip);
            //MappedDiagnosticsLogicalContext.Set("Userid", objObject.ObjClass.Userid);
            MappedDiagnosticsLogicalContext.Set("ReferenceNo", StaticClass.APIReferenceNo);
            logger.Info("Controller : " + controllerName + Environment.NewLine + "Action : " + actionName + "JSON Input" + jsonInput.ToString());

        }

        public void OnActionExecuted(ActionExecutedContext context)
            {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var actionName = descriptor.ActionName;
            var controllerName = descriptor.ControllerName;
            var result = context.Result;
            MappedDiagnosticsLogicalContext.Set("methodName", actionName);
            var jsonInput = JsonConvert.SerializeObject(result);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Root objObject = JsonConvert.DeserializeObject<Root>(StcjsonInput, settings);
            MappedDiagnosticsLogicalContext.Set("Useragent", objObject.ObjClass.Useragent);
            MappedDiagnosticsLogicalContext.Set("Userip", objObject.ObjClass.Userip);
            MappedDiagnosticsLogicalContext.Set("Userid", objObject.ObjClass.Userid);
            MappedDiagnosticsLogicalContext.Set("ReferenceNo", StaticClass.APIReferenceNo);
            logger.Info("Controller : " + controllerName + Environment.NewLine + "Action : " + actionName + "JSON OutPut" + jsonInput.ToString());
        }

    }
}
