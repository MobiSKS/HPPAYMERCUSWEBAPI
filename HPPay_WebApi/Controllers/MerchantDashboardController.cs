using CCA.Util;
using HPPay.DataModel.MerchantDashboard;
using HPPay.DataRepository.MerchantDashboard;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/merchantdashboard")]
    [ApiController]
    public class MerchantDashboardController : ControllerBase
    {
        private readonly ILogger<MerchantDashboardController> _logger;

        private readonly IMerchantDashboardRepository _merchantdashboard;

        private readonly IConfiguration _configuration;

        public MerchantDashboardController(ILogger<MerchantDashboardController> logger, IMerchantDashboardRepository merchantdashboard, IConfiguration configuration)
        {
            _logger = logger;
            _merchantdashboard = merchantdashboard;
            _configuration = configuration;
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_dashboard_key_information")]
        public async Task<IActionResult> MerchantDashboardKeyInformation([FromBody] MerchantDashboardKeyInformationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchantdashboard.MerchantDashboardKeyInformation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantDashboardKeyInformationModelOutput> item = result.Cast<MerchantDashboardKeyInformationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_dashboard_last_transaction")]
        public async Task<IActionResult> MerchantDashboardLastTransaction([FromBody] MerchantDashboardLastTransactionModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchantdashboard.MerchantDashboardLastTransaction(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantDashboardLastTransactionModelOutput> item = result.Cast<MerchantDashboardLastTransactionModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_dashboard_last_batch_deatils")]
        public async Task<IActionResult> MerchantDashboardLastBatchDeatils([FromBody] MerchantDashboardLastBatchDeatilsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchantdashboard.MerchantDashboardLastBatchDeatils(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantDashboardLastBatchDeatilsModelOutput> item = result.Cast<MerchantDashboardLastBatchDeatilsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_dashboard_last_sale_reload_earning_details")]
        public async Task<IActionResult> MerchantDashboardLastSaleReloadEarningDetails([FromBody] MerchantDashboardLastSaleReloadEarningDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchantdashboard.MerchantDashboardLastSaleReloadEarningDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantDashboardLastSaleReloadEarningDetailsModelOutput> item = result.Cast<MerchantDashboardLastSaleReloadEarningDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_dashboard_key_events_and_figures")]
        public async Task<IActionResult> MerchantDashboardKeyEventsAndFigures([FromBody] MerchantDashboardKeyEventsAndFiguresModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchantdashboard.MerchantDashboardKeyEventsAndFigures(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantDashboardKeyEventsAndFiguresModelOutput> item = result.Cast<MerchantDashboardKeyEventsAndFiguresModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_dashboard_todays_transaction_summary")]
        public async Task<IActionResult> MerchantDashboardTodaysTransactionSummary([FromBody] MerchantDashboardTodaysTransactionSummaryModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchantdashboard.MerchantDashboardTodaysTransactionSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantDashboardTodaysTransactionSummaryModelOutput> item = result.Cast<MerchantDashboardTodaysTransactionSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

    }
}

