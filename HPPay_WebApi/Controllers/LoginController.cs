using HPPay.DataModel.Login;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.Login;
using HPPay.Infrastructure.CommonClass;
using HPPay.Infrastructure.Extension;
using HPPay.Infrastructure.TokenManager;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private readonly ILoginRepository _loginRepo;
        private readonly Variables ObjVariable;
        public LoginController(ILogger<LoginController> logger, ILoginRepository loginRepo, IConfiguration configuration)
        {
            _logger = logger;
            _loginRepo = loginRepo;
            ObjVariable = new Variables(configuration);
        }

        private bool Return_Key(ILoginRepository loginRepo,
          out string UserMessage, int Header_Parameter_Value, out int Status_Code, string Useragent, string Userip, string Userid)
        {
            if (loginRepo is null)
            {
                throw new ArgumentNullException(nameof(loginRepo));
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



                if (Useragent != "" && Userip != "" && Userid != "")
                {
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
        [Route("get_login")]
        public async Task<IActionResult> GetLogin([FromBody] GetLoginModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loginRepo.GetLogin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    bool IsResult = this.Return_Key(_loginRepo, out string UserMessage, 0, out int IntStatusCode,
                        ObjClass.Useragent, ObjClass.Userip, ObjClass.Userid);
                    if (IsResult)
                    {
                        if (result.Cast<GetLoginModelOutput>().ToList()[0].Status == 1)
                        {
                            InsertUpdateManageUsersTokenModelInput insertUpdateManageUsersTokenModelInput = new InsertUpdateManageUsersTokenModelInput();
                            insertUpdateManageUsersTokenModelInput.Userid = ObjClass.Userid;
                            insertUpdateManageUsersTokenModelInput.Token = result.FirstOrDefault().Token;
                            insertUpdateManageUsersTokenModelInput.Useragent = ObjClass.Useragent;
                            insertUpdateManageUsersTokenModelInput.Userip = ObjClass.Userip;

                            var result2 = await _loginRepo.InsertUpdateManageUsersToken(insertUpdateManageUsersTokenModelInput);
                            if (result2.FirstOrDefault().Status == 1)
                            {
                                return this.OkCustom(ObjClass, result, _logger);
                            }
                            else
                            {
                                return this.FailCustom(ObjClass, result, _logger,
                                result.Cast<GetLoginModelOutput>().ToList()[0].Reason);
                            }
                        }
                        else
                        {
                            return this.FailCustom(ObjClass, result, _logger,
                                result.Cast<GetLoginModelOutput>().ToList()[0].Reason);
                        }
                    }
                    else
                    {
                        result.Cast<GetLoginModelOutput>().ToList()[0].Reason = UserMessage;
                        return this.FailCustomGT(ObjClass, null, _logger,
                                   result.Cast<GetLoginModelOutput>().ToList()[0].Reason, IntStatusCode);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_menu_details_for_user")]
        public async Task<IActionResult> GetMenuDetailsForUser([FromBody] GetMenuDetailsForUserModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loginRepo.GetMenuDetailsForUser(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetMenuDetailsForUserModelOutput>().ToList().Count > 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetMenuDetailsForUserModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("get_mobile_login")]
        //public async Task<IActionResult> GetMobileUserLogin([FromBody] GetMobileUserLoginInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _loginRepo.GetMobileUserLogin(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            if (result.Cast<GetMobileUserLoginOutput>().ToList()[0].Status == 1)
        //            {
        //                return this.OkCustom(ObjClass, result, _logger);
        //            }
        //            else
        //            {
        //                return this.FailCustom(ObjClass, result, _logger,
        //                    result.Cast<GetMobileUserLoginOutput>().ToList()[0].Reason);
        //            }
        //        }
        //    }
        //}

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_mobile_menu_details_for_user")]
        public async Task<IActionResult> GetMobileMenuDetailsForUser([FromBody] GetMobileMenuDetailsForUserModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loginRepo.GetMobileMenuDetailsForUser(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetMobileMenuDetailsForUserModelOutput>().ToList().Count > 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetMobileMenuDetailsForUserModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("insert_update_manage_users_token")]
        //public async Task<IActionResult> InsertUpdateManageUsersToken([FromBody] InsertUpdateManageUsersTokenModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _loginRepo.InsertUpdateManageUsersToken(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            if (result.ManageUsersTokenModelBaseOutput.Status == 1)
        //            {
        //                return this.OkCustom(ObjClass, result, _logger);
        //            }
        //            else
        //            {
        //                return this.FailCustom(ObjClass, result, _logger,
        //                    result.ManageUsersTokenModelBaseOutput.Reason);
        //            }
        //        }
        //    }
        //}

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_manage_users_token")]
        public async Task<IActionResult> CheckManageUsersToken([FromBody] CheckManageUsersTokenModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loginRepo.CheckManageUsersToken(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.MenuDetails.Count() > 0)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.CheckManageUsersTokenModelBaseOutput.Reason);
                    }
                }
            }
        }
    }
}
