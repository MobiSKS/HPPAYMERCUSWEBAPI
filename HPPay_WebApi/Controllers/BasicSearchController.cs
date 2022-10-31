using CCA.Util;
using HPPay.DataModel.BasicSearchByCustomer;
using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataRepository.BasicSearch;
using HPPay.DataRepository.HDFCCreditPouch;
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
using System.Text;
using System.Threading.Tasks;
using static HPPay.DataModel.BasicSearchByCard.BasicSearchByModelCard;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/basicsearch")]
    public class BasicSearchController : ControllerBase
    {
        private readonly ILogger<BasicSearchController> _logger;
        private readonly IBasicSearchByCustomerRepository _BasicSearchRepo;
        private readonly IConfiguration _configuration;

        public BasicSearchController(ILogger<BasicSearchController> logger, IBasicSearchByCustomerRepository BasicSearchRepo, IConfiguration configuration)
        {
            _logger = logger;
            _BasicSearchRepo = BasicSearchRepo;
            _configuration = configuration;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_basic_searchby_customer")]
        public async Task<IActionResult> GetBasicSearchByModelCustomers([FromBody] BasicSearchByCustomerInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _BasicSearchRepo.GetBasicSearchByModelCustomers(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BasicSearchByCustomerOutput> item = result.Cast<BasicSearchByCustomerOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }


                

            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_basic_searchby_card")]
        public async Task<IActionResult> GetBasicSearchByModelCards([FromBody] BasicSearchByCardInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _BasicSearchRepo.GetBasicSearchByModelCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BasicSearchByCardOutput> item = result.Cast<BasicSearchByCardOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_basic_searchby_customer")]

        public async Task<IActionResult> ViewBasicSearchByModelCustomers([FromBody] ViewBasicSearchByCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _BasicSearchRepo.ViewBasicSearchByModelCustomers(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewBasicSearchByCustomerModelOutput> item = result.Cast<ViewBasicSearchByCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }
}

