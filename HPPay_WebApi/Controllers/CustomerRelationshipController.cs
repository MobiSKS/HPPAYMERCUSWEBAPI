using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using HPPay.DataModel.Customer;
using System.Linq;
using HPPay.DataRepository.Customer;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using HPPay.DataModel;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.SMSGetSend;
using System;
using HPPay.DataRepository.CustomerRelationship;
using HPPay.DataModel.CustomerRelationship;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/CustomerRelationship")]
    public class CustomerRelationshipController : ControllerBase
    {
        private readonly ILogger<CustomerRelationshipController> _logger;

        private readonly ICustomerRelationshipRepository _CustomerRepo;
        public CustomerRelationshipController(ILogger<CustomerRelationshipController> logger, ICustomerRelationshipRepository CRepo)
        {
            _logger = logger;
            _CustomerRepo = CRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("payment_terms_type")]
        public async Task<IActionResult> PaymentTermsType([FromBody] CustomerRelationshipPaymentTermsTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.PaymentTermsType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipPaymentTermsTypeModelOutput> item = result.Cast<CustomerRelationshipPaymentTermsTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("payment_terms_mode")]
        public async Task<IActionResult> PaymentTermsMode([FromBody] CustomerRelationshipPaymentTermsModeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.PaymentTermsMode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipPaymentTermsModeModelOutput> item = result.Cast<CustomerRelationshipPaymentTermsModeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("segment_served")]
        public async Task<IActionResult> SegmentServed([FromBody] CustomerRelationshipSegmentServedModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.SegmentServed(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipSegmentServedModelOutput> item = result.Cast<CustomerRelationshipSegmentServedModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("usage_type")]
        public async Task<IActionResult> UsageType([FromBody] CustomerRelationshipUsageTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.UsageType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipUsageTypeModelOutput> item = result.Cast<CustomerRelationshipUsageTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("business_solicitation_call_report")]
        public async Task<IActionResult> BusinessSolicitationCallReport([FromBody] BusinessSolicitationCallReportModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.BusinessSolicitationCallReport(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.BusinessSolicitationCallReport.Count > 0 && result.BusinessSolicitationAreaofOperation.Count > 0 && result.BusinessSolicitationMapping.Count > 0 && result.BusinessSolicitationMeetingRemark.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_category")]
        public async Task<IActionResult> CustomerCategory([FromBody] CustomerRelationshipCustomerCategoryModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.CustomerCategory(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipCustomerCategoryModelOutput> item = result.Cast<CustomerRelationshipCustomerCategoryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fleet_size_value")]
        public async Task<IActionResult> FleetSizeValue([FromBody] CustomerRelationshipFleetSizeValueModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.FleetSizeValue(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipFleetSizeValueModelOutput> item = result.Cast<CustomerRelationshipFleetSizeValueModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_mapping_input")]
        public async Task<IActionResult> GetDealerMappingInput([FromBody] CustomerRelationshipGetDealerMappingInputModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.GetDealerMappingInput(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipGetDealerMappingInputModelOutput> item = result.Cast<CustomerRelationshipGetDealerMappingInputModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("list_all_track_id")]
        public async Task<IActionResult> ListAllTrackId([FromBody] CustomerRelationshipListAllTrackIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.ListAllTrackId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipListAllTrackIdModelOutput> item = result.Cast<CustomerRelationshipListAllTrackIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_business_solicitation_call_report")]
        public async Task<IActionResult> UpdateBusinessSolicitationCallReport([FromBody] CustomerRelationshipUpdateBusinessSolicitationCallReportModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.UpdateBusinessSolicitationCallReport(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CustomerRelationshipUpdateBusinessSolicitationCallReportModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CustomerRelationshipUpdateBusinessSolicitationCallReportModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_relationship_business_solicitation_call_report")]
        public async Task<IActionResult> CustomerRelationshipBusinessSolicitationCallReport([FromBody] CustomerRelationshipBusinessSolicitationCallReportModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.CustomerRelationshipBusinessSolicitationCallReport(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CustomerRelationshipBusinessSolicitationCallReportModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CustomerRelationshipBusinessSolicitationCallReportModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_relationship_month")]
        public async Task<IActionResult> CustomerRelationshipMonth([FromBody] CustomerRelationshipMonthModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.CustomerRelationshipMonth(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerRelationshipMonthModelOutput> item = result.Cast<CustomerRelationshipMonthModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_call_status_month")]
        public async Task<IActionResult> getcallstatusmonth([FromBody] CustomerRelationshipgetcallstatusmonthModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.getcallstatusmonth(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                   
                    if (result.BussinessSolicitationDetails.Count > 0 && result.SolicitationRelationshipDetails.Count>0 && result.CustomerRelationshipDetails.Count>0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_relationship_management_call")]
        public async Task<IActionResult> GetRelationshipManagementCall([FromBody] GetRelationshipManagementCallModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerRepo.GetRelationshipManagementCall(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.CustomerDetails.Count > 0 && result.CustomerRelationDetails.Count > 0 && result.Hsddetails.Count > 0
                        &&result.DrivestarDetails.Count>0 && result.KeyCustomerDetails.Count>0 && result.CustomerRouteDetails.Count>0
                        && result.CustomerPaymentDetails.Count>0 && result.CustomerMappingLocation.Count>0 && result.CustomerFeedbackDetails.Count>0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }
}

