using CCA.Util;
using HPCL.DataModel.BasicSearchByCustomer;
using HPCL.DataModel.HDFCCreditPouch;
using HPCL.DataRepository.BasicSearch;
using HPCL.DataRepository.BasicSearchByCard;
using HPCL.DataRepository.HDFCCreditPouch;
using HPCL.Infrastructure.CommonClass;
using HPCL_WebApi.ActionFilters;
using HPCL_WebApi.ExtensionMethod;
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
using static HPCL.DataModel.BasicSearchByCard.BasicSearchByModelCard;

namespace HPCL_WebApi.Controllers
{
    //[ApiController]
    //[Route("/api/dtplus/BasicSearchCard")]
    //public class BasicSearchByCardController : ControllerBase
    //{
    //    private readonly ILogger<BasicSearchByCardController> _logger;
    //    private readonly IBasicSearchByCardRepository _BasicSearchCardRepo; 
    //    private readonly IConfiguration _configuration;

    //    public BasicSearchByCardController(ILogger<BasicSearchByCardController> logger, IBasicSearchByCardRepository BasicSearchCardRepo, IConfiguration configuration)
    //    {
    //        _logger = logger;
    //        _BasicSearchCardRepo = BasicSearchCardRepo;
    //        _configuration = configuration;
    //    }

    //    [HttpPost]
    //    //[ServiceFilter(typeof(CustomAuthenticationFilter))]
    //    [Route("get_Basic_SearchBy_Card")]
    //    public async Task<IActionResult> GetBasicSearchByModelCards([FromBody] BasicSearchByCardInput ObjClass)
    //    {
    //        if (ObjClass == null)
    //        {
    //            return this.BadRequestCustom(ObjClass, null, _logger);
    //        }
    //        else
    //        {
    //            var result = await _BasicSearchCardRepo.GetBasicSearchByModelCards(ObjClass);
    //            if (result == null)
    //            {
    //                return this.NotFoundCustom(ObjClass, null, _logger);
    //            }
    //            else
    //            {
    //                List<BasicSearchByCardOutput> item = result.Cast<BasicSearchByCardOutput>().ToList();
    //                if (item.Count > 0)
    //                    return this.OkCustom(ObjClass, result, _logger);
    //                else
    //                    return this.Fail(ObjClass, result, _logger);
    //            }
    //        }
    //    }


    //}
}
