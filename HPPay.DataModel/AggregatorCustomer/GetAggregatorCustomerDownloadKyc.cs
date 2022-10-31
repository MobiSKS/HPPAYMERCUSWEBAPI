using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.AggregatorCustomer
{
    public class GetAggregatorNormalFleetCustomerDownloadKycModelInput : BaseClass
    {
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }
    }
    public class GetAggregatorNormalFleetCustomerDownloadKycModelOutput
    {


        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }


        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [JsonProperty("AddressProofTypeId")]
        [DataMember]
        public Int32 AddressProofTypeId { get; set; }


        [JsonProperty("AddressProofTypeName")]
        [DataMember]
        public string AddressProofTypeName { get; set; }



        [JsonProperty("CustomerAddressProof")]
        [DataMember]
        public string CustomerAddressProof { get; set; }


        [JsonProperty("IdProofTypeId")]
        [DataMember]
        public Int32 IdProofTypeId { get; set; }


        [JsonProperty("IdProofTypeName")]
        [DataMember]
        public string IdProofTypeName { get; set; }



        [JsonProperty("IDProofofOwnerPartner")]
        [DataMember]
        public string IDProofofOwnerPartner { get; set; }



        [JsonProperty("PanCardTypeId")]
        [DataMember]
        public Int32 PanCardTypeId { get; set; }


        [JsonProperty("PanCardTypeName")]
        [DataMember]
        public string PanCardTypeName { get; set; }



        [JsonProperty("PANCarddetails")]
        [DataMember]
        public string PANCarddetails { get; set; }

        [JsonProperty("VehicleDetailsTypeId")]
        [DataMember]
        public Int32 VehicleDetailsTypeId { get; set; }


        [JsonProperty("VehicleDetailsTypeName")]
        [DataMember]
        public string VehicleDetailsTypeName { get; set; }



        [JsonProperty("VehicleDetails")]
        [DataMember]
        public string VehicleDetails { get; set; }

        [JsonProperty("CustomerFormTypeId")]
        [DataMember]
        public Int32 CustomerFormTypeId { get; set; }


        [JsonProperty("CustomerFormTypeName")]
        [DataMember]
        public string CustomerFormTypeName { get; set; }



        [JsonProperty("SignedCustomerForm")]
        [DataMember]
        public string SignedCustomerForm { get; set; }

    }

}
