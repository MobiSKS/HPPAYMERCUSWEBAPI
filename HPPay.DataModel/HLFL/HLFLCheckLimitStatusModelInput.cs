using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.HLFL
{
    public class HLFLCheckLimitStatusModelInput
    {
        //[Required]
        //[JsonPropertyName("Source")]
        //[DataMember]
        //public string Source { get; set; }

        [Required]
        [JsonPropertyName("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public double Amount { get; set; }

        //[JsonPropertyName("Request")]
        //[DataMember]
        //public string Request { get; set; }

        //[JsonPropertyName("Response")]
        //[DataMember]
        //public string Response { get; set; }

        //[JsonPropertyName("Product")]
        //[DataMember]
        //public string Product { get; set; }

        //[JsonPropertyName("AggrID")]
        //[DataMember]
        //public string AggrID { get; set; }

        //[JsonPropertyName("FacilityNumber")]
        //[DataMember]
        //public string FacilityNumber { get; set; }

        //[JsonPropertyName("HLFLCustomerID")]
        //[DataMember]
        //public string HLFLCustomerID { get; set; }

        //[JsonPropertyName("AggrControlCardNumber")]
        //[DataMember]
        //public string AggrControlCardNumber { get; set; }        

        //[JsonPropertyName("HLFLRequestID")]
        //[DataMember]
        //public string HLFLRequestID { get; set; }

        //[JsonPropertyName("AggrRequestID")]
        //[DataMember]
        //public string AggrRequestID { get; set; }

        //[Required]        
        //[JsonPropertyName("CreatedBy")]
        //[DataMember]
        //public string CreatedBy { get; set; }

    }

    public class HLFLLimitStatusCheckModelInput
    {
        //[JsonPropertyName("Source")]
        //[DataMember]
        //public string Source { get; set; }

        [Required]
        [JsonPropertyName("aggrCustomerID")]
        [DataMember]
        public string aggrCustomerID { get; set; }

        [JsonPropertyName("product")]
        [DataMember]
        public string product { get; set; }

        [JsonPropertyName("aggrID")]
        [DataMember]
        public string aggrID { get; set; }

        [JsonPropertyName("facilityNumber")]
        [DataMember]
        public string facilityNumber { get; set; }

        [JsonPropertyName("hlflcustomerID")]
        [DataMember]
        public string hlflcustomerID { get; set; }

        [JsonPropertyName("aggrControlCardNumber")]
        [DataMember]
        public string aggrControlCardNumber { get; set; }

        //[JsonPropertyName("Authorization")]
        //[DataMember]
        //public string Authorization { get; set; }

        //[JsonPropertyName("HLFLRequestID")]
        //[DataMember]
        //public string HLFLRequestID { get; set; }

        //[JsonPropertyName("AggrRequestID")]
        //[DataMember]
        //public string AggrRequestID { get; set; }

        //[Required]
        //[JsonPropertyName("CreatedBy")]
        //[DataMember]
        //public string CreatedBy { get; set; }

    }

    public class HLFLCheckLimitStatusModelOutput
    {
        [JsonProperty("Response")]
        [DataMember]
        public string Response { get; set; }


        [JsonProperty("aggrId")]
        [DataMember]
        public string aggrId { get; set; }

        [JsonProperty("facilityStatus")]
        [DataMember]
        public string facilityStatus { get; set; }

        [JsonProperty("facilityLimitAmount")]
        [DataMember]
        public string facilityLimitAmount { get; set; }

        [JsonProperty("facilityConsumedAmount")]
        [DataMember]
        public string facilityConsumedAmount { get; set; }

        [JsonProperty("cutOffLimit")]
        [DataMember]
        public string cutOffLimit { get; set; }

        [JsonProperty("startDate")]
        [DataMember]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        [DataMember]
        public string endDate { get; set; }

        [JsonProperty("facilityNumber")]
        [DataMember]
        public string facilityNumber { get; set; }

        [JsonProperty("aggrControlCardNumber")]
        [DataMember]
        public string aggrControlCardNumber { get; set; }

        [JsonProperty("facilityBalanceAmount")]
        [DataMember]
        public string facilityBalanceAmount { get; set; }

        [JsonProperty("hlflStatusCode")]
        [DataMember]
        public int hlflStatusCode { get; set; }

        [JsonProperty("hlflStatusRemark")]
        [DataMember]
        public string hlflStatusRemark { get; set; }

        [JsonProperty("transactionStatus")]
        [DataMember]
        public string transactionStatus { get; set; }

        [JsonProperty("aggrRequestId")]
        [DataMember]
        public string aggrRequestId { get; set; }

        [JsonProperty("hlflRequestId")]
        [DataMember]
        public string hlflRequestId { get; set; }

    }

    public class HLFLDDRequestModelInput
    {
        [JsonPropertyName("Product")]
        [DataMember]
        public string Product { get; set; }

        [Required]
        [JsonPropertyName("Source")]
        [DataMember]
        public string Source { get; set; }

        [Required]
        [JsonPropertyName("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }


        [JsonPropertyName("Response")]
        [DataMember]
        public string Response { get; set; }



        [JsonPropertyName("AggrID")]
        [DataMember]
        public string AggrID { get; set; }

        [JsonPropertyName("HLFLFacilityNumber")]
        [DataMember]
        public string HLFLFacilityNumber { get; set; }

        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

        [JsonPropertyName("AggrControlCardNumber")]
        [DataMember]
        public string AggrControlCardNumber { get; set; }


        [JsonPropertyName("AggrRequestID")]
        [DataMember]
        public string AggrRequestID { get; set; }

        [Required]
        [Range(1.00, 10000000.00, ErrorMessage = "Limit value should be between 1 to 10 Cr")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName(" DDRequestAmount")]
        [DataMember]
        public double DDRequestAmount { get; set; }

        [Required]
        [JsonPropertyName("DDRequestDate")]
        [DataMember]
        public string DDRequestDate { get; set; }

        [Required]
        [JsonPropertyName("Authorization")]
        [DataMember]
        public string Authorization { get; set; }

    }

    public class HLFLDDRequestModelOutput
    {

        //[JsonPropertyName("Status")]
        //[DataMember]
        //public int Status { get; set; }

        //[JsonPropertyName("responseMessage")]
        //[DataMember]
        //public string responseMessage { get; set; }

        [JsonProperty("Response")]
        [DataMember]
        public string Response { get; set; }

        [JsonProperty("aggrId")]
        [DataMember]
        public string aggrId { get; set; }

        [JsonProperty("aggrRequestId")]
        [DataMember]
        public string aggrRequestId { get; set; }

        [JsonProperty("hlflRequestId")]
        [DataMember]
        public string hlflRequestId { get; set; }

        [JsonProperty("hlflFacilityNumber")]
        [DataMember]
        public string hlflFacilityNumber { get; set; }

        [JsonProperty("hlflStatusCode")]
        [DataMember]
        public string hlflStatusCode { get; set; }

        [JsonProperty("hlflStatusRemark")]
        [DataMember]
        public string hlflStatusRemark { get; set; }

        [JsonProperty("facilityStatus")]
        [DataMember]
        public string facilityStatus { get; set; }

        [JsonProperty("facilityLimitAmount")]
        [DataMember]
        public string facilityLimitAmount { get; set; }

        [JsonProperty("facilityConsumedAmount")]
        [DataMember]
        public string facilityConsumedAmount { get; set; }

        [JsonProperty("cutOffLimit")]
        [DataMember]
        public string cutOffLimit { get; set; }

        [JsonProperty("startDate")]
        [DataMember]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        [DataMember]
        public string endDate { get; set; }

        [JsonProperty("facilityNumber")]
        [DataMember]
        public string facilityNumber { get; set; }

        [JsonProperty("aggrControlCardNumber")]
        [DataMember]
        public string aggrControlCardNumber { get; set; }

        [JsonProperty("facilityBalanceAmount")]
        [DataMember]
        public string facilityBalanceAmount { get; set; }

    }

    public class HLFLValidateOTPModelInput
    {
        [JsonPropertyName("Product")]
        [DataMember]
        public string Product { get; set; }

        [Required]
        [JsonPropertyName("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }

        [JsonPropertyName("AggrID")]
        [DataMember]
        public string AggrID { get; set; }

        [JsonPropertyName("HLFLFacilityNumber")]
        [DataMember]
        public string HLFLFacilityNumber { get; set; }

        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

        [JsonPropertyName("AggrControlCardNumber")]
        [DataMember]
        public string AggrControlCardNumber { get; set; }


        [JsonPropertyName("AggrRequestID")]
        [DataMember]
        public string AggrRequestID { get; set; }

        [JsonPropertyName("HLFLRequestID")]
        [DataMember]
        public string HLFLRequestID { get; set; }

        [JsonPropertyName("CustomerOTP")]
        [DataMember]
        public string CustomerOTP { get; set; }

        //[JsonPropertyName("DDRequestDate")]
        //[DataMember]
        //public string DDRequestDate { get; set; }

        [JsonPropertyName("DDRequestAmount")]
        [DataMember]
        public string DDRequestAmount { get; set; }




    }
    public class HLFLValidateOTPOutput
    {
        [JsonProperty("aggrId")]
        [DataMember]
        public string aggrId { get; set; }

        [JsonProperty("aggrRequestId")]
        [DataMember]
        public string aggrRequestId { get; set; }

        [JsonProperty("hlflRequestId")]
        [DataMember]
        public string hlflRequestId { get; set; }

        [JsonProperty("hlflFacilityNumber")]
        [DataMember]
        public string hlflFacilityNumber { get; set; }

        [JsonProperty("hlflStatusCode")]
        [DataMember]
        public string hlflStatusCode { get; set; }

        [JsonProperty("hlflStatusRemark")]
        [DataMember]
        public string hlflStatusRemark { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }
        

    }
    public class HLFLResendOTPInput
    {
        [JsonPropertyName("Product")]
        [DataMember]
        public string Product { get; set; }

        [Required]
        [JsonPropertyName("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }

        [JsonPropertyName("AggrID")]
        [DataMember]
        public string AggrID { get; set; }

        [JsonPropertyName("HLFLFacilityNumber")]
        [DataMember]
        public string HLFLFacilityNumber { get; set; }

        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

        [JsonPropertyName("AggrControlCardNumber")]
        [DataMember]
        public string AggrControlCardNumber { get; set; }


        [JsonPropertyName("AggrRequestID")]
        [DataMember]
        public string AggrRequestID { get; set; }

        [JsonPropertyName("HLFLRequestID")]
        [DataMember]
        public string HLFLRequestID { get; set; }

        [JsonPropertyName("CustomerOTP")]
        [DataMember]
        public string CustomerOTP { get; set; }

        [JsonPropertyName("DDRequestDate")]
        [DataMember]
        public string DDRequestDate { get; set; }

        [JsonPropertyName("DDRequestAmount")]
        [DataMember]
        public string DDRequestAmount { get; set; }
    }
    public class HLFLResendOTPOutput
    {
        [JsonProperty("aggrId")]
        [DataMember]
        public string aggrId { get; set; }

        [JsonProperty("aggrRequestId")]
        [DataMember]
        public string aggrRequestId { get; set; }

        [JsonProperty("hlflRequestId")]
        [DataMember]
        public string hlflRequestId { get; set; }

        [JsonProperty("hlflFacilityNumber")]
        [DataMember]
        public string hlflFacilityNumber { get; set; }

        [JsonProperty("hlflStatusCode")]
        [DataMember]
        public string hlflStatusCode { get; set; }

        [JsonProperty("hlflStatusRemark")]
        [DataMember]
        public string hlflStatusRemark { get; set; }


    }

    public class CheckIfHLFLUserModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

         
    }

    public class CheckIfHLFLUserModelOutput:HLFLAPIBaseClassOutput
    { 

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

}
