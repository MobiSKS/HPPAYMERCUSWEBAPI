using HPPay.DataModel.CountryRegion;
using HPPay.DataModel.Hotlist;
using HPPay.DataRepository.CountryRegion;
using HPPay.DataRepository.Hotlist;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HPPay.DataModel.Hotlist.HotlistUpdatePermanentlyHotlistCardsModel;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/hotlist")]
    [ApiController]
    public class HotlistController : ControllerBase
    {
        private readonly ILogger<HotlistController> _logger;

        private readonly IHotlistRepository _HLRepo;
        public HotlistController(ILogger<HotlistController> logger, IHotlistRepository HLRepo)
        {

            _logger = logger;
            _HLRepo = HLRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_action_list")]
        public async Task<IActionResult> GetActionList([FromBody] GetActionListInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetActionList(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetActionListOutput> item = result.Cast<GetActionListOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_entity_type_list")]
        public async Task<IActionResult> GetEntityTypeList([FromBody] GetEntityTypeListInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetEntityTypeList(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetEntityTypeListOutput> item = result.Cast<GetEntityTypeListOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_reason_list_for_entities")]
        public async Task<IActionResult> GetReasonListForEntities([FromBody] GetReasonListForEntitiesInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetReasonListForEntities(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetReasonListForEntitiesOutput> item = result.Cast<GetReasonListForEntitiesOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hotlisted_or_reactivated_details")]
        public async Task<IActionResult> GetHotlistedOrReactivatedDetails([FromBody] GetHotlistedOrReactivatedDetailsInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetHotlistedOrReactivatedDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetHotlistedOrReactivatedDetailsOutput> item = result.Cast<GetHotlistedOrReactivatedDetailsOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_hotlist_or_reactivate")]
        public async Task<IActionResult> UpdateHotlistOrReactivate([FromBody] HotlistUpdateModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.UpdateHotlistOrReactivate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HotlistUpdateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<HotlistUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hotlist_approval")]
        public async Task<IActionResult> GetHotlistApproval([FromBody] GetHotlistApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetHotlistApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetHotlistApprovalModelOutput> item = result.Cast<GetHotlistApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_hotlist_approval")]
        public async Task<IActionResult> UpdateHotlistApproval([FromBody] UpdateHotlistApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.UpdateHotlistApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateHotlistApprovalModelOutput> item = result.Cast<UpdateHotlistApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hotlist_cards_details")]
        public async Task<IActionResult> GetHotlistCardsDetails([FromBody] HotlistGetHotlistCardsDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetHotlistCardsDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<HotlistGetHotlistCardsDetailsModelOutput> item = result.Cast<HotlistGetHotlistCardsDetailsModelOutput>().ToList();
                    //if (item.Count > 0)
                    if (result.Cast<HotlistGetHotlistCardsDetailsModelOutput>().ToList()[0].Status == 1 && result.Count()>0)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }

                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, "");
                    }
                       
                }
            }
        }





        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hotlist_reason")]
        public async Task<IActionResult> GetHotlistReason([FromBody] HotlistGetHotlistReasonModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetHotlistReason(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<HotlistGetHotlistReasonModelOutput> item = result.Cast<HotlistGetHotlistReasonModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_permanently_hotlist_cards")]
        public async Task<IActionResult> UpdatePermanentlyHotlistCards([FromBody] HotlistUpdatePermanentlyHotlistCardsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.UpdatePermanentlyHotlistCards(ObjClass);
                if (result == null)
                {
                    return this.Fail(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HotlistUpdatePermanentlyHotlistCardsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<HotlistUpdatePermanentlyHotlistCardsModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_entity_already_hotlisted")]
        public async Task<IActionResult> CheckEntityAlreadyHotlisted([FromBody] CheckEntityAlreadyHotlistedModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.CheckEntityAlreadyHotlisted(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckEntityAlreadyHotlistedModelOutput> item = result.Cast<CheckEntityAlreadyHotlistedModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hotlist_reissue_cards")]
        public async Task<IActionResult> GetHotlistReissueCards([FromBody] HotlistGetHotlistReissueCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _HLRepo.GetHotlistReissueCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<HotlistGetHotlistReissueCardsModelOutput> item = result.Cast<HotlistGetHotlistReissueCardsModelOutput>().ToList();
                    //if (item.Count > 0)
                    if (result.Cast<HotlistGetHotlistReissueCardsModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }
}
