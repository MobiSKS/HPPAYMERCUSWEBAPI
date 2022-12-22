using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Linq;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using HPPay.DataModel;
using HPPay.DataModel.MODashboard;
using HPPay.DataRepository;


namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/modashboard")]
    public class MODashboardController : ControllerBase
    {
        private readonly ILogger<MODashboardController> _logger;

        private readonly IMODashboardRepository _modashboardRepo;

        public MODashboardController(ILogger<MODashboardController> logger, IMODashboardRepository modashboardRepo)
        {
            _logger = logger;
            _modashboardRepo = modashboardRepo;
        }


        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("mo_dashboard_pending_terminal")]
        public async Task<IActionResult> MODashboardPendingTerminal([FromBody] MODashboardPendingTerminalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _modashboardRepo.MODashboardPendingTerminal(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<MODashboardPendingTerminalModelOutput> item = result.Cast<MODashboardPendingTerminalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("mo_dashboard_region_information")]
        public async Task<IActionResult> MODashboardRegionInformation([FromBody] MODashboardRegionInformationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _modashboardRepo.MODashboardRegionInformation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<MODashboardRegionInformationModelOutput> item = result.Cast<MODashboardRegionInformationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("mo_dashboard_user_information")]
        public async Task<IActionResult> MODashboardUserInformation([FromBody] MODashboardUserInformationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _modashboardRepo.MODashboardUserInformation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<MODashboardUserInformationModelOutput> item = result.Cast<MODashboardUserInformationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }
}