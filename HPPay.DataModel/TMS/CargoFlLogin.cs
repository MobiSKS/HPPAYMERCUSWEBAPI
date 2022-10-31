using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMS
{
    public class CargoFlLogin
    {
        [Required]
        public string cargofl_userid { get; set; }
    }

    public class CargoFlResponse:BaseClassOutput
    {
   
        public string cargofl_userid { get; set; }
        public string message { get; set; }
    }
    public class CargoFlLoginResponse
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
    }
    public class CargoFlRegisterTrucker
    {
        public string name { get; set; }
        public string ownerName { get; set; }
        public string shortname { get; set; }
        public string contactNo { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public string email { get; set; }
        public string pan { get; set; }
        public string gst { get; set; }
        public string dtplus_userid { get; set; }
        public string marketing_officer { get; set; }
        public string regional_office { get; set; }
        public string enrollment_notes { get; set; }


    }
    public class CargoFlRegisterTruckerResponse
    {

    }

        public class ApiRequestResponse
    {
        public string request  { get; set; }
        public string response { get; set; }
        public string apiurl  { get; set; }
        public string UserId { get; set; }
        public string TMSUserId { get; set; }
        public string CustomerId { get; set; }
        public int TMSStatus { get; set; }

    }

    public class AddVehicleAPIRequest
    {
        public string cargofl_userid { get; set; }
        public List<Vehicle> vehicles { get; set; }
    }

    public class Vehicle
    {
        public string vehicleNo { get; set; }
        public string vehicleType { get; set; }
    }





}
