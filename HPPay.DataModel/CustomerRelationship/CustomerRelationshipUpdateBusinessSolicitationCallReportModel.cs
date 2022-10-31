
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{

        public class CustomerRelationshipUpdateBusinessSolicitationCallReportModelInput : BaseClass
        {
            [Required]
            [JsonPropertyName("TrackId")]
            [DataMember]
            public string TrackId { get; set; }


            [Required]
            [JsonPropertyName("CustomerName")]
            [DataMember]
            public string CustomerName { get; set; }

            [Required]
            [JsonPropertyName("ZonalOffice")]
            [DataMember]
            public int ZonalOffice { get; set; }

            [Required]
            [JsonPropertyName("RegionalOffice")]
            [DataMember]
            public int RegionalOffice { get; set; }

            [Required]
            [JsonPropertyName("SalesSrea")]
            [DataMember]
            public int SalesSrea { get; set; }

            [Required]
            [JsonPropertyName("Address1")]
            [DataMember]
            public string Address1 { get; set; }

            [Required]
            [JsonPropertyName("Address2")]
            [DataMember]
            public string Address2 { get; set; }


            [JsonPropertyName("Address3")]
            [DataMember]
            public string Address3 { get; set; }


            [JsonPropertyName("Location")]
            [DataMember]
            public string Location { get; set; }

            [Required]
            [JsonPropertyName("City")]
            [DataMember]
            public string City { get; set; }

            [Required]
            [JsonPropertyName("Pincode")]
            [DataMember]
            public string Pincode { get; set; }

            [Required]
            [JsonPropertyName("State")]
            [DataMember]
            public int State { get; set; }

            [Required]
            [JsonPropertyName("District")]
            [DataMember]
            public int District { get; set; }

            [Required]
            [JsonPropertyName("PhoneCode")]
            [DataMember]
            public string PhoneCode { get; set; }

            [Required]
            [JsonPropertyName("PhoneNo")]
            [DataMember]
            public string PhoneNo { get; set; }


            [JsonPropertyName("FaxCode")]
            [DataMember]
            public string FaxCode { get; set; }


            [JsonPropertyName("Fax")]
            [DataMember]
            public string Fax { get; set; }

            [Required]
            [JsonPropertyName("MobileNo")]
            [DataMember]
            public string MobileNo { get; set; }

            [Required]
            [JsonPropertyName("Email")]
            [DataMember]
            public string Email { get; set; }


            [Required]
            [JsonPropertyName("CustomerCategory")]
            [DataMember]
            public int CustomerCategory { get; set; }


            [JsonPropertyName("Fleetsize")]
            [DataMember]
            public int Fleetsize { get; set; }

            [Required]
            [JsonPropertyName("HSD")]
            [DataMember]
            public decimal HSD { get; set; }

            [Required]
            [JsonPropertyName("MS")]
            [DataMember]
            public decimal MS { get; set; }

            [Required]
            [JsonPropertyName("Lube")]
            [DataMember]
            public decimal Lube { get; set; }

            [Required]
            [JsonPropertyName("CustomerType")]
            [DataMember]
            public int CustomerType { get; set; }

            [Required]
            [JsonPropertyName("CustomerSubType")]
            [DataMember]
            public int CustomerSubType { get; set; }

            [Required]
            [JsonPropertyName("KeyOfficialFirstName")]
            [DataMember]
            public string KeyOfficialFirstName { get; set; }

            [Required]
            [JsonPropertyName("KeyOfficialMiddleName")]
            [DataMember]
            public string KeyOfficialMiddleName { get; set; }

            [Required]
            [JsonPropertyName("KeyOfficialLastName")]
            [DataMember]
            public string KeyOfficialLastName { get; set; }

            [JsonPropertyName("KeyOfficialDesignation")]
            [DataMember]
            public string KeyOfficialDesignation { get; set; }


            [JsonPropertyName("KeyOfficialPhoneCode")]
            [DataMember]
            public string KeyOfficialPhoneCode { get; set; }


            [JsonPropertyName("KeyOfficialPhoneNo")]
            [DataMember]
            public string KeyOfficialPhoneNo { get; set; }

            [Required]
            [JsonPropertyName("KeyOfficialMobile")]
            [DataMember]
            public string KeyOfficialMobile { get; set; }

            [Required]
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


            [JsonPropertyName("CreatedBy")]
            [DataMember]
            public string CreatedBy { get; set; }


            [JsonPropertyName("CreatedTime")]
            [DataMember]
            public string CreatedTime { get; set; }

            [JsonPropertyName("TypeAreaOperation")]
            [DataMember]
            public List<TypeAreaOperation> TypeAreaOperation { get; set; }


            [JsonPropertyName("TypeMappingSolicitation")]
            [DataMember]
            public List<TypeMappingSolicitation> TypeMappingSolicitation { get; set; }


            [JsonPropertyName("TypeRemarkBusinessSolicitation")]
            [DataMember]
            public List<TypeRemarkBusinessSolicitation> TypeRemarkBusinessSolicitation { get; set; }
        }

        public class TypeAreaOperation
        {

            [JsonPropertyName("ID")]
            [DataMember]
            public int ID { get; set; }

            [JsonPropertyName("TrackId")]
            [DataMember]
            public int TrackId { get; set; }

            [Required]
            [JsonPropertyName("Routes")]
            [DataMember]
            public string Routes { get; set; }

            [Required]
            [JsonPropertyName("RouteFrom")]
            [DataMember]
            public string RouteFrom { get; set; }

            [Required]
            [JsonPropertyName("RouteTo")]
            [DataMember]
            public string RouteTo { get; set; }

            [Required]
            [JsonPropertyName("NHNO")]
            [DataMember]
            public decimal NHNO { get; set; }
        }

        public class TypeMappingSolicitation
        {
            [JsonPropertyName("ID")]
            [DataMember]
            public int ID { get; set; }


            [JsonPropertyName("TrackId")]
            [DataMember]
            public int TrackId { get; set; }

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

        public class TypeRemarkBusinessSolicitation
        {
            [JsonPropertyName("ID")]
            [DataMember]
            public int ID { get; set; }

            [JsonPropertyName("TrackId")]
            [DataMember]
            public int TrackId { get; set; }

            [Required]
            [JsonPropertyName("MeetingDate")]
            [DataMember]
            public string MeetingDate { get; set; }

            [Required]
            [JsonPropertyName("MeetingRemark")]
            [DataMember]
            public string MeetingRemark { get; set; }
        }
        public class CustomerRelationshipUpdateBusinessSolicitationCallReportModelOutput : BaseClassOutput
        {

        }
    }

