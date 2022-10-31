using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class BankCreditLimitRequestModelInput:BaseClass
    {

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("ObjTypeBankCreditLimit")]
        [DataMember]
        public List<TypeBankCreditLimit> ObjTypeBankCreditLimit { get; set; }

    }



    public class TypeBankCreditLimit
    {
        //CustomerID,CCMSRechargeType,RequestedCreditLimit  
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonPropertyName("CCMSRechargeType")]
        [DataMember]
        public string CCMSRechargeType { get; set; }


        [JsonPropertyName("RequestedCreditLimit")]
        [DataMember]
        public string RequestedCreditLimit { get; set; }
    }


    public class BankCreditLimitRequestModelOutput : BaseClassOutput
    {

      

    }

}
