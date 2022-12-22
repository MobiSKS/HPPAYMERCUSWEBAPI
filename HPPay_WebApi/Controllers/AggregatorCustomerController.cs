using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using HPPay.DataModel.AggregatorCustomer;
using System.Linq;
using HPPay.DataRepository.AggregatorCustomer;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;


namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/aggregatorcustomer")]
    public class AggregatorCustomerController : Controller
    {
        private readonly ILogger<AggregatorCustomerController> _logger;

        private readonly IAggregatorCustomerRepository _aggregatorCustomerRepo;

        public AggregatorCustomerController(ILogger<AggregatorCustomerController> logger, IAggregatorCustomerRepository aggregatorRepo)
        {
            _logger = logger;
            _aggregatorCustomerRepo = aggregatorRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_aggregator_customer")]
        public async Task<IActionResult> InsertAggregatorCustomer([FromBody] AggregatorCustomerInsertModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.InsertAggregatorCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorCustomerInsertModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorCustomerInsertModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_aggregator_customer")]
        public async Task<IActionResult> UpdateAggregatorCustomer([FromBody] AggregatorCustomerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.UpdateAggregatorCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorCustomerUpdateModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorCustomerUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("upload_aggregator_customer_kyc")]
        public async Task<IActionResult> UploadAggregatorCustomerKYC([FromForm] AggregatorCustomerKYCModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.UploadAggregatorCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorCustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorCustomerKYCModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("upload_aggregator_normal_fleet_customer_kyc")]
        public async Task<IActionResult> UploadAggregatorNormalFleetCustomerKYC([FromForm] AggregatorNormalFleetCustomerKYCModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.UploadAggregatorNormalFleetCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorNormalFleetCustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorNormalFleetCustomerKYCModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }

        //[HttpPost]
        ////[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("upload_aggregator_normal_fleet_customer_RcCopy")]
        //public async Task<IActionResult> UploadAggregatorNormalFleetCustomerRCCopy([FromForm] AggregatorNormalFleetCustomerRCCopyModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _aggregatorCustomerRepo.UploadAggregatorNormalFleetCustomerRCCopy(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            if (result.Cast<AggregatorNormalFleetCustomerRCCopyModelOutput>().ToList()[0].Status == 1)
        //            {
        //                return this.OkCustom(ObjClass, result, _logger);
        //            }
        //            else
        //            {
        //                return this.FailCustom(ObjClass, result, _logger,
        //                    result.Cast<AggregatorNormalFleetCustomerRCCopyModelOutput>().ToList()[0].Reason);
        //            }

        //        }
        //    }
        //}

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("aggregator_normal_fleet_customer_add_card")]
        public async Task<IActionResult> AggregatorNormalFleetCustomerAddCard([FromForm] AggregatorNormalFleetCustomerAddCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.AggregatorNormalFleetCustomerAddCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorNormalFleetCustomerAddCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorNormalFleetCustomerAddCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("aggregator_normal_fleet_customer_add_oncard")]
        public async Task<IActionResult> AggregatorNormalFleetCustomerAddOnCard([FromForm] AggregatorNormalFleetCustomerAddOnCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.AggregatorNormalFleetCustomerAddOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorNormalFleetCustomerAddOnCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorNormalFleetCustomerAddOnCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_fleet_customer_name_by_customerId")]
        public async Task<IActionResult> GetAggregatorFleetCustomerNameByCustomerId([FromBody] GetAggregatorFleetCustomerNameByCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorFleetCustomerNameByCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorFleetCustomerNameByCustomerIdModelOutput> item = result.Cast<GetAggregatorFleetCustomerNameByCustomerIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer_normal_fleet_download_kyc")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerDownloadKyc([FromBody] GetAggregatorNormalFleetCustomerDownloadKycModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerDownloadKyc(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetCustomerDownloadKycModelOutput> item = result.Cast<GetAggregatorNormalFleetCustomerDownloadKycModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer")]
        public async Task<IActionResult> GetAggregatorCustomer([FromBody] GetAggregatorCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorCustomerModelOutput> item = result.Cast<GetAggregatorCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_aggregator_normal_fleet_customer")]
        public async Task<IActionResult> InsertAggregatorNormalFleetCustomer([FromBody] AggregatorNormalFleetCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.InsertAggregatorNormalFleetCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorNormalFleetCustomerModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorNormalFleetCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_aggregator_normal_fleet_customer")]
        public async Task<IActionResult> UpdateAggregatorNormalFleetCustomer([FromBody] AggregatorNormalFleetCustomerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.UpdateAggregatorNormalFleetCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorNormalFleetCustomerUpdateModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorNormalFleetCustomerUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_aggregator_customer")]
        public async Task<IActionResult> ApproveRejectAggregatorCustomer([FromBody] AggregatorCustomerApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.ApproveRejectAggregatorCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AggregatorCustomerApprovalModelOutput>().ToList()[0].Status == 1)
                    {


                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AggregatorCustomerApprovalModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_approve_aggregator_fee_waiver_detail")]
        public async Task<IActionResult> GetApproveAggregatorFeeWaiverDetail([FromBody] GetApproveAggregatorFeeWaiverDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetApproveAggregatorFeeWaiverDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetApproveAggregatorFeeWaiverBasicDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer_status")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerStatus([FromBody] GetAggregatorNormalFleetCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetCustomerStatusModelOutput> item = result.Cast<GetAggregatorNormalFleetCustomerStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer_status_approve")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerStatusApprove([FromBody] GetAggregatorNormalFleetCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerStatusApprove(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetCustomerStatusModelOutput> item = result.Cast<GetAggregatorNormalFleetCustomerStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_name_by_reference_no")]
        public async Task<IActionResult> GetAggregatorNormalFleetNamebyReferenceNo([FromBody] GetAggregatorNormalFleetNamebyReferenceNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetNamebyReferenceNo(ObjClass);
                if (result == null || result.Count() == 0)
                {
                    return this.Fail(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetNamebyReferenceNoModelOutput> item = result.Cast<GetAggregatorNormalFleetNamebyReferenceNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.NotFoundCustom(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomer([FromBody] GetAggregatorNormalFleetCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetCustomerModelOutput> item = result.Cast<GetAggregatorNormalFleetCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer_verify_card")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerVerifyCard([FromBody] GetAggregatorNormalFleetCustomerVerifyCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerVerifyCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetCustomerVerifyCardModelOutput> item = result.Cast<GetAggregatorNormalFleetCustomerVerifyCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer_approve_card")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerApproveCard([FromBody] GetAggregatorNormalFleetCustomerApproveCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerApproveCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNormalFleetCustomerApproveCardModelOutput> item = result.Cast<GetAggregatorNormalFleetCustomerApproveCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("verify_reject_aggregator_normal_fleet_customer_card")]
        public async Task<IActionResult> VerifyRejectAggregatorNormalFleetCustomerCard([FromBody] VerifyRejectAggregatorNormalFleetCustomerCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.VerifyRejectAggregatorNormalFleetCustomerCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<VerifyRejectAggregatorNormalFleetCustomerCardModelOutput> item = result.Cast<VerifyRejectAggregatorNormalFleetCustomerCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("verify_reject_aggregator_normal_fleet_customer")]
        public async Task<IActionResult> VerifyRejectAggregatorNormalFleetCustomer([FromBody] VerifyRejectAggregatorNormalFleetCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.VerifyRejectAggregatorNormalFleetCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<VerifyRejectAggregatorNormalFleetCustomerModelOutput> item = result.Cast<VerifyRejectAggregatorNormalFleetCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_aggregator_normal_fleet_customer")]
        public async Task<IActionResult> ApproveRejectAggregatorNormalFleetCustomer([FromBody] ApproveRejectAggregatorNormalFleetCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.ApproveRejectAggregatorNormalFleetCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ApproveRejectAggregatorNormalFleetCustomerModelOutput> item = result.Cast<ApproveRejectAggregatorNormalFleetCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_aggregator_normal_fleet_customer_card")]
        public async Task<IActionResult> ApproveRejectAggregatorNormalFleetCustomerCard([FromBody] ApproveRejectAggregatorNormalFleetCustomerCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.ApproveRejectAggregatorNormalFleetCustomerCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ApproveRejectAggregatorNormalFleetCustomerCardModelOutput> item = result.Cast<ApproveRejectAggregatorNormalFleetCustomerCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_name_and_form_number_by_reference_no")]
        public async Task<IActionResult> GetAggregatorNameandFormNumberbyReferenceNo([FromBody] AggregatorCustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNameandFormNumberbyReferenceNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorCustomerGetCustomerReferenceNoModelOutput> item = result.Cast<AggregatorCustomerGetCustomerReferenceNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer_name_and_form_number_by_reference_no")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNo([FromBody] AggregatorNormalFleetCustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorNormalFleetCustomerGetCustomerReferenceNoModelOutput> item = result.Cast<AggregatorNormalFleetCustomerGetCustomerReferenceNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_normal_fleet_customer_name_and_form_number_by_reference_no_for_customer")]
        public async Task<IActionResult> GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNoforCustomer([FromBody] AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNoforCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelOutput> item = result.Cast<AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_name_and_form_number_by_reference_no_for_add_card")]
        public async Task<IActionResult> GetAggregatorNameandFormNumberbyReferenceNoforAddCard([FromBody] AggregatorCustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNameandFormNumberbyReferenceNoforAddCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorCustomerGetCustomerReferenceNoModelOutput> item = result.Cast<AggregatorCustomerGetCustomerReferenceNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer_by_customer_id")]
        public async Task<IActionResult> GetAggregatorCustomerByCustomerId([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorCustomerByCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAggregatorCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer_detail")]
        public async Task<IActionResult> GetAggregatorCustomerDetails([FromBody] AggregatorCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAggregatorCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_raw_aggregator_customer_detail")]
        public async Task<IActionResult> GetRawAggregatorCustomerDetails([FromBody] AggregatorCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetRawAggregatorCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAggregatorCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_pending_aggregator_customer")]
        public async Task<IActionResult> BindPendingAggregatorCustomer([FromBody] BindPendingAggregatorCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.BindPendingAggregatorCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindPendingAggregatorCustomerModelOutput> item = result.Cast<BindPendingAggregatorCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_unverfied_aggregator_customer")]
        public async Task<IActionResult> BindUnverfiedCustomer([FromBody] BindPendingAggregatorCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.BindUnverfiedAggregatorCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindPendingAggregatorCustomerModelOutput> item = result.Cast<BindPendingAggregatorCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_unverfied_aggregator_customer_detail_by_form_number")]
        public async Task<IActionResult> GetUnverfiedAggregatorCustomerDetailbyFormNumber([FromBody] AggregatorCustomerDetailsbyFormNumberModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetUnverfiedAggregatorCustomerDetailbyFormNumber(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAggregatorCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_unverfied_aggregator_normal_fleet_customer_detail_by_form_number")]
        public async Task<IActionResult> GetUnverfiedAggregatorNormalFleetCustomerDetailbyFormNumber([FromBody] AggregatorNormalFleetCustomerDetailsbyFormNumberModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetUnverfiedAggregatorNormalFleetCustomerDetailbyFormNumber(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAggregatorCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer_name_by_customer_id")]
        public async Task<IActionResult> GetAggregatorCustomerNameByCustomerId([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorCustomerNameByCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorCustomerGetCustomerNameModelOutput> item = result.Cast<AggregatorCustomerGetCustomerNameModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer_details_for_search")]
        public async Task<IActionResult> GetAggregatorCustomerDetailsForSearch([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorCustomerDetailsForSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorCustomerGetCustomerDetailsForSearchModelOutput> item = result.Cast<AggregatorCustomerGetCustomerDetailsForSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_aggregator_customer_and_card_form")]
        public async Task<IActionResult> SearchAggregatorCustomerandCardForm([FromBody] SearchAggregatorCustomerandCardFormModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.SearchAggregatorCustomerandCardForm(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetAggregatorCustomerSearchOutput.Count > 0 && result.GetAggregatorCardSearchOutput.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_name_and_formnumber_by_customerid")]
        public async Task<IActionResult> GetAggregatorNameandFormNumberbyCustomerId([FromBody] GetAggregatorNameandFormNumberbyCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorNameandFormNumberbyCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorNameandFormNumberbyCustomerIdModelOutput> item = result.Cast<GetAggregatorNameandFormNumberbyCustomerIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("aggregator_customer_add_on_user")]
        public async Task<IActionResult> AggregatorCustomerAddOnUser([FromBody] AggregatorCustomerAddOnUserModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.AggregatorCustomerAddOnUser(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AggregatorCustomerAddOnUserModelOutput> item = result.Cast<AggregatorCustomerAddOnUserModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_status_list")]
        public async Task<IActionResult> GetAggregatorStatusList([FromBody] GetAggregatorStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorStatusList(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorStatusModelOutput> item = result.Cast<GetAggregatorStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregator_customer_for_zo_ho_approval")]
        public async Task<IActionResult> GetAggregatorCustomerForZOHOApproval([FromBody] GetAggregatorCustomerForZOHOApprovalModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregatorCustomerForZOHOApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregatorCustomerForZOHOApprovalModelOutput> item = result.Cast<GetAggregatorCustomerForZOHOApprovalModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_aggregate_userdetail_for_approval")]
        public async Task<IActionResult> GetAggregateUserDetailForApproval([FromBody] GetAggregateUserDetailForApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.GetAggregateUserDetailForApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAggregateUserDetailForApprovalModelOutput> item = result.Cast<GetAggregateUserDetailForApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Approve_Reject_Aggregator_User_Approval")]
        public async Task<IActionResult> ApproveRejectAggregateUserApproval([FromBody] ApproveRejectAggregateUserApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _aggregatorCustomerRepo.ApproveRejectAggregateUserApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ApproveRejectAggregateUserApprovalModelOutput> item = result.Cast<ApproveRejectAggregateUserApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }
}


