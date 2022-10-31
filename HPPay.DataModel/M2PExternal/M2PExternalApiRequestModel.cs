using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.M2PExternal
{
    

    public class M2PApiRequestModelInput : BaseClass
    {
        public string ApiRequestUrL { get; set; }

        public string MerchantID { get; set; }
        public string TerminalID { get; set; }

        public string DTPCustomerId { get; set; }
        public string CardNo { get; set; }
        public Nullable<DateTime> Transdate { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }

        public string TxnId { get; set; }

        public string Invoiceid { get; set; }
        public Int64 Batchid { get; set; }
        public Nullable<DateTime> Invoicedate { get; set; }

        public int Productid { get; set; }
        public string Odometerreading { get; set; }
        public string TransType { get; set; }
        public int Sourceid { get; set; }
        public int Formfactor { get; set; }
        public string DCSTokenNo { get; set; }
        public int Stan { get; set; }
        public string Paymentmode { get; set; }
        public string Gatewayname { get; set; }
        public string Bankname { get; set; }
        public string Paycode { get; set; }
    }


    public class M2PApiRequestModelOutput : BaseClassOutput
    {
        public int RequestId { get; set; }
    }

    public class M2PApiRequestResponseModelInput : BaseClass
    {
        public int RqId { get; set; }
        public string ApiRequestUrL { get; set; }
        public string ApiRequest { get; set; }
        public string ApiResponse { get; set; }
        public string ReqAmount { get; set; }
        public string MerchantID { get; set; }
        public string TerminalID { get; set; }
        public string ReqCardNo { get; set; }
        public string ReqTxnId { get; set; }
        public string ResTxnId { get; set; }
        public string ResMsgType { get; set; }
        public string ResErrorReason { get; set; }
        public string ResMsg { get; set; }
        public string ResAvailableLimit { get; set; }
        public string M2PCustomerID { get; set; }
        public string DTPCustomerID { get; set; }
        public string ResDTPCustomerID { get; set; }
        public string ResCardNumber { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public int IsPaymentSuccess { get; set; }
        public int IsRefundSuccess { get; set; }
        public string ReqOrgTxnId { get; set; }

        public string Result { get; set; }
        public string DetailMessage { get; set; }
        public string ShortMessage { get; set; }
        public string ErrorCode { get; set; }
        public string TransactionDate { get; set; }


    }
    public class M2PApiRequestResponseModelOutput : BaseClass
    {

    }


    public class M2PRefundStatusUpdateModelOutput : BaseClassOutput
    {

    }
    public class UpdateCCMSBAlanceForM2PCustomer : BaseClassOutput
    {

    }


    public class UpdateM2PRequestInput
    {
        public int RequestId { get; set; }
        public string Remarks { get; set; }
        public string ModifiedBy { get; set; }

        public string EntityCheckAPIRequest { get; set; } = String.Empty;
        public string EntityCheckAPIResponse { get; set; } = String.Empty;

    }
    public class UpdateM2PApiRequestOutput : BaseClassOutput
    {
    }


    public class M2PCheckCardLimitValidationforAPIInput
    {
        public string CardNo { get; set; }
        public string Mobileno { get; set; }
        public DateTime Invoicedate { get; set; }
        public decimal Invoiceamount { get; set; }
        public int Sourceid { get; set; }
        public int Formfactor { get; set; }

        public string Pin { get; set; }
        public string Userid { get; set; }

    }

    public class M2PCheckCardLimitValidationforAPIOutput : BaseClassOutput
    {
        public string CardNumber { get; set; }
    }

   
}
