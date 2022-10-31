using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.IciciAPI
{
    public class IciciApiRequestResponseInput
    {
        public string ApiRequestUrL { get; set; }
        public string ApiRequest { get; set; }
        public string ApiResponse { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
    }

    public class IciciApiRequestResponseOutput : BaseClassOutput
    {
        public int Id { get; set; }
    }


    public class InsertFastagIciciApiRequestInput
    {
        public string ApiRequestUrL { get; set; }
        public string ApiRequest { get; set; }
        public string ApiResponse { get; set; }
        public string MerchantID { get; set; }
        public string TerminalID { get; set; }
        public int BankID { get; set; }
        public string MobileNo { get; set; }
        public string Vrn { get; set; }
        public string Amount { get; set; }
        public string NetAmount { get; set; }
        public string DiscountAmount { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }

        public string TxnId { get; set; }
        public string TagId { get; set; }
        public string OrgTxnId { get; set; }
        public string OrgTxnTime { get; set; }
        public string OTP { get; set; }
        public string TxnTime { get; set; }
        public string TxnNo { get; set; }

        public string Invoiceid { get; set; }       
        public int Batchid { get; set; }
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
    public class InsertFastagIciciApiRequestOutput : BaseClassOutput
    {
        public int RequestId { get; set; }
    }

    public class UpdateFastagIciciApiRequestInput
    {
        public int RequestId { get; set; }
        public string Remarks { get; set; }
        public string ModifiedBy { get; set; }

    }
    public class UpdateFastagIciciApiRequestOutput : BaseClassOutput
    {
    }

    public class IciciApiRequestResponseDetailsInput
    {
    }
    public class IciciApiRequestResponseDetailInput
    {
        public int RqId { get; set; }
        public string ApiRequestUrL { get; set; }
        public string ApiRequest { get; set; }
        public string ApiResponse { get; set; }

        public string ReqMobileNo { get; set; }
        public string ReqVrn { get; set; }
        public string ReqAmount { get; set; }
        public string ReqNetAmount { get; set; }
        public string ReqDiscount { get; set; }
        public string ReqEntityId { get; set; }
        public string ReqPosId { get; set; }
        public string ReqTxnTime { get; set; }
        public string ReqIIN { get; set; }
        public string ReqChkSm { get; set; }
        public string ReqOtp { get; set; }
        public string ReqOrgTxnId { get; set; }
        public string ReqOrgTxnTime { get; set; }
        public string ReqTxnId { get; set; }
        public string ResTxnId { get; set; }
        public string ResTxnNo { get; set; }
        public string ResCode { get; set; }
        public string ResMsg { get; set; }
        public string RestagId { get; set; }
        public string ResMobileNo { get; set; }
        public string ResVrn { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public int IsPaymentSuccess { get; set; }
        public int IsRefundSuccess { get; set; }

    }
    public class IciciApiRequestResponseDetailOutput : BaseClassOutput
    {
    }


    public class IciciCheckFastagInvoiceIdBatchIdExistInput 
    {
        public string Invoiceid { get; set; }
        public int Batchid { get; set; }
        public int RecordType { get; set; }
        public string MerchantID { get; set; }
        public string TerminalID { get; set; }
        public string UserId { get; set; }
        public string TransTypeId { get; set; }
        public string Useragent { get; set; }

    }
    public class IciciCheckFastagInvoiceIdBatchIdExistOutput : BaseClassOutput
    {
    }


}
