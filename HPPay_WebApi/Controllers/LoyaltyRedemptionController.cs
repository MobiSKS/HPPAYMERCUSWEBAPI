using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using HPPay.DataModel.LoyaltyRedemption;
using System.Linq;
using HPPay.DataRepository.LoyaltyRedemption;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using HPPay.DataModel;
using System;


namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/loyaltyredemption")]

    public class LoyaltyRedemptionController  : ControllerBase
    {
        private readonly ILogger<LoyaltyRedemptionController> _logger;
       
        private readonly ILoyaltyRedemptionRepository _loyaltyredemptionRepo;
       
     
        public LoyaltyRedemptionController(ILogger<LoyaltyRedemptionController> logger, ILoyaltyRedemptionRepository loyaltyredemptionRepo)
        {
            _logger = logger;
            _loyaltyredemptionRepo = loyaltyredemptionRepo;
            
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_loyalty_redemption")]
        public async Task<IActionResult> GetLoyaltyRedemption([FromBody] GetLoyaltyRedemptionModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetLoyaltyRedemption(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetLoyaltyRedemptionModelOutput> item = result.Cast<GetLoyaltyRedemptionModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_update_loyalty_redemption")]
        public async Task<IActionResult> GetUpdateLoyaltyRedemption([FromBody] GetUpdateLoyaltyRedemptionModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetUpdateLoyaltyRedemption(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetUpdateLoyaltyRedemptionModelOutput> item = result.Cast<GetUpdateLoyaltyRedemptionModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_loyalty_redemption")]
        public async Task<IActionResult> InsertLoyaltyRedemption([FromBody] InsertLoyaltyRedemptionModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.InsertLoyaltyRedemption(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //if (result.Cast<InsertLoyaltyRedemptionModelOutput>().ToList()[0].Status == 1)
                    List<InsertLoyaltyRedemptionModelOutput> item = result.Cast<InsertLoyaltyRedemptionModelOutput>().ToList();
                    if (item.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_transaction_source_id")]
        public async Task<IActionResult> GetTransactionSourceID([FromBody] GetTransactionSourceIDModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetTransactionSourceID(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<GetTransactionSourceIDModelOutput> item = result.Cast<GetTransactionSourceIDModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_authorization_level_id")]
        public async Task<IActionResult> GetAuthorizationLevelID([FromBody] GetAuthorizationLevelIDModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetAuthorizationLevelID(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<GetAuthorizationLevelIDModelOutput> item = result.Cast<GetAuthorizationLevelIDModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_redemption_request_rule")]
        public async Task<IActionResult> GetRedemptionRequestRule([FromBody] GetRedemptionRequestRuleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetRedemptionRequestRule(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetRedemptionRequestRuleModelOutput> item = result.Cast<GetRedemptionRequestRuleModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_redemption_request_rule")]
        public async Task<IActionResult> InsertRedemptionRequestRule([FromBody] InsertRedemptionRequestRuleModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.InsertRedemptionRequestRule(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertRedemptionRequestRuleModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<InsertRedemptionRequestRuleModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_redemption_request_rule")]
        public async Task<IActionResult> UpdateRedemptionRequestRule([FromBody] UpdateRedemptionRequestRuleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.UpdateRedemptionRequestRule(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateRedemptionRequestRuleModelOutput> item = result.Cast<UpdateRedemptionRequestRuleModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_redemption_request_rule")]
        public async Task<IActionResult> DeleteRedemptionRequestRule([FromBody] DeleteRedemptionRequestRuleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.DeleteRedemptionRequestRule(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<DeleteRedemptionRequestRuleModelOutput> item = result.Cast<DeleteRedemptionRequestRuleModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
      [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approval_authorize_fuel_loyalty_redemption")]
        public async Task<IActionResult> ApprovalAuthorizeFuelLoyaltyRedemption([FromBody] ApprovalAuthorizeFuelLoyaltyRedemptionModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.ApprovalAuthorizeFuelLoyaltyRedemption(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //if (result.Cast<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput>().ToList()[0].Status == 1)
                    //{
                    //    return this.OkCustom(ObjClass, result, _logger);
                    //}
                    //else
                    //{
                    //    return this.FailCustom(ObjClass, result, _logger, result.Cast<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput>().ToList()[0].Reason);
                    //}

                    List<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput> item = result.Cast<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput>().ToList();
                    if (item.Count > 0)
                            

                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_authorize_fuel_loyalty_redemption_Detail")]
        public async Task<IActionResult> GetAuthorizeFuelLoyaltyRedemptionDetail([FromBody] GetAuthorizeFuelLoyaltyRedemptionDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetAuthorizeFuelLoyaltyRedemptionDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAuthorizeFuelLoyaltyRedemptionDetailModelOutput> item = result.Cast<GetAuthorizeFuelLoyaltyRedemptionDetailModelOutput>().ToList();
                    if (item.Count > 0)

                    
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fuel_loyalty_redemption_authorize")]
        public async Task<IActionResult> FuelLoyaltyRedemptionAuthorize([FromBody] FuelLoyaltyRedemptionAuthorizeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.FuelLoyaltyRedemptionAuthorize(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //if (result.Cast<FuelLoyaltyRedemptionAuthorizeModelOutput>().ToList()[0].Status == 1)
                    //{
                    //    return this.OkCustom(ObjClass, result, _logger);
                    //}
                    //else
                    //{
                    //    return this.FailCustom(ObjClass, result, _logger, result.Cast<FuelLoyaltyRedemptionAuthorizeModelOutput>().ToList()[0].Reason);
                    //}

                    List<FuelLoyaltyRedemptionAuthorizeModelOutput> item = result.Cast<FuelLoyaltyRedemptionAuthorizeModelOutput>().ToList();
                    if (item.Count > 0)


                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                    }


                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_Approve_fuel_loyalty_redemption_Detail")]
        public async Task<IActionResult> GetApproveFuelLoyaltyRedemptionDetail([FromBody] GetApprovedFuelLoyaltyRedemptionDetailModelnput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _loyaltyredemptionRepo.GetApproveFuelLoyaltyRedemptionDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetApprovedFuelLoyaltyRedemptionDetailModelOutput> item = result.Cast<GetApprovedFuelLoyaltyRedemptionDetailModelOutput>().ToList();
                    if (item.Count > 0)


                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

    }
}
