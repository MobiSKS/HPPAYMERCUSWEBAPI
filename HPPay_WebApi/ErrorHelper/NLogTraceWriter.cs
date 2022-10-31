using Newtonsoft.Json.Serialization;
using NLog;
using System;
using System.Diagnostics;

namespace HPPay_WebApi.ErrorHelper
{
    public class NLogTraceWriter : ITraceWriter
    {
        private static readonly Logger Logger = LogManager.GetLogger("NLogTraceWriter");

        public TraceLevel LevelFilter
        {
            // trace all messages. nlog can handle filtering
            get { return TraceLevel.Verbose; }
        }

        public void Trace(TraceLevel level, string message, Exception ex)
        {
            LogEventInfo logEvent = new LogEventInfo
            {
                Message = message,
                Level = GetLogLevel(level),
                Exception = ex
            };

            // log Json.NET message to NLog
            Logger.Log(logEvent);
        }

        private LogLevel GetLogLevel(TraceLevel level)
        {
            //HttpContext context= new HttpContextAccessor().HttpContext;
            //if (context == null)
            //    return;

            //var context = new HttpContextWrapper(HttpContext.Current);

            //if (context.Request == null)
            //    return;

            //var work = context.Request.RequestContext.GetWorkContext();
            //if (work == null)
            //    return;

            return level switch
            {
                TraceLevel.Error => LogLevel.Error,
                TraceLevel.Warning => LogLevel.Warn,
                TraceLevel.Info => LogLevel.Info,
                TraceLevel.Off => LogLevel.Off,
                _ => LogLevel.Trace,
            };

            //switch (level)
            //{
            //    case TraceLevel.Error:
            //        return LogLevel.Error;
            //    case TraceLevel.Warning:
            //        return LogLevel.Warn;
            //    case TraceLevel.Info:
            //        return LogLevel.Info;
            //    case TraceLevel.Off:
            //        return LogLevel.Off;
            //    default:
            //        return LogLevel.Trace;
            //}
        }
    }
}
