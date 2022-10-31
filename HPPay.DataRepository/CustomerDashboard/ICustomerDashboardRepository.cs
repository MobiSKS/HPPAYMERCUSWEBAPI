using HPPay.DataModel.CustomerDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository
{
    public interface ICustomerDashboardRepository
    {
        public Task<IEnumerable<CustomerDashBoardVerifyYourDetailsModelOutput>> CustomerDashBoardVerifyYourDetails(CustomerDashBoardVerifyYourDetailsModelInput objClass);
        public Task<IEnumerable<CustomerDashBoardAccountSummaryModelOutput>> CustomerDashBoardAccountSummary(CustomerDashBoardAccountSummaryModelInput objClass);
        public Task<IEnumerable<CustomerDashBoardLastTransactionsModelOutput>> CustomerDashBoardLastTransactions(CustomerDashBoardLastTransactionsModelInput objClass);
        public Task<IEnumerable<CustomerDashBoardKeyEventModelOutput>> CustomerDashBoardKeyEvent(CustomerDashBoardKeyEventModelInput objClass);
        public Task<IEnumerable<CustomerDashBoardLatestDrivestarsTransactionsModelOutput>> CustomerDashBoardLatestDrivestarsTransactions([FromBody] CustomerDashBoardLatestDrivestarsTransactionsModelInput ObjClass);
        public Task<IEnumerable<CustomerDashBoardReminderModelOutput>> CustomerDashBoardReminder([FromBody] CustomerDashBoardReminderModelInput ObjClass);
        public Task<IEnumerable<CustomerDashboardUpdateVerifyYourDetailsModelOutput>> CustomerDashboardUpdateVerifyYourDetails(CustomerDashboardUpdateVerifyYourDetailsModelInput objClass);
        public  Task<IEnumerable<GetNotificationContentModelOutput>> GetNotificationContent(GetNotificationContentModelInput objClass);
    }
}
