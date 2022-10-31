

using System;

namespace HPPay.DataModel.STFC
{
    public class STFCApiRequestModelInput:BaseClass
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
        public Int32 Sourceid { get; set; }
        public int Formfactor { get; set; }
        public string DCSTokenNo { get; set; }
        public int Stan { get; set; }
        public string Paymentmode { get; set; }
        public string Gatewayname { get; set; }
        public string Bankname { get; set; }
        public string Paycode { get; set; }
    }


    public class STFCApiRequestModelOutput : BaseClassOutput
    {
        public int RequestId { get; set; }
    }

    public class STFCApiRequestResponseModelInput : BaseClass
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
        public string STFCCustomerID { get; set; }
        public string DTPCustomerID { get; set; }
        public string ResDTPCustomerID { get; set; }
        public string ResCardNumber { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public int IsPaymentSuccess { get; set; }
        public int IsRefundSuccess { get; set; }
        public string ReqOrgTxnId { get; set; }


    }
    public class STFCApiRequestResponseModelOutput : BaseClassOutput
    {
       
    }


    public class STFCRefundStatusUpdateModelOutput : BaseClassOutput
    {

    }
    public class UpdateCCMSBAlanceForSTFCCustomer : BaseClassOutput
    {
        public string RSP { get; set; }
        public string Volume { get; set; }
    }


    public class UpdateSTFCRequestInput
    {
        public int RequestId { get; set; }
        public string Remarks { get; set; }
        public string ModifiedBy { get; set; }
        public string EntityCheckAPIRequest { get; set; } = String.Empty;
        public string EntityCheckAPIResponse { get; set; } = String.Empty;

    }
    public class UpdateSTFCApiRequestOutput : BaseClassOutput
    {
    }


    public class GetSTFCTxnRefIDOutput 
    {
        public string STFCTxnRefID { get; set; }
    }

}
