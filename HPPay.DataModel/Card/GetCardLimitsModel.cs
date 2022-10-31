using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class GetCardLimitsModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        //[Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        //[Required]
        [JsonPropertyName("Statusflag")]
        [DataMember]
        public Int32 Statusflag { get; set; }

    }
    public class GetCardLimitsModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }


        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }


        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }


        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public Int32 YearOfRegistration { get; set; }


        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }


        [JsonProperty("CashPurseLimit")]
        [DataMember]
        public decimal CashPurseLimit { get; set; }

        [JsonProperty("SaleTxnLimit")]
        [DataMember]
        public decimal SaleTxnLimit { get; set; }

        [JsonProperty("DailySaleLimit")]
        [DataMember]
        public decimal DailySaleLimit { get; set; }

        [JsonProperty("MonthlySaleLimit")]
        [DataMember]
        public decimal MonthlySaleLimit { get; set; }

    }


    public class ViewCardLimitsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }
         
    }

    public class ViewCardLimitsModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }


        [JsonProperty("DailySaleLimit")]
        [DataMember]
        public decimal DailySaleLimit { get; set; }


        [JsonProperty("DailySaleBal")]
        [DataMember]
        public decimal DailySaleBal { get; set; }


        [JsonProperty("MonthlySaleLimit")]
        [DataMember]
        public decimal MonthlySaleLimit { get; set; }


        [JsonProperty("MonthlySaleBal")]
        [DataMember]
        public decimal MonthlySaleBal { get; set; }


        [JsonProperty("CCMSLimit")]
        [DataMember]
        public string CCMSLimit { get; set; }

        [JsonProperty("LimitType")]
        [DataMember]
        public string LimitType { get; set; }


        [JsonProperty("AvailableCCMSLimit")]
        [DataMember]
        public string AvailableCCMSLimit { get; set; }


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("SaleTransLimt")]
        [DataMember]
        public decimal SaleTransLimt { get; set; }

    }
    public class GetCardLimitsByVehicleNoModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        //[Required]
        [JsonPropertyName("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        ////[Required]
        //[JsonPropertyName("Mobileno")]
        //[DataMember]
        //public string Mobileno { get; set; }


        //[Required]
        [JsonPropertyName("Statusflag")]
        [DataMember]
        public Int32 Statusflag { get; set; }

    }
    public class GetCardLimitsByVehicleNoModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }


        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }


        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }


        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public Int32 YearOfRegistration { get; set; }


        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }


        [JsonProperty("CashPurseLimit")]
        [DataMember]
        public decimal CashPurseLimit { get; set; }

        [JsonProperty("SaleTxnLimit")]
        [DataMember]
        public decimal SaleTxnLimit { get; set; }

        [JsonProperty("DailySaleLimit")]
        [DataMember]
        public decimal DailySaleLimit { get; set; }

        [JsonProperty("MonthlySaleLimit")]
        [DataMember]
        public decimal MonthlySaleLimit { get; set; }

    }
    public class GetVehicleDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }


    }

    public class GetVehicleDetailsModelOutput:BaseClassOutput
    {
        [JsonProperty("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [JsonProperty("OwnerName")]
        [DataMember]
        public string OwnerName { get; set; }

        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("RegistrationDate")]
        [DataMember]
        public string RegistrationDate { get; set; }

        [JsonProperty("MakerModel")]
        [DataMember]
        public string MakerModel { get; set; }

        [JsonProperty("FuelType")]
        [DataMember]
        public string FuelType { get; set; }


        [JsonProperty("InsuranceUpto")]
        [DataMember]
        public string InsuranceUpto { get; set; }

        [JsonProperty("FitnessUpto")]
        [DataMember]
        public string FitnessUpto { get; set; }

        [JsonProperty("VehicleCatgory")]
        [DataMember]
        public string VehicleCatgory { get; set; }


        [JsonProperty("RcStatus")]
        [DataMember]
        public string RcStatus { get; set; }
    }
    

}
