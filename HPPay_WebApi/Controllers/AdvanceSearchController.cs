using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Linq;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using HPPay.DataModel;
using HPPay.DataModel.AdvanceSearch;
using HPPay.DataRepository;
using HPPay.DataRepository.AdvanceSearch;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/advancesearch")]
    public class AdvanceSearchController : ControllerBase
    {
        private readonly ILogger<AdvanceSearchController> _logger;

        private readonly IAdvanceSearchRepositary _advancesearchRepo;

        public AdvanceSearchController(ILogger<AdvanceSearchController> logger, IAdvanceSearchRepositary searchRepo)
        {
            _logger = logger;
            _advancesearchRepo = searchRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_advance_search_customer_search")]
        public async Task<IActionResult> GetAdvanceSearchCustomerSearch([FromBody] GetAdvanceSearchCustomerSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _advancesearchRepo.GetAdvanceSearchCustomerSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAdvanceSearchCustomerSearchModelOutput> item = result.Cast<GetAdvanceSearchCustomerSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_advance_search_merchant_search")]
        public async Task<IActionResult> GetAdvanceSearchMerchantSearch([FromBody] GetAdvanceSearchMerchantSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _advancesearchRepo.GetAdvanceSearchMerchantSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAdvanceSearchMerchantSearchModelOutput> item = result.Cast<GetAdvanceSearchMerchantSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_advance_search_card_search")]
        public async Task<IActionResult> GetAdvanceSearchCardSearch([FromBody] GetAdvanceSearchCardSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _advancesearchRepo.GetAdvanceSearchCardSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAdvanceSearchCardSearchModelOutput> item = result.Cast<GetAdvanceSearchCardSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_advance_search_terminal_search")]
        public async Task<IActionResult> GetAdvanceSearchTerminalSearch([FromBody] GetAdvanceSearchTerminalSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _advancesearchRepo.GetAdvanceSearchTerminalSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAdvanceSearchTerminalSearchModelOutput> item = result.Cast<GetAdvanceSearchTerminalSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
    }
}
