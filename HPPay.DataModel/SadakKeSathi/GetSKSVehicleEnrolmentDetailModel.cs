using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SadakKeSathi
{

    public class GetSKSVehicleDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetSKSVehicleDetailModelOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonPropertyName("Points")]
        [DataMember]
        public string Points { get; set; }
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }
        [JsonPropertyName("vehicleNo")]
        [DataMember]
        public string vehicleNo { get; set; }
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

    }
    public class GetSKSVehicleEnrolmentDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetSKSVehicleEnrolmentDetailModelOutput : BaseClassOutput
    {
        [JsonPropertyName("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }
               
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }
        [JsonPropertyName("EnrollmentType")]
        [DataMember]
        public string EnrollmentType { get; set; }
        [JsonPropertyName("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonPropertyName("EffectiveFrom")]
        [DataMember]
        public string EffectiveFrom { get; set; }

        [JsonPropertyName("EnrollmentStatus")]
        [DataMember]
        public string EnrollmentStatus { get; set; }

    }

    public class GetSKSChargesPerVehicleModelInput : BaseClass
    {
    }

        public class GetSKSChargesPerVehicleModelOutput : BaseClassOutput
    {
        [JsonPropertyName("ServiceCharge")]
        [DataMember]
        public decimal ServiceCharge { get; set; }
    }

    

    public class InsertSKSVehicleEnrolmentDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("AvailedPoints")]
        [DataMember]
     
        public string AvailedPoints { get; set; }

        [JsonPropertyName("TotalAmount")]
        [DataMember]
        public decimal TotalAmount { get; set; }

        public List<SKSVehicle> SKSVehicles { get; set; }

    }

    public class InsertSKSVehicleEnrolmentDetailModelOutput : BaseClassOutput
    {

    }

    public class SKSVehicle
    {
        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [Required]
        [JsonPropertyName("ServicePeriod")]
        [DataMember]
        public int ServicePeriod { get; set; }

    }
}
