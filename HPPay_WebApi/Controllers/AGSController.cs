using HPPay.DataModel.AGS;
using HPPay.DataRepository.AGS;
using HPPay.DataRepository.DBDapper;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{


    [ApiController]
    [Route("Automation")]

    public class AGSController : ControllerBase
    {
        private readonly ILogger<AGSController> _logger;
        private readonly IAGSRepository _AGS;
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;

        public AGSController(ILogger<AGSController> logger, IAGSRepository AGS, IConfiguration configuration, DapperContext context)
        {
            _logger = logger;
            _AGS = AGS;
            _configuration = configuration;
            _context = context;

        }

        //CustomAuthenticationFilter
        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Login")]
        public async Task<IActionResult> AGSAPIsValidateCredentials([FromBody] AGSAPIValidateCredentialsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
              //  return this.AGSBadRequestCustom(ObjClass, null, _logger);
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.AGSAPIsValidateCredentials(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AGSAPIValidateCredentialsModelOutput> item = result.Cast<AGSAPIValidateCredentialsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }




        [HttpPost]
      [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Initialization")]
        public async Task<IActionResult> Initialization([FromBody] InitializationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.Initialization(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<InitializationModelOutput> item = result.Cast<InitializationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        //[ServiceFilter(typeof(AGSAuthenticationFilter))]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("CustomerDetails")]
        public async Task<IActionResult> GetCustomerByMobileNo([FromBody] GetCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.GetCustomerByMobileNo(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                if (result.CustomerInfo.Count > 0)
                    return this.AGSOkCustom(ObjClass, result, _logger);
                else
                    return this.AGSFail(ObjClass, result, _logger);
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetPEK")]
        public async Task<IActionResult> GetPEK([FromBody] GetPEKModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.GetPEK(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetPEKModelOutput> item = result.Cast<GetPEKModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("ValidateVehicleNumber")]
        public async Task<IActionResult> ValidateVehicleNumber([FromBody] ValidateVehicleNumberModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.ValidateVehicleNumber(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateVehicleNumberModelOutput> item = result.Cast<ValidateVehicleNumberModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] AuthorizationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.Authorization(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AuthorizationModelOutput> item = result.Cast<AuthorizationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Acknowledge")]
        public async Task<IActionResult> Acknowledge([FromBody] AcknowledgeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.Acknowledge(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AcknowledgeModelOutput> item = result.Cast<AcknowledgeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("BatchSettlement")]
        public async Task<IActionResult> BatchSettlement([FromBody] BatchSettlementModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.BatchSettlement(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BatchSettlementModelOutput> item = result.Cast<BatchSettlementModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("TransactionReversal")]
        public async Task<IActionResult> TransactionReversal([FromBody] TransactionReversalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.TransactionReversal(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<TransactionReversalModelOutput> item = result.Cast<TransactionReversalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("PayCodeTransactionReversal")]
        public async Task<IActionResult> PayCodeTransactionReversal([FromBody] PayCodeTransactionReversalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.PayCodeTransactionReversal(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<PayCodeTransactionReversalModelOutput> item = result.Cast<PayCodeTransactionReversalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("AuthorizePayCodeTxn")]
        public async Task<IActionResult> AuthorizePayCodeTxn([FromBody] AuthorizePayCodeTxnModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.AuthorizePayCodeTxn(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AuthorizePayCodeTxnModelOutput> item = result.Cast<AuthorizePayCodeTxnModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("BatchUploadModel")]
        public async Task<IActionResult> BatchUpload([FromBody] BatchUploadModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.AGSBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _AGS.BatchUpload(ObjClass);
                if (result == null)
                {
                    return this.AGSNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BatchUploadModelOutput> item = result.Cast<BatchUploadModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.AGSOkCustom(ObjClass, result, _logger);
                    else
                        return this.AGSFail(ObjClass, result, _logger);
                }
            }
        }



    }
}

