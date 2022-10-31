using Dapper;
using HPPay.DataModel.CustomerAPI;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay_WebApi.ActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        readonly DapperContext _dbContext;
        public ValidateModelAttribute(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var controllerName = descriptor.ControllerName;

            if (!context.ModelState.IsValid)
            {
                if (controllerName == "CustomerAPI")
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResultCustomerAPI(context, _dbContext).Execute()
                     ));
                }
                else if (controllerName == "HLFL")
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResultHLFL(context).Execute()
                     ));
                }
                else if (controllerName == "TMFL")
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResultTMFL(context).Execute()
                     ));
                }
                else if (controllerName == "SFLAPI")
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResultSFL(context).Execute()
                     ));
                }
                else if (controllerName == "STFCAPI")
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResultSTFC(context).Execute()
                     ));
                }
                else if (controllerName == "M2PAPI")
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResultM2P(context).Execute()
                     ));
                }
                else
                {
                    context.Result = new JsonResult
                     (
                     new RouteValueDictionary(new BadRequestFailureResult(context).Execute()
                     ));
                }

                // context.Result = new BadRequestObjectResult(context.ModelState);
            }
            base.OnActionExecuting(context);
        }
        public class BadRequestFailureResult
        {
            readonly ActionExecutingContext _context;

            public BadRequestFailureResult(ActionExecutingContext context)
            {
                _context = context;
            }

            public ApiResponseMessage Execute()
            {
                HttpRequest request = _context.HttpContext.Request;
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                var modelState = _context.ModelState.Values;
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);
                ApiResponseMessage response = new ApiResponseMessage
                {
                    Status_Code = (int)HttpStatusCode.BadRequest,
                    Internel_Status_Code = (int)StatusInformation.Fail,
                    Message = string.Join(" - ", allErrors.Select(e => e.ErrorMessage)),
                    Success = false,
                    Method_Name = actionName,
                    Data = null,
                    Model_State = _context.ModelState,
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                logger.Error(string.Join(" - ", allErrors.Select(e => e.ErrorMessage)));
                return (response);

            }


        }

        public class BadRequestFailureResultCustomerAPI
        {

            readonly DapperContext _dbContext;

            readonly ActionExecutingContext _context;

            public BadRequestFailureResultCustomerAPI(ActionExecutingContext context, DapperContext dbContext)
            {
                _context = context;
                _dbContext = dbContext;
            }

            public CustomerAPIReponseMessage Execute()
            {
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                var controllerName = descriptor.ControllerName;
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);

                object obj = new object();
                CustomerAPIResponseCaptureModel customerAPIResponseCaptureMdl = new CustomerAPIResponseCaptureModel();
                var data = _context.ActionArguments.TryGetValue("ObjClass", out obj);

                CustomerAPIReponseMessage response = new CustomerAPIReponseMessage
                {
                    responseCode = "0",
                    responseMessage = string.Join(" - ", allErrors.Select(e => e.ErrorMessage).FirstOrDefault()),
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

                if (obj is CustomerAPISetCardAddOnLimitModelInput)
                {
                    List<CustomerAPISetCardAddOnLimitModelInput> dataList = new List<CustomerAPISetCardAddOnLimitModelInput>();
                    dataList.Add((CustomerAPISetCardAddOnLimitModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().customerID;
                    customerAPIResponseCaptureMdl.LimitType = dataList.FirstOrDefault().limitType;
                    customerAPIResponseCaptureMdl.LimitValue = dataList.FirstOrDefault().limitValue;
                    customerAPIResponseCaptureMdl.CardNumber = dataList.FirstOrDefault().cardNumber;
                    customerAPIResponseCaptureMdl.Mobile = dataList.FirstOrDefault().mobile;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPISetCardLimitModelInput)
                {
                    List<CustomerAPISetCardLimitModelInput> dataList = new List<CustomerAPISetCardLimitModelInput>();
                    dataList.Add((CustomerAPISetCardLimitModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().customerID;
                    customerAPIResponseCaptureMdl.LimitType = dataList.FirstOrDefault().limitType;
                    customerAPIResponseCaptureMdl.LimitValue = dataList.FirstOrDefault().limitValue;
                    customerAPIResponseCaptureMdl.CardNumber = dataList.FirstOrDefault().cardNumber;
                    customerAPIResponseCaptureMdl.Mobile = dataList.FirstOrDefault().mobile;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPITransactionQueryStatusModelInput)
                {
                    List<CustomerAPITransactionQueryStatusModelInput> dataList = new List<CustomerAPITransactionQueryStatusModelInput>();
                    dataList.Add((CustomerAPITransactionQueryStatusModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().customerID;
                    customerAPIResponseCaptureMdl.CardNumber = dataList.FirstOrDefault().cardNumber;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPIParentChildBalanceTransferModelInput)
                {
                    List<CustomerAPIParentChildBalanceTransferModelInput> dataList = new List<CustomerAPIParentChildBalanceTransferModelInput>();
                    dataList.Add((CustomerAPIParentChildBalanceTransferModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().ParentCustomerID;
                    customerAPIResponseCaptureMdl.TransferAmount = dataList.FirstOrDefault().TransferAmount.ToString();
                    customerAPIResponseCaptureMdl.BalanceTransType = dataList.FirstOrDefault().BalanceTransType.ToString();
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                    customerAPIResponseCaptureMdl.ChildId = dataList.FirstOrDefault().ChildCustomerID;
                }
                else if (obj is CustomerAPISetCardAllLimitModelInput)
                {
                    List<CustomerAPISetCardAllLimitModelInput> dataList = new List<CustomerAPISetCardAllLimitModelInput>();
                    dataList.Add((CustomerAPISetCardAllLimitModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().customerID;
                    customerAPIResponseCaptureMdl.CardNumber = dataList.FirstOrDefault().cardNumber;
                    customerAPIResponseCaptureMdl.SaleTransactionLimit = dataList.FirstOrDefault().saleTransactionLimit;
                    customerAPIResponseCaptureMdl.DailyLimit = dataList.FirstOrDefault().dailyLimit;
                    customerAPIResponseCaptureMdl.MonthlyLimit = dataList.FirstOrDefault().monthlyLimit;
                    customerAPIResponseCaptureMdl.CCMSLimitType = dataList.FirstOrDefault().ccmslimittype;
                    customerAPIResponseCaptureMdl.CCMSLimitValue = dataList.FirstOrDefault().CCMSlimitValue;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPICheckBalanceTransferStatusModelInput)
                {
                    List<CustomerAPICheckBalanceTransferStatusModelInput> dataList = new List<CustomerAPICheckBalanceTransferStatusModelInput>();
                    dataList.Add((CustomerAPICheckBalanceTransferStatusModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().UserName;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPIChildtoParentBalanceTransferRequestModelInput)
                {
                    List<CustomerAPIChildtoParentBalanceTransferRequestModelInput> dataList = new List<CustomerAPIChildtoParentBalanceTransferRequestModelInput>();
                    dataList.Add((CustomerAPIChildtoParentBalanceTransferRequestModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().ParentCustomerID;
                    customerAPIResponseCaptureMdl.TransferAmount = dataList.FirstOrDefault().TransferAmount.ToString();
                    customerAPIResponseCaptureMdl.BalanceTransType = dataList.FirstOrDefault().BalanceTransType.ToString();
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                    customerAPIResponseCaptureMdl.ChildId = dataList.FirstOrDefault().ChildCustomerID;
                }
                else if (obj is CustomerAPILoyaltyRedeemRequestModelInput)
                {
                    List<CustomerAPILoyaltyRedeemRequestModelInput> dataList = new List<CustomerAPILoyaltyRedeemRequestModelInput>();
                    dataList.Add((CustomerAPILoyaltyRedeemRequestModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.DriveStars = dataList.FirstOrDefault().DriveStars.ToString();
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().CustomerID.ToString();
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPICheckLoyaltyRedeemStatusModelInput)
                {
                    List<CustomerAPICheckLoyaltyRedeemStatusModelInput> dataList = new List<CustomerAPICheckLoyaltyRedeemStatusModelInput>();
                    dataList.Add((CustomerAPICheckLoyaltyRedeemStatusModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().UserName;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPIChildtoParentBalanceTransferModelInput)
                {
                    List<CustomerAPIChildtoParentBalanceTransferModelInput> dataList = new List<CustomerAPIChildtoParentBalanceTransferModelInput>();
                    dataList.Add((CustomerAPIChildtoParentBalanceTransferModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.TransferAmount = dataList.FirstOrDefault().TransferAmount.ToString();
                    customerAPIResponseCaptureMdl.BalanceTransType = dataList.FirstOrDefault().BalanceTransType.ToString();
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().ParentCustomerID;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                    customerAPIResponseCaptureMdl.ChildId = dataList.FirstOrDefault().ChildCustomerID;
                }
                else if (obj is CustomerAPIParentChildBalanceTransferV2ModelInput)
                {
                    List<CustomerAPIParentChildBalanceTransferV2ModelInput> dataList = new List<CustomerAPIParentChildBalanceTransferV2ModelInput>();
                    dataList.Add((CustomerAPIParentChildBalanceTransferV2ModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().ParentCustomerID;
                    customerAPIResponseCaptureMdl.TransferAmount = dataList.FirstOrDefault().TransferAmount.ToString();
                    customerAPIResponseCaptureMdl.BalanceTransType = dataList.FirstOrDefault().BalanceTransType.ToString();
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                    customerAPIResponseCaptureMdl.ChildId = dataList.FirstOrDefault().ChildCustomerID;
                }
                else if (obj is CustomerAPIGetTransactionsV2ModelInput)
                {
                    List<CustomerAPIGetTransactionsV2ModelInput> dataList = new List<CustomerAPIGetTransactionsV2ModelInput>();
                    dataList.Add((CustomerAPIGetTransactionsV2ModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CustomerId = dataList.FirstOrDefault().customerID;
                    customerAPIResponseCaptureMdl.ChildId = dataList.FirstOrDefault().childID;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPITransactionQueryStatusWithDetailsModelInput)
                {
                    List<CustomerAPITransactionQueryStatusWithDetailsModelInput> dataList = new List<CustomerAPITransactionQueryStatusWithDetailsModelInput>();
                    dataList.Add((CustomerAPITransactionQueryStatusWithDetailsModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.CardNumber = dataList.FirstOrDefault().cardNumber;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPIGenerateOTPModelInput)
                {
                    List<CustomerAPIGenerateOTPModelInput> dataList = new List<CustomerAPIGenerateOTPModelInput>();
                    dataList.Add((CustomerAPIGenerateOTPModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.Mobile = dataList.FirstOrDefault().MobileNumber;
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPIParentChildBalanceTransferModelInput)
                {
                    List<CustomerAPIParentChildBalanceTransferModelInput> dataList = new List<CustomerAPIParentChildBalanceTransferModelInput>();
                    dataList.Add((CustomerAPIParentChildBalanceTransferModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.ParentCustomerId = dataList.FirstOrDefault().ParentCustomerID;
                    customerAPIResponseCaptureMdl.ChildCustomerId = dataList.FirstOrDefault().ChildCustomerID;
                    customerAPIResponseCaptureMdl.BalanceTransType = dataList.FirstOrDefault().BalanceTransType.ToString();
                    customerAPIResponseCaptureMdl.TransferAmount = dataList.FirstOrDefault().TransferAmount.ToString();
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }
                else if (obj is CustomerAPIChildtoParentBalanceTransferRequestModelInput)
                {
                    List<CustomerAPIChildtoParentBalanceTransferRequestModelInput> dataList = new List<CustomerAPIChildtoParentBalanceTransferRequestModelInput>();
                    dataList.Add((CustomerAPIChildtoParentBalanceTransferRequestModelInput)obj);
                    customerAPIResponseCaptureMdl.Username = dataList.FirstOrDefault().Username;
                    customerAPIResponseCaptureMdl.Password = dataList.FirstOrDefault().Password;
                    customerAPIResponseCaptureMdl.TransactionId = dataList.FirstOrDefault().TransactionId;
                    customerAPIResponseCaptureMdl.ParentCustomerId = dataList.FirstOrDefault().ParentCustomerID;
                    customerAPIResponseCaptureMdl.ChildCustomerId = dataList.FirstOrDefault().ChildCustomerID;
                    customerAPIResponseCaptureMdl.BalanceTransType = dataList.FirstOrDefault().BalanceTransType.ToString();
                    customerAPIResponseCaptureMdl.TransferAmount = dataList.FirstOrDefault().TransferAmount.ToString();
                    customerAPIResponseCaptureMdl.ControllerName = controllerName;
                    customerAPIResponseCaptureMdl.ActionName = actionName;
                }

                IEnumerable<CustomerAPIValidateCredentialsModelOutput> Validation = new List<CustomerAPIValidateCredentialsModelOutput>();

                var procedureName = "UspCustomerAPICaptureReponseLog";
                var parameters = new DynamicParameters();
                parameters.Add("Username", customerAPIResponseCaptureMdl.Username, DbType.String, ParameterDirection.Input);
                parameters.Add("Password", customerAPIResponseCaptureMdl.Password, DbType.String, ParameterDirection.Input);
                parameters.Add("TransactionId", customerAPIResponseCaptureMdl.TransactionId, DbType.String, ParameterDirection.Input);
                parameters.Add("CustomerId", customerAPIResponseCaptureMdl.CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("LimitType", customerAPIResponseCaptureMdl.LimitType, DbType.String, ParameterDirection.Input);
                parameters.Add("LimitValue", customerAPIResponseCaptureMdl.LimitValue, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNumber", customerAPIResponseCaptureMdl.CardNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Mobile", customerAPIResponseCaptureMdl.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("SaleTransactionLimit", customerAPIResponseCaptureMdl.SaleTransactionLimit, DbType.String, ParameterDirection.Input);
                parameters.Add("DailyLimit", customerAPIResponseCaptureMdl.DailyLimit, DbType.String, ParameterDirection.Input);
                parameters.Add("MonthlyLimit", customerAPIResponseCaptureMdl.MonthlyLimit, DbType.String, ParameterDirection.Input);
                parameters.Add("CCMSLimitType", customerAPIResponseCaptureMdl.CCMSLimitType, DbType.String, ParameterDirection.Input);
                parameters.Add("CCMSLimitValue", customerAPIResponseCaptureMdl.CCMSLimitValue, DbType.String, ParameterDirection.Input);
                parameters.Add("ChildId", customerAPIResponseCaptureMdl.ChildId, DbType.String, ParameterDirection.Input);
                parameters.Add("BalanceTransType", customerAPIResponseCaptureMdl.BalanceTransType, DbType.String, ParameterDirection.Input);
                parameters.Add("TransferAmount", customerAPIResponseCaptureMdl.TransferAmount, DbType.String, ParameterDirection.Input);
                parameters.Add("DriveStars", customerAPIResponseCaptureMdl.DriveStars, DbType.String, ParameterDirection.Input);
                parameters.Add("ParentCustomerId", customerAPIResponseCaptureMdl.ParentCustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ChildCustomerId", customerAPIResponseCaptureMdl.ChildCustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ResponseCode", response.responseCode, DbType.String, ParameterDirection.Input);
                parameters.Add("ResponseMessage", response.responseMessage, DbType.String, ParameterDirection.Input);
                parameters.Add("ControllerName", controllerName, DbType.String, ParameterDirection.Input);
                parameters.Add("ActionName", actionName.Replace("CustomerAPI", ""), DbType.String, ParameterDirection.Input);
                using var connection = _dbContext.CreateConnection();
                Validation = connection.Query<CustomerAPIValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                logger.Error(string.Join(" - ", "CustomerAPI Action: "+ actionName + ", Mandatory Field is missing:"));
                return (response);
            }
        }

        public class BadRequestFailureResultHLFL
        {
            readonly ActionExecutingContext _context;

            public BadRequestFailureResultHLFL(ActionExecutingContext context)
            {
                _context = context;
            }

            public HLFLReponseMessage Execute()
            {
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                //var missingFieldName = _context.ModelState.Keys.SingleOrDefault();
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);
                HLFLReponseMessage response = new HLFLReponseMessage
                {
                    Status = "1",
                    //responseMessage = "Mandatory Field is missing: " + missingFieldName,
                    ResponseMessage = string.Join(" - ", allErrors.Select(e => e.ErrorMessage).FirstOrDefault()),
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                logger.Error(string.Join(" - ", "HLFL Action: " + actionName + ", Mandatory Field is missing:"));
                return (response);
            }


        }

        public class BadRequestFailureResultTMFL
        {
            readonly ActionExecutingContext _context;

            public BadRequestFailureResultTMFL(ActionExecutingContext context)
            {
                _context = context;
            }

            public TMFLReponseMessage Execute()
            {
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                //var missingFieldName = _context.ModelState.Keys.SingleOrDefault();
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);
                TMFLReponseMessage response = new TMFLReponseMessage
                {
                    Status = "1",
                    //responseMessage = "Mandatory Field is missing: " + missingFieldName,
                    ResponseMessage = string.Join(" - ", allErrors.Select(e => e.ErrorMessage).FirstOrDefault()),
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                logger.Error(string.Join(" - ", "TMFL Action: " + actionName + ", Mandatory Field is missing:"));
                return (response);
            }


        }

        public class BadRequestFailureResultSFL
        {
            readonly ActionExecutingContext _context;

            public BadRequestFailureResultSFL(ActionExecutingContext context)
            {
                _context = context;
            }

            public SFLResponseMessage Execute()
            {
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                //var missingFieldName = _context.ModelState.Keys.SingleOrDefault();
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);
                SFLResponseMessage response = new SFLResponseMessage
                {
                    responseCode = "1",
                    //responseMessage = "Mandatory Field is missing: " + missingFieldName,
                    responseMessage = string.Join(" - ", allErrors.Select(e => e.ErrorMessage)),
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                logger.Error(string.Join(" - ", "SFL Action: " + actionName + ", Mandatory Field is missing:"));
                return (response);
            }


        }

        public class BadRequestFailureResultSTFC
        {
            readonly ActionExecutingContext _context;

            public BadRequestFailureResultSTFC(ActionExecutingContext context)
            {
                _context = context;
            }

            public STFCResponseMessage Execute()
            {
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                //var missingFieldName = _context.ModelState.Keys.SingleOrDefault();
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);
                STFCResponseMessage response = new STFCResponseMessage
                {
                    responseCode = "1",
                    //responseMessage = "Mandatory Field is missing: " + missingFieldName,
                    responseMessage = string.Join(" - ", allErrors.Select(e => e.ErrorMessage).FirstOrDefault()),
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                logger.Error(string.Join(" - ", "STFC Action: " + actionName + ", Mandatory Field is missing:"));
                return (response);
            }


        }

        public class BadRequestFailureResultM2P
        {
            readonly ActionExecutingContext _context;

            public BadRequestFailureResultM2P(ActionExecutingContext context)
            {
                _context = context;
            }

            public M2PResponseMessage Execute()
            {
                var descriptor = _context.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                //var missingFieldName = _context.ModelState.Keys.SingleOrDefault();
                var allErrors = _context.ModelState.Values.SelectMany(v => v.Errors);
                M2PResponseMessage response = new M2PResponseMessage
                {
                    responseCode = "1",
                    //responseMessage = "Mandatory Field is missing: " + missingFieldName,
                    responseMessage = string.Join(" - ", allErrors.Select(e => e.ErrorMessage).FirstOrDefault()),
                };

                var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                logger.Error(string.Join(" - ", "M2P Action: " + actionName + ", Mandatory Field is missing:"));
                return (response);
            }


        }

    }
}
