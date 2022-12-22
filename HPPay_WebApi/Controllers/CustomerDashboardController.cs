using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Linq;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using HPPay.DataModel;
using HPPay.DataModel.CustomerDashboard;
using HPPay.DataRepository;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/customerdashboard")]
    public class CustomerDashboardController : ControllerBase
    {
        private readonly ILogger<CustomerDashboardController> _logger;

        private readonly ICustomerDashboardRepository _customerdashboardRepo;

        public CustomerDashboardController(ILogger<CustomerDashboardController> logger, ICustomerDashboardRepository customerdashboardRepo)
        {
            _logger = logger;
            _customerdashboardRepo = customerdashboardRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_verify_your_details")]
        public async Task<IActionResult> CustomerDashBoardVerifyYourDetails([FromBody] CustomerDashBoardVerifyYourDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashBoardVerifyYourDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerDashBoardVerifyYourDetailsModelOutput> item = result.Cast<CustomerDashBoardVerifyYourDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_account_summary")]
        public async Task<IActionResult> CustomerDashBoardAccountSummary([FromBody] CustomerDashBoardAccountSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashBoardAccountSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerDashBoardAccountSummaryModelOutput> item = result.Cast<CustomerDashBoardAccountSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_last_transactions")]
        public async Task<IActionResult> CustomerDashBoardLastTransactions([FromBody] CustomerDashBoardLastTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashBoardLastTransactions(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null,_logger);
                }
                else
                {

                    List<CustomerDashBoardLastTransactionsModelOutput> item = result.Cast<CustomerDashBoardLastTransactionsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_key_event")]
        public async Task<IActionResult> CustomerDashBoardKeyEvent([FromBody] CustomerDashBoardKeyEventModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashBoardKeyEvent(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerDashBoardKeyEventModelOutput> item = result.Cast<CustomerDashBoardKeyEventModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_latest_drivestars_transactions")]
        public async Task<IActionResult> CustomerDashBoardLatestDrivestarsTransactions([FromBody] CustomerDashBoardLatestDrivestarsTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashBoardLatestDrivestarsTransactions(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerDashBoardLatestDrivestarsTransactionsModelOutput> item = result.Cast<CustomerDashBoardLatestDrivestarsTransactionsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_reminder")]
        public async Task<IActionResult> CustomerDashBoardReminder([FromBody] CustomerDashBoardReminderModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashBoardReminder(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerDashBoardReminderModelOutput> item = result.Cast<CustomerDashBoardReminderModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_dashboard_update_verify_your_details")]
        public async Task<IActionResult> CustomerDashboardUpdateVerifyYourDetails([FromBody] CustomerDashboardUpdateVerifyYourDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.CustomerDashboardUpdateVerifyYourDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<CustomerDashboardUpdateVerifyYourDetailsModelOutput> item = result.Cast<CustomerDashboardUpdateVerifyYourDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_notification_content")]
        public async Task<IActionResult> GetNotificationContent([FromBody] GetNotificationContentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _customerdashboardRepo.GetNotificationContent(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<GetNotificationContentModelOutput> item = result.Cast<GetNotificationContentModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }
}
   
