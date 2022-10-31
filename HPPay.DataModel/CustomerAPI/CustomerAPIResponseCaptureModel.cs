using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIResponseCaptureModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TransactionId { get; set; }
        public string CustomerId { get; set; }
        public string ChildId { get; set; }
        public string BalanceTransType { get; set; }
        public string TransferAmount { get; set; }
        public string DriveStars { get; set; }
        public string LimitType { get; set; }
        public string LimitValue { get; set; }
        public string CardNumber { get; set; }
        public string Mobile { get; set; }
        public string SaleTransactionLimit { get; set; }
        public string DailyLimit { get; set; }
        public string MonthlyLimit { get; set; }
        public string CCMSLimitType { get; set; }
        public string CCMSLimitValue { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ParentCustomerId { get; set; }
        public string ChildCustomerId { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }
    }
}
