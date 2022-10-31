using HPPay.DataModel.SadakKeSathi;
using HPPay.DataRepository.SadakKeSathi;
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
    [Route("api/dtplus/SadakKeSathi")]
    [ApiController]
    public class SadakKeSathiController : ControllerBase
    {
        private readonly ISadakKeSathiRepository _SKSRepo;
        private readonly ILogger<SadakKeSathiController> _logger;
        private readonly IConfiguration _configuration;
        public SadakKeSathiController(ILogger<SadakKeSathiController> logger, ISadakKeSathiRepository SKSRepo, IConfiguration configuration)
        {
            _SKSRepo = SKSRepo;
            _logger = logger;
            _configuration = configuration;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 19-09-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_sks_vehicle_detail")]
        public async Task<IActionResult> GetSKSVehicleDetail([FromBody] GetSKSVehicleDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SKSRepo.GetSKSVehicleDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetSKSVehicleDetailModelOutput> item = result.Cast<GetSKSVehicleDetailModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 19-09-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_sks_monthly_charges_per_vehicle")]
        public async Task<IActionResult> GetSKSMonthlyChargesPerVehicle([FromBody] GetSKSChargesPerVehicleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SKSRepo.GetSKSMonthlyChargesPerVehicle();
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetSKSChargesPerVehicleModelOutput> item = result.Cast<GetSKSChargesPerVehicleModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 19-09-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_sks_vehicle_enrolment_detail")]
        public async Task<IActionResult> GetSKSVehicleEnrolmentDetail([FromBody] GetSKSVehicleEnrolmentDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SKSRepo.GetSKSVehicleEnrolmentDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetSKSVehicleEnrolmentDetailModelOutput> item = result.Cast<GetSKSVehicleEnrolmentDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 19-09-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_sks_vehicle_enrolment_detail")]
        public async Task<IActionResult> InsertSKSVehicleEnrolmentDetail([FromBody] InsertSKSVehicleEnrolmentDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SKSRepo.InsertSKSVehicleEnrolmentDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<InsertSKSVehicleEnrolmentDetailModelOutput> item = result.Cast<InsertSKSVehicleEnrolmentDetailModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

    }
}
