using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace HPPay.Infrastructure.Response
{
    [Serializable]
    [DataContract]
    public class ApiResponseMessage
    {
        #region Public properties.
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>
        [JsonProperty("Success")]
        [DataMember]
        public bool Success { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>
        [JsonProperty("Status_Code")]
        [DataMember]
        public int Status_Code { get; set; }

        [JsonProperty("Internel_Status_Code")]
        [DataMember]
        public int Internel_Status_Code { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("Message")]
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("Method_Name")]
        [DataMember]
        public string Method_Name { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("Data")]
        [DataMember]
        public object Data { get; set; }

        [JsonProperty("Model_State")]
        [DataMember]
        public ModelStateDictionary Model_State { get; set; }


        #endregion
    }


    [Serializable]
    [DataContract]
    public class ApiErrorResponseMessage
    {
        #region Public properties.
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>

        [DataMember]
        public bool Success { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>

        [DataMember]
        public int Status_Code { get; set; }


        //[DataMember]
        //public int Internel_Status_Code { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>

        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        /// 

        [DataMember]
        public string Error_Message { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>

        [DataMember]
        public int Error_Code { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>

        [DataMember]
        public string Method_Name { get; set; }

        [DataMember]
        public int Internel_Status_Code { get; set; }
        
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>

        [DataMember]
        public object Data { get; set; }


        #endregion
    }

}
