using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public  class InsertVehicleDetailsModelInput:BaseClass
    {

       
        [JsonPropertyName("seatingCapacity")]
        [DataMember]
        public string seatingCapacity { get; set; }

        [JsonPropertyName("taxPaidUpto")]
        [DataMember]
        public string taxPaidUpto { get; set; }

        [JsonPropertyName("vehicleClassDescription")]
        [DataMember]
        public string vehicleClassDescription { get; set; }

        [JsonPropertyName("grossVehicleWeight")]
        [DataMember]
        public string grossVehicleWeight { get; set; }

        [JsonPropertyName("unladenWeight")]
        [DataMember]
        public string unladenWeight { get; set; }

        [JsonPropertyName("permanentAddress")]
        [DataMember]
        public string permanentAddress { get; set; }

        [JsonPropertyName("ownerSerialNumber")]
        [DataMember]
        public string ownerSerialNumber { get; set; }

        [JsonPropertyName("statusAsOn")]
        [DataMember]
        public string statusAsOn { get; set; }

        [JsonPropertyName("wheelbase")]
        [DataMember]
        public string wheelbase { get; set; }

        [JsonPropertyName("registrationDate")]
        [DataMember]
        public string registrationDate { get; set; }

        [JsonPropertyName("fatherName")]
        [DataMember]
        public string fatherName { get; set; }

        [JsonPropertyName("financier")]
        [DataMember]
        public string financier { get; set; }


        [JsonPropertyName("registrationNumber")]
        [DataMember]
        public string registrationNumber { get; set; }

        [JsonPropertyName("chassisNumber")]
        [DataMember]
        public string chassisNumber { get; set; }

        [JsonPropertyName("numberOfCylinders")]
        [DataMember]
        public string numberOfCylinders { get; set; }

        [JsonPropertyName("bodyTypeDescription")]
        [DataMember]
        public string bodyTypeDescription { get; set; }

        [JsonPropertyName("makerDescription")]
        [DataMember]
        public string makerDescription { get; set; }

        [JsonPropertyName("sleeperCapacity")]
        [DataMember]
        public string sleeperCapacity { get; set; }


        [JsonPropertyName("fuelDescription")]
        [DataMember]
        public string fuelDescription { get; set; }


        [JsonPropertyName("makerModel")]
        [DataMember]
        public string makerModel { get; set; }

        [JsonPropertyName("cubicCapacity")]
        [DataMember]
        public string cubicCapacity { get; set; }

        [JsonPropertyName("color")]
        [DataMember]
        public string color { get; set; }


        [JsonPropertyName("ownerName")]
        [DataMember]
        public string ownerName { get; set; }

        [JsonPropertyName("normsDescription")]
        [DataMember]
        public string normsDescription { get; set; }

        [JsonPropertyName("standingCapacity")]
        [DataMember]
        public string standingCapacity { get; set; }

        [JsonPropertyName("insuranceUpto")]
        [DataMember]
        public string insuranceUpto { get; set; }


        [JsonPropertyName("engineNumber")]
        [DataMember]
        public string engineNumber { get; set; }

        [JsonPropertyName("presentAddress")]
        [DataMember]
        public string presentAddress { get; set; }


        [JsonPropertyName("insurancePolicyNumber")]
        [DataMember]
        public string insurancePolicyNumber { get; set; }

        [JsonPropertyName("registeredAt")]
        [DataMember]
        public string registeredAt { get; set; }

        [JsonPropertyName("fitnessUpto")]
        [DataMember]
        public string fitnessUpto { get; set; }


        [JsonPropertyName("manufacturedMonthYear")]
        [DataMember]
        public string manufacturedMonthYear { get; set; }

        [JsonPropertyName("insuranceCompany")]
        [DataMember]
        public string insuranceCompany { get; set; }

        [JsonPropertyName("pucNumber")]
        [DataMember]
        public string pucNumber { get; set; }

        [JsonPropertyName("pucExpiryDate")]
        [DataMember]
        public string pucExpiryDate { get; set; }

        [JsonPropertyName("blackListStatus")]
        [DataMember]
        public string blackListStatus { get; set; }


        [JsonPropertyName("nationalPermitIssuedBy")]
        [DataMember]
        public string nationalPermitIssuedBy { get; set; }


        [JsonPropertyName("nationalPermitNumber")]
        [DataMember]
        public string nationalPermitNumber { get; set; }


        [JsonPropertyName("nationalPermitExpiryDate")]
        [DataMember]
        public string nationalPermitExpiryDate { get; set; }

        [JsonPropertyName("statePermitNumber")]
        [DataMember]
        public string statePermitNumber { get; set; }

        [JsonPropertyName("statePermitType")]
        [DataMember]
        public string statePermitType { get; set; }


        [JsonPropertyName("statePermitIssuedDate")]
        [DataMember]
        public string statePermitIssuedDate { get; set; }

        [JsonPropertyName("statePermitExpiryDate")]
        [DataMember]
        public string statePermitExpiryDate { get; set; }

        [JsonPropertyName("nonUseFrom")]
        [DataMember]
        public string nonUseFrom { get; set; }

        [JsonPropertyName("nocDetails")]
        [DataMember]
        public string nocDetails { get; set; }


        [JsonPropertyName("nonUseTo")]
        [DataMember]
        public string nonUseTo { get; set; }


        [JsonPropertyName("stateCd")]
        [DataMember]
        public string stateCd { get; set; }

        [JsonPropertyName("vehicleCatgory")]
        [DataMember]
        public string vehicleCatgory { get; set; }

        [JsonPropertyName("rcStatus")]
        [DataMember]
        public string rcStatus { get; set; }


        [JsonPropertyName("stautsMessage")]
        [DataMember]
        public string stautsMessage { get; set; }

        [JsonPropertyName("rcMobileNo")]
        [DataMember]
        public string rcMobileNo { get; set; }


        [JsonPropertyName("rcNonUseStatus")]
        [DataMember]
        public string rcNonUseStatus { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class InsertVehicleDetailsModelOutPut:BaseClassOutput
    {      
        

    }
     

    public class Result
    {
        public string seatingCapacity { get; set; }
        public string taxPaidUpto { get; set; }
        public string vehicleClassDescription { get; set; }
        public string grossVehicleWeight { get; set; }
        public string unladenWeight { get; set; }
        public string permanentAddress { get; set; }
        public string ownerSerialNumber { get; set; }
        public string statusAsOn { get; set; }
        public string wheelbase { get; set; }
        public string registrationDate { get; set; }
        public string fatherName { get; set; }
        public string financier { get; set; }
        public string registrationNumber { get; set; }
        public string chassisNumber { get; set; }
        public string numberOfCylinders { get; set; }
        public string bodyTypeDescription { get; set; }
        public string makerDescription { get; set; }
        public string sleeperCapacity { get; set; }
        public string fuelDescription { get; set; }
        public string makerModel { get; set; }
        public string cubicCapacity { get; set; }
        public string color { get; set; }
        public string ownerName { get; set; }
        public string normsDescription { get; set; }
        public string standingCapacity { get; set; }
        public string insuranceUpto { get; set; }
        public string engineNumber { get; set; }
        public string presentAddress { get; set; }
        public string insurancePolicyNumber { get; set; }
        public string registeredAt { get; set; }
        public string fitnessUpto { get; set; }
        public string manufacturedMonthYear { get; set; }
        public string insuranceCompany { get; set; }
        public string pucNumber { get; set; }
        public string pucExpiryDate { get; set; }
        public string blackListStatus { get; set; }
        public string nationalPermitIssuedBy { get; set; }
        public string nationalPermitNumber { get; set; }
        public string nationalPermitExpiryDate { get; set; }
        public string statePermitNumber { get; set; }
        public string statePermitType { get; set; }
        public string statePermitIssuedDate { get; set; }
        public string statePermitExpiryDate { get; set; }
        public string nonUseFrom { get; set; }
        public string nocDetails { get; set; }
        public string nonUseTo { get; set; }
        public string stateCd { get; set; }
        public string vehicleCatgory { get; set; }
        public string rcStatus { get; set; }
        public string stautsMessage { get; set; }
        public string rcMobileNo { get; set; }
        public string rcNonUseStatus { get; set; }
        public List<object> blackListInfo { get; set; }
    }

    public class Root
    {
        public string requestId { get; set; }
        public Result result { get; set; }
        public int statusCode { get; set; }
    }
}
