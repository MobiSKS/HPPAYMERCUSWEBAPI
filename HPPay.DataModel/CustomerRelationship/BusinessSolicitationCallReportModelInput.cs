using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{
        public class BusinessSolicitationCallReportModelInput : BaseClass
        {
            [Required]
            [JsonPropertyName("TrackId")]
            [DataMember]
            public int TrackId { get; set; }
        }
        public class BusinessSolicitationCallReportModelOutput:BaseClassOutput
    {

            [JsonPropertyName("BusinessSolicitationCallReport")]
            [DataMember]
            public List<BusinessSolicitationCallReport> BusinessSolicitationCallReport { get; set; }



            [JsonPropertyName("BusinessSolicitationAreaofOperation")]
            [DataMember]
            public List<BusinessSolicitationAreaofOperation> BusinessSolicitationAreaofOperation { get; set; }



            [JsonPropertyName("BusinessSolicitationMapping")]
            [DataMember]
            public List<BusinessSolicitationMapping> BusinessSolicitationMapping { get; set; }



            [JsonPropertyName("BusinessSolicitationMeetingRemark")]
            [DataMember]
            public List<BusinessSolicitationMeetingRemark> BusinessSolicitationMeetingRemark { get; set; }


        }

        public class BusinessSolicitationCallReport
        {
            [JsonPropertyName("TrackId")]
            [DataMember]
            public int TrackId { get; set; }

            [JsonPropertyName("PreviousVisit")]
            [DataMember]
            public string PreviousVisit { get; set; }

            [JsonPropertyName("CustomerName")]
            [DataMember]
            public string CustomerName { get; set; }

            [JsonPropertyName("ZonalOffice")]
            [DataMember]
            public int ZonalOffice { get; set; }

            [JsonPropertyName("RegionalOffice")]
            [DataMember]
            public int RegionalOffice { get; set; }

            [JsonPropertyName("SalesSrea")]
            [DataMember]
            public int SalesSrea { get; set; }

            [JsonPropertyName("Address1")]
            [DataMember]
            public string Address1 { get; set; }

            [JsonPropertyName("Address2")]
            [DataMember]
            public string Address2 { get; set; }

            [JsonPropertyName("Address3")]
            [DataMember]
            public string Address3 { get; set; }

            [JsonPropertyName("Location")]
            [DataMember]
            public string Location { get; set; }

            [JsonPropertyName("City")]
            [DataMember]
            public string City { get; set; }

            [JsonPropertyName("Pincode")]
            [DataMember]
            public string Pincode { get; set; }

            [JsonPropertyName("State")]
            [DataMember]
            public int State { get; set; }

            [JsonPropertyName("District")]
            [DataMember]
            public int District { get; set; }

            [JsonPropertyName("CustomerPhoneCode")]
            [DataMember]
            public string CustomerPhoneCode { get; set; }

            [JsonPropertyName("CustomerPhoneNo")]
            [DataMember]
            public string CustomerPhoneNo { get; set; }

            [JsonPropertyName("CustomerFaxCode")]
            [DataMember]
            public string CustomerFaxCode { get; set; }

            [JsonPropertyName("CustomerFaxNumber")]
            [DataMember]
            public string CustomerFaxNumber { get; set; }

            [JsonPropertyName("Mobile")]
            [DataMember]
            public string Mobile { get; set; }

            [JsonPropertyName("Email")]
            [DataMember]
            public string Email { get; set; }

            [JsonPropertyName("CustomerCategory")]
            [DataMember]
            public int CustomerCategory { get; set; }

            [JsonPropertyName("Fleetsize")]
            [DataMember]
            public int Fleetsize { get; set; }

            [JsonPropertyName("HSD")]
            [DataMember]
            public decimal HSD { get; set; }


            [JsonPropertyName("MS")]
            [DataMember]
            public decimal MS { get; set; }

            [JsonPropertyName("Lube")]
            [DataMember]
            public decimal Lube { get; set; }

            [JsonPropertyName("CustomerType")]
            [DataMember]
            public int CustomerType { get; set; }

            [JsonPropertyName("CustomerSubType")]
            [DataMember]
            public int CustomerSubType { get; set; }

            [JsonPropertyName("KeyOfficialFirstName")]
            [DataMember]
            public string KeyOfficialFirstName { get; set; }

            [JsonPropertyName("KeyOfficialMiddleName")]
            [DataMember]
            public string KeyOfficialMiddleName { get; set; }

            [JsonPropertyName("KeyOfficialLastName")]
            [DataMember]
            public string KeyOfficialLastName { get; set; }

            [JsonPropertyName("KeyOfficialDesignation")]
            [DataMember]
            public string KeyOfficialDesignation { get; set; }

            [JsonPropertyName("KeyOfficialPhoneCode")]
            [DataMember]
            public string KeyOfficialPhoneCode { get; set; }

            [JsonPropertyName("KeyOfficialContactNo")]
            [DataMember]
            public string KeyOfficialContactNo { get; set; }

            [JsonPropertyName("KeyOfficialMobile")]
            [DataMember]
            public string KeyOfficialMobile { get; set; }


            [JsonPropertyName("KeyOfficialEmail")]
            [DataMember]
            public string KeyOfficialEmail { get; set; }

            [JsonPropertyName("KeyOfficialAlterMobile")]
            [DataMember]
            public string KeyOfficialAlterMobile { get; set; }


            [JsonPropertyName("TypeOfBusinessEntity")]
            [DataMember]
            public int TypeOfBusinessEntity { get; set; }


            [JsonPropertyName("SegmentServed")]
            [DataMember]
            public int SegmentServed { get; set; }


            [JsonPropertyName("UsageType")]
            [DataMember]
            public int UsageType { get; set; }

            [JsonPropertyName("NoOfDays")]
            [DataMember]
            public int NoOfDays { get; set; }


            [JsonPropertyName("ActionPlanforEnrollment")]
            [DataMember]
            public string ActionPlanforEnrollment { get; set; }


            [JsonPropertyName("EnrollmentExpectedby")]
            [DataMember]
            public string EnrollmentExpectedby { get; set; }


            [JsonPropertyName("PaymenttermsType")]
            [DataMember]
            public int PaymenttermsType { get; set; }


            [JsonPropertyName("Paymenttermsmode")]
            [DataMember]
            public int Paymenttermsmode { get; set; }

        }


        public class BusinessSolicitationAreaofOperation
        {
            [JsonPropertyName("Id")]
            [DataMember]
            public int Id { get; set; }

            [JsonPropertyName("TrackID")]
            [DataMember]
            public int TrackID { get; set; }

            [JsonPropertyName("Routes")]
            [DataMember]
            public string Routes { get; set; }

            [JsonPropertyName("RouteFrom")]
            [DataMember]
            public string RouteFrom { get; set; }

            [JsonPropertyName("RouteTo")]
            [DataMember]
            public string RouteTo { get; set; }

            [JsonPropertyName("NHNO")]
            [DataMember]
            public int NHNO { get; set; }
        }
        public class BusinessSolicitationMapping
        {
            [JsonPropertyName("Id")]
            [DataMember]
            public int Id { get; set; }

            [JsonPropertyName("TrackID")]
            [DataMember]
            public int TrackID { get; set; }

            [JsonPropertyName("MappingLocation")]
            [DataMember]
            public string MappingLocation { get; set; }

            [JsonPropertyName("CurrentSupplier")]
            [DataMember]
            public string CurrentSupplier { get; set; }

            [JsonPropertyName("LHSANDRHS")]
            [DataMember]
            public int LHSANDRHS { get; set; }

            [JsonPropertyName("Zone")]
            [DataMember]
            public int Zone { get; set; }

            [JsonPropertyName("Region")]
            [DataMember]
            public int Region { get; set; }

            [JsonPropertyName("CreditExpected")]
            [DataMember]
            public decimal CreditExpected { get; set; }

            [JsonPropertyName("DiscountExpected")]
            [DataMember]
            public decimal DiscountExpected { get; set; }

            [JsonPropertyName("NoOfDays")]
            [DataMember]
            public int NoOfDays { get; set; }

        }

        public class BusinessSolicitationMeetingRemark
        {
            [JsonPropertyName("Id")]
            [DataMember]
            public int Id { get; set; }

            [JsonPropertyName("TrackID")]
            [DataMember]
            public int TrackID { get; set; }

            [JsonPropertyName("MeetingDate")]
            [DataMember]
            public string MeetingDate { get; set; }

            [JsonPropertyName("MeetingRemark")]
            [DataMember]
            public string MeetingRemark { get; set; }
        }
    }

