using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SMSGetSend
{

    public class SMSGetInputModel : BaseClass
    {

    }

    public class SMSGetOutputModel
    {
        [JsonPropertyName("TemplateName")]
        [DataMember]
        public string TemplateName { get; set; }

        [JsonPropertyName("TemplateType")]
        [DataMember]
        public string TemplateType { get; set; }

        [JsonPropertyName("TemplateMessage")]
        [DataMember]
        public string TemplateMessage { get; set; }

        [JsonPropertyName("CTID")]
        [DataMember]
        public string CTID { get; set; }
    }

    public class SMSSendInputModel : BaseClass
    {

        [JsonPropertyName("CTID")]
        [DataMember]
        public string CTID { get; set; }

    }

    public class SMSSendOutputModel
    {
        [JsonProperty("SenderId")]
        [DataMember]
        public string SenderId { get; set; }

        [JsonProperty("SMSAPIURL")]
        [DataMember]
        public string SMSAPIURL { get; set; }

        [JsonProperty("SMSText")]
        [DataMember]
        public string SMSText { get; set; }

        [JsonProperty("HeaderTemplate")]
        [DataMember]
        public string HeaderTemplate { get; set; }
    }

    public class InsertSMSTextEntryInputModel : BaseClass
    {

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("HeaderTemplate")]
        [DataMember]
        public string HeaderTemplate { get; set; }

        [JsonPropertyName("CTID")]
        [DataMember]
        public string CTID { get; set; }

        [JsonPropertyName("SMSText")]
        [DataMember]
        public string SMSText { get; set; }

        [JsonPropertyName("SMSStatus")]
        [DataMember]
        public string SMSStatus { get; set; }

        [JsonPropertyName("SMSStatusDesc")]
        [DataMember]
        public string SMSStatusDesc { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class InsertSMSTextEntryOutputModel : BaseClassOutput
    {

    }


    public class GetandInsertSendInputModel : BaseClass
    {
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("HeaderTemplate")]
        [DataMember]
        public string HeaderTemplate { get; set; }

        [JsonPropertyName("CTID")]
        [DataMember]
        public string CTID { get; set; }

        [JsonPropertyName("SMSText")]
        [DataMember]
        public string SMSText { get; set; }
         

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("OfficerMobileNo")]
        [DataMember]
        public string OfficerMobileNo { get; set; }

        [JsonPropertyName("SenderId")]
        [DataMember]
        public string SenderId { get; set; }

        [JsonPropertyName("SMSAPIURL")]
        [DataMember]
        public string SMSAPIURL { get; set; }
    }

    public class GetandInsertSendOutputModel : BaseClassOutput
    {
        [JsonPropertyName("SenderId")]
        [DataMember]
        public string SenderId { get; set; }

        [JsonPropertyName("SMSAPIURL")]
        [DataMember]
        public string SMSAPIURL { get; set; }

    }


    public class GetSMSValueInputModel : BaseClass
    {

        [JsonPropertyName("MethodName")]
        [DataMember]
        public string MethodName { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("EmailIdTo")]
        [DataMember]
        public string EmailIdTo { get; set; }

        [JsonPropertyName("SMSText")]
        [DataMember]
        public string SMSText { get; set; }

        [JsonPropertyName("EmailText")]
        [DataMember]
        public string EmailText { get; set; }



    }

    public class GetSMSValueOutputModel : BaseClassOutput
    {
        [JsonProperty("TemplateName")]
        [DataMember]
        public string TemplateName { get; set; }

        [JsonProperty("CTID")]
        [DataMember]
        public string CTID { get; set; }

        [JsonProperty("TemplateMessage")]
        [DataMember]
        public string TemplateMessage { get; set; }

        [JsonProperty("Header")]
        [DataMember]
        public string Header { get; set; }

        [JsonProperty("EmailTemplateMessage")]
        [DataMember]
        public string EmailTemplateMessage { get; set; }

        [JsonProperty("EmailStatus")]
        [DataMember]
        public Int16 EmailStatus { get; set; }

        [JsonProperty("SMSStatus")]
        [DataMember]
        public Int16 SMSStatus { get; set; }

        [JsonProperty("FromEmail")]
        [DataMember]
        public string FromEmail { get; set; }

        [JsonProperty("Host")]
        [DataMember]
        public string Host { get; set; }

        [JsonProperty("HostPWd")]
        [DataMember]
        public string HostPWd { get; set; }

        [JsonProperty("EmailTemplateSubject")]
        [DataMember]
        public string EmailTemplateSubject { get; set; }

        [JsonProperty("OfficerMobileNo")]
        [DataMember]
        public string OfficerMobileNo { get; set; }

        [JsonProperty("OfficerCCEmailId")]
        [DataMember]
        public string OfficerCCEmailId { get; set; }

        [JsonProperty("OfficerBCCEmailId")]
        [DataMember]
        public string OfficerBCCEmailId { get; set; }

        [JsonProperty("SenderId")]
        [DataMember]
        public string SenderId { get; set; }

        [JsonProperty("SMSAPIURL")]
        [DataMember]
        public string SMSAPIURL { get; set; }

        [JsonProperty("SMSEmailStatus")]
        [DataMember]
        public string SMSEmailStatus { get; set; }
    }


    public class InsertEmailTextEntryInputModel : BaseClass
    {
         

        [JsonPropertyName("Host")]
        [DataMember]
        public string Host { get; set; }

        [JsonPropertyName("HostPWd")]
        [DataMember]
        public string HostPWd { get; set; }

        [JsonPropertyName("EmailIdFrom")]
        [DataMember]
        public string EmailIdFrom { get; set; }

        [JsonPropertyName("EmailIdTo")]
        [DataMember]
        public string EmailIdTo { get; set; }

        [JsonPropertyName("EmailIdCC")]
        [DataMember]
        public string EmailIdCC { get; set; }

        [JsonPropertyName("EmailIdBCC")]
        [DataMember]
        public string EmailIdBCC { get; set; }

        [JsonPropertyName("Subject")]
        [DataMember]
        public string Subject { get; set; }

        [JsonPropertyName("EmailTemplate")]
        [DataMember]
        public string EmailTemplate { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class InsertEmailTextEntryOutputModel : BaseClassOutput
    {

    }

    public class GetDetailsSMSValueInputModel : BaseClass
    {

        [JsonPropertyName("MethodName")]
        [DataMember]
        public string MethodName { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("EmailIdTo")]
        [DataMember]
        public string EmailIdTo { get; set; }

        [JsonPropertyName("SMSText")]
        [DataMember]
        public string SMSText { get; set; }

        [JsonPropertyName("EmailText")]
        [DataMember]
        public string EmailText { get; set; }

        [JsonPropertyName("APIRefNo")]
        [DataMember]
        public string APIRefNo { get; set; }

    }

    public class GetDetailsSMSValueOutputModel : BaseClassOutput
    {
        [JsonProperty("TemplateName")]
        [DataMember]
        public string TemplateName { get; set; }

        [JsonProperty("CTID")]
        [DataMember]
        public string CTID { get; set; }

        [JsonProperty("TemplateMessage")]
        [DataMember]
        public string TemplateMessage { get; set; }

        [JsonProperty("Header")]
        [DataMember]
        public string Header { get; set; }

        [JsonProperty("EmailTemplateMessage")]
        [DataMember]
        public string EmailTemplateMessage { get; set; }

        [JsonProperty("EmailStatus")]
        [DataMember]
        public Int16 EmailStatus { get; set; }

        [JsonProperty("SMSStatus")]
        [DataMember]
        public Int16 SMSStatus { get; set; }

        [JsonProperty("FromEmail")]
        [DataMember]
        public string FromEmail { get; set; }

        [JsonProperty("Host")]
        [DataMember]
        public string Host { get; set; }

        [JsonProperty("HostPWd")]
        [DataMember]
        public string HostPWd { get; set; }

        [JsonProperty("EmailTemplateSubject")]
        [DataMember]
        public string EmailTemplateSubject { get; set; }

        [JsonProperty("OfficerMobileNo")]
        [DataMember]
        public string OfficerMobileNo { get; set; }

        [JsonProperty("OfficerCCEmailId")]
        [DataMember]
        public string OfficerCCEmailId { get; set; }

        [JsonProperty("OfficerBCCEmailId")]
        [DataMember]
        public string OfficerBCCEmailId { get; set; }

        [JsonProperty("SenderId")]
        [DataMember]
        public string SenderId { get; set; }

        [JsonProperty("SMSAPIURL")]
        [DataMember]
        public string SMSAPIURL { get; set; }

        [JsonProperty("SMSEmailStatus")]
        [DataMember]
        public string SMSEmailStatus { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }


        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

}

    