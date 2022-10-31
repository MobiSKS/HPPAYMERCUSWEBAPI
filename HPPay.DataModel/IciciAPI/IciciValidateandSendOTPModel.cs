using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.IciciAPI
{

    public class IciciValidateandSendOTPModelInput:BaseClass
    {
        public string VehicleNumber { get; set; }
        public string MobileNumber { get; set; }

    }

    public class IciciValidateandSendOTPModelOutput : BaseClassOutput
    {
        public string VehicleNumber { get; set; }
        public string MobileNumber { get; set; }

    }
    public class IciciValidateandSendOTPRequest
    {
        public string VehicleNumber { get; set; }
        public string MobileNumber { get; set; }
    
    }

    public class IciciValidateandSendOTPResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsOTPGenerated { get; set; }
        public string CustomerId { get; set; }
        public Int64 TagAccountNumber { get; set; }
        public string HexTagId { get; set; }
        public string OTPExpiryTime { get; set; }
        public int IssuerId { get; set; }
        public List<string> Messages { get; set; }
    }

    public class IciciConfirmOTPRequest
    {
        public string CustomerId { get; set; }
        public string VehcileNumber { get; set; }
        public string MobileNumber { get; set; }
        public string OTP { get; set; }


    }

    public class IciciConfirmOTPResponse
    {
        public bool IsValidOTP { get; set; }
        public bool IsSuccess { get; set; }

        public List<string> Messages { get; set; }
    }

}
