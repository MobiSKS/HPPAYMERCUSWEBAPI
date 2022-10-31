using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.CommonValidations
{
    public class VehicleRegistrationValidateRequestModel
    {
        public string registrationNumber { get; set; }
        public string consent { get; set; }
        public string version { get; set; }
    }
}
