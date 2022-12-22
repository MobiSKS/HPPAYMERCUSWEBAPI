using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using HPPay.DataRepository.AccountStatment;
using HPPay.DataModel.AccountStatment;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/AccountStatement")]
    public class AccountStatementController : ControllerBase
    {
        private readonly ILogger<AccountStatementController> _logger;
        private readonly IAccountStatmentRepository _accountStatement;
        private readonly IConfiguration _configuration;

        public AccountStatementController(ILogger<AccountStatementController> logger, IAccountStatmentRepository accountStatement, IConfiguration configuration)
        {
            _logger = logger;
            _accountStatement = accountStatement;
            _configuration = configuration;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_account_statment_request")]
        public async Task<IActionResult> InsertParentCustomer([FromBody] InsertAccountStatmentRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _accountStatement.InsertAccountStatmentRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertAccountStatmentRequestModelOutPut>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertAccountStatmentRequestModelOutPut>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_account_statment_request_details")]
        public async Task<IActionResult> GetAccountStatmentRequestDetails([FromBody] GetAccountStatmentRequestDetailsInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _accountStatement.GetAccountStatmentRequestDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAccountStatmentRequest.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("action_get_account_statment_request_type")]
        public async Task<IActionResult> GetAccountStatmentType([FromBody] GetAccountStatmentTypeInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _accountStatement.GetAccountStatmentType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetAccountStatmentTypeOutPut>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetAccountStatmentTypeOutPut>().ToList()[0].Reason);
                    }
                }
            }
        } 

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_account_statment_request_status")]
        public async Task<IActionResult> UpdateAccountStatmentRequest([FromBody] UpdateAccountStatmentRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _accountStatement.UpdateAccountStatmentRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateAccountStatmentRequestModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateAccountStatmentRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("download_account_statment")]
        public async Task<IActionResult> DownloadAccountStatment([FromBody] DownloadAccountStatmentInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _accountStatement.DownloadAccountStatment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<DownloadAccountStatmentOutput> item = result.Cast<DownloadAccountStatmentOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }

}
