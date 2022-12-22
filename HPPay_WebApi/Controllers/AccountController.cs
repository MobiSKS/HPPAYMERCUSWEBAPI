using HPPay.DataRepository.Account;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;
using System;
using System.Threading.Tasks;
using static HPPay.Infrastructure.CommonClass.StatusMessage;
using HPPay.Infrastructure.TokenManager;
using Microsoft.Extensions.Configuration;
using HPPay_WebApi.ActionFilters;
using HPPay.Infrastructure.Extension;
using HPPay.DataModel.Account;
using HPPay_WebApi.ExtensionMethod;

namespace HPPay_WebApi.Controllers
{

    [Route("api/hppay")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Variables ObjVariable;
        private readonly IAccountRepository _accountRepo;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountRepository accountRepo, ILogger<AccountController> logger, IConfiguration configuration)
        {
            _accountRepo = accountRepo;
            _logger = logger;
            ObjVariable = new Variables(configuration);
        }

        private  bool Return_Key(IAccountRepository accountRepo,
          out string UserMessage, int Header_Parameter_Value, out int Status_Code, string Useragent, string Userip, string Userid)
        {
            if (accountRepo is null)
            {
                throw new ArgumentNullException(nameof(accountRepo));
            }

            var request = Request;
            //var headers = request.Headers;
            bool IsResult = false;
            string Secret_Key = string.Empty;
            string StrMessage = string.Empty;
            int IntStatusCode = 0;
            try
            {
                string API_Key;
                if (Header_Parameter_Value == 0)
                {
                    API_Key = request.GetHeader("API_Key");
                    Secret_Key = request.GetHeader("Secret_Key");

                    if (API_Key == "" && Secret_Key != "")
                    {
                        StrMessage = StatusInformation.API_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.API_Key_Is_Null;
                        IsResult = false;
                    }
                    else if (API_Key != "" && Secret_Key == "")
                    {
                        StrMessage = StatusInformation.Secret_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.Secret_Key_Is_Null;
                        IsResult = false;
                    }

                    else if (API_Key == "" && Secret_Key == "")
                    {
                        StrMessage = StatusInformation.API_Key_Secret_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.API_Key_Secret_Key_Is_Null;
                        IsResult = false;
                    }
                    else
                    {
                        bool IsAPI_Key_Validate = ObjVariable.Chk_API_Key_SecretKey_Validation(API_Key, Secret_Key);
                        if (IsAPI_Key_Validate == true)
                        {
                            IsResult = true;
                            StrMessage = StatusInformation.Success.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Success;
                        }

                        else
                        {
                            IsResult = false;
                            StrMessage = StatusInformation.API_Key_Is_Secret_Key_Invalid.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.API_Key_Is_Secret_Key_Invalid;
                        }
                    }


                }

                if (Header_Parameter_Value == 1)
                {
                    API_Key = request.GetHeader("API_Key");

                    if (API_Key == "")
                    {
                        StrMessage = StatusInformation.API_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.API_Key_Is_Null;
                        IsResult = false;
                    }
                    else
                    {
                        bool IsAPI_Key_Validate = ObjVariable.Chk_APIKey_Validation(API_Key);
                        if (IsAPI_Key_Validate == true)
                        {
                            IsResult = true;
                            StrMessage = StatusInformation.Success.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Success;
                        }
                        else
                        {
                            IsResult = false;
                            StrMessage = StatusInformation.API_Key_Is_Invalid.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.API_Key_Is_Invalid;
                        }

                    }


                }

                if (Header_Parameter_Value == 2)
                {

                    API_Key = request.GetHeader("Secret_Key");
                    if (Secret_Key == "")
                    {
                        StrMessage = StatusInformation.Secret_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.Secret_Key_Is_Null;
                        IsResult = false;
                    }
                    else
                    {
                        bool IsSecret_Key_Validate = ObjVariable.Chk_SecretKey_Validation(Secret_Key);
                        if (IsSecret_Key_Validate == true)
                        {
                            StrMessage = StatusInformation.Success.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Success;
                            IsResult = true;
                        }
                        else
                        {
                            StrMessage = StatusInformation.Secret_Key_Is_Invalid.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Secret_Key_Is_Invalid;
                            IsResult = false;
                        }

                    }
                }
            }
            catch
            {
                StrMessage = StatusInformation.Internel_Error.GetDisplayName();
                IntStatusCode = (int)StatusInformation.Internel_Error;
                IsResult = false;
            }


            if (IsResult == true)
            {
                if (Useragent == null)
                    Useragent = "";

                if (Userip == null)
                    Userip = "";

                if (Userid == null)
                    Userid = "";

                if (Userid == "")
                    Userid = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (Useragent != "" && Userip != "" && Userid != "")
                {
                    //AccountModel objAccountModel = new AccountModel
                    //{
                    //    MethodName = Method_Name,
                    //    Useragent = Useragent,
                    //    Userid = Userid,
                    //    Userip = Userip
                    //};
                    IsResult = true;
                }
                else
                {
                    IsResult = false;
                    StrMessage = StatusInformation.User_Agentor_User_IP_User_Id_is_null.GetDisplayName();
                    IntStatusCode = (int)StatusInformation.User_Agentor_User_IP_User_Id_is_null;
                }
            }

            UserMessage = StrMessage;
            Status_Code = IntStatusCode;
            return IsResult;
        }


        [HttpPost]
        [Route("generate_token")]
        public IActionResult GenerateToken(GenerateTokenInput ObjClass)
        {
            //ReturnGenerateTokenStatusOutput TokenObject = new ReturnGenerateTokenStatusOutput();
            //string MethodName = "GENERATE_TOKEN";
            try
            {
                StatusInformation.API_Key_Is_Null.GetDisplayName();
                var request = Request;
                var headers = request.Headers;
                string API_Key = string.Empty;
                string Secret_Key = string.Empty;
                byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70 };
                string SecretKey = Convert.ToBase64String(bytes);
                bool IsResult = this.Return_Key( _accountRepo, out string UserMessage, 0, out int IntStatusCode, ObjClass.Useragent, ObjClass.Userip, ObjClass.Userid);
                if (IsResult == true)
                {
                    TokenManager.Secret = SecretKey;
                    return this.OkToken(_logger, ObjClass, ObjClass);

                }
                else
                {
                    TokenManager.Secret = SecretKey;
                    return this.BadRequestToken(_logger, ObjClass);
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
    }
}
