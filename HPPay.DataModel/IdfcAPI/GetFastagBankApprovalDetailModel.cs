using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class GetFastagBankApprovalDetailModelInput:BaseClass
    {

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

    }

    public class GetFastagBankApprovalDetailModelOutput : BaseClassOutput
    {

        //[JsonProperty("Customerid")]
        //[DataMember]
        //public string Customerid { get; set; }



        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }


        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }



        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }


        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }



        [JsonProperty("Requestedby")]
        [DataMember]
        public string Requestedby { get; set; }



        [JsonProperty("comments")]
        [DataMember]
        public string comments { get; set; }






        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }



        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }



        [JsonProperty("IdProofTypeId")]
        [DataMember]
        public string IdProofTypeId { get; set; }



        [JsonProperty("IdProofTypeName")]
        [DataMember]
        public string IdProofTypeName { get; set; }



        [JsonProperty("IdProofDocumentNo")]
        [DataMember]
        public string IdProofDocumentNo { get; set; }



        [JsonProperty("IdProofFront")]
        [DataMember]
        public string IdProofFront { get; set; }



        [JsonProperty("IdProofBack")]
        [DataMember]
        public string IdProofBack { get; set; }



        [JsonProperty("AddressProofTypeId")]
        [DataMember]
        public string AddressProofTypeId { get; set; }



        [JsonProperty("AddressProofTypeName")]
        [DataMember]
        public string AddressProofTypeName { get; set; }



        [JsonProperty("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }


        [JsonProperty("AddressProofFront")]
        [DataMember]
        public string AddressProofFront { get; set; }


        [JsonProperty("AddressProofBack")]
        [DataMember]
        public string AddressProofBack { get; set; }



    }


}
