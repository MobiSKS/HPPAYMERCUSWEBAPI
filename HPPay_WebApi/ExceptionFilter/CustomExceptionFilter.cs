using HPPay.DataModel;
using HPPay.Infrastructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay_WebApi.ExceptionFilter
{
    public class BaseClassOutputError
    {
        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonProperty("Reason")]
        [DataMember]
        public string Reason { get; set; }

    }
    public class CustomExceptionFilter : IExceptionFilter
    {


        public void OnException(ExceptionContext context)
        {


            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : getErrorCode(context.Exception.GetType());
            string errorMessage = context.Exception.Message;
            string customErrorMessage = "Custom Error";
            string stackTrace = context.Exception.StackTrace;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = 200;// (int)statusCode;
            response.ContentType = "application/json";
            //var result = JsonConvert.SerializeObject(
            //    new
            //    {
            //        Message = customErrorMessage,
            //        Method_Name = string.Empty,
            //        Status_Code = statusCode,
            //        Internel_Status_Code = statusCode,
            //        Success = false,
            //        Token = string.Empty,
            //        Model_State = string.Empty
            //        //message = customErrorMessage,
            //        //isError = true,
            //        //errorMessage = errorMessage,
            //        //errorCode = statusCode,
            //        //model = string.Empty
            //    });

            List<BaseClassOutputError> ObjError = new List<BaseClassOutputError>();
            ObjError.Add(new BaseClassOutputError()
            {
                Status = 0,
                Reason = errorMessage
            });

            string result = JsonConvert.SerializeObject(
               new ApiErrorResponseMessage
               {
                   Message = errorMessage,
                   Success = false,
                   Status_Code = 200,
                   Internel_Status_Code = (int)StatusInformation.Fail,
                   Data = ObjError,
                   Error_Code = (int)statusCode,
                   Error_Message = customErrorMessage,
                   Method_Name = context.RouteData.Values["action"].ToString()
               });


            #region Logging  
            //if (ConfigurationHelper.GetConfig()[ConfigurationHelper.environment].ToLower() != "dev")  
            //{  
            //    LogMessage objLogMessage = new LogMessage()  
            //    {  
            //        ApplicationName = ConfigurationHelper.GetConfig()["ApplicationName"].ToString(),  
            //        ComponentType = (int) ComponentType.Server,  
            //        ErrorMessage = errorMessage,  
            //        LogType = (int) LogType.EventViewer,  
            //        ErrorStackTrace = stackTrace,  
            //        UserName = Common.GetAccNameDev(context.HttpContext)  
            //    };  
            //    LogError(objLogMessage, LogEntryType.Error);  
            //}  
            #endregion Logging  

            response.ContentLength = result.Length;
            response.WriteAsync(result);



        }


        private HttpStatusCode getErrorCode(Type exceptionType)
        {
            ExceptionsEnum tryParseResult;
            if (Enum.TryParse<ExceptionsEnum>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case ExceptionsEnum.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case ExceptionsEnum.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case ExceptionsEnum.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionsEnum.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case ExceptionsEnum.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case ExceptionsEnum.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case ExceptionsEnum.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case ExceptionsEnum.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case ExceptionsEnum.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case ExceptionsEnum.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case ExceptionsEnum.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case ExceptionsEnum.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case ExceptionsEnum.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionsEnum.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case ExceptionsEnum.IOException:
                        return HttpStatusCode.NotFound;

                    case ExceptionsEnum.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
