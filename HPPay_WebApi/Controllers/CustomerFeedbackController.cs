using HPPay.DataRepository.CustomerFeedbackRepository;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay.DataModel.CustomerFeedback;
using System.Collections.Generic;
using System.Linq;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/customerfeedback")]
    public class CustomerFeedbackController : Controller
    {

        private readonly ILogger<CustomerFeedbackController> _logger;

        private readonly ICustomerFeedbackRepository _CustomerFeedbackRepo;
        public CustomerFeedbackController(ILogger<CustomerFeedbackController> logger, ICustomerFeedbackRepository CustomerFeedbackRepo)
        {
            _logger = logger;
            _CustomerFeedbackRepo = CustomerFeedbackRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_feedback_dropdown")]
        public async Task<IActionResult> CustomerFeedbackDropdown([FromBody] CustomerFeedbackDropdownModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CustomerFeedbackRepo.CustomerFeedbackDropdown(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerFeedbackDropdownModelOutput> item = result.Cast<CustomerFeedbackDropdownModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }
}
