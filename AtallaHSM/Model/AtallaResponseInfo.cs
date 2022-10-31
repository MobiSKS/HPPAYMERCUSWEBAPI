using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtallaHSM.Model
{

    public class KeySetInfo
    {
        private string key;
        private string keySpecifier;
        private string kcv;
        private string keyScheme;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string KeySpecifier
        {
            get { return keySpecifier; }
            set { keySpecifier = value; }
        }

        public string KCV
        {
            get { return kcv; }
            set { kcv = value; }
        }

        public string KeyScheme
        {
            get { return keyScheme; }
            set { keyScheme = value; }
        }

    }

    public class HSMResponseInfo
    {
        private string functionCode;
        private string returnCode;
        private string returnMessage;
        public string FunctionCode
        {
            get { return functionCode; }
            internal set { functionCode = value; }
        }
        public string ReturnCode
        {
            get { return returnCode; }
            internal set { returnCode = value; }
        }
        public string ReturnMessage
        {
            get { return returnMessage; }
            internal set { returnMessage = value; }
        }
        public object ResponseData { get; set; }
    }

    public class ATBaseResponseInfo
    {
        public string Header { get; set; }
        public string ResponseCode { get; set; }
        public string ErrorCode { get; set; }
    }

    public class AT93ResponseInfo
    {
        private int noOfKeySet;
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public int NoOfKeySet
        {
            get { return noOfKeySet; }
            internal set { noOfKeySet = value; }
        }
        public KeySetInfo keySet { get; set; }
    }

    public class AT97ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public string encKeyAKB { get; set; }
        public string encKey { get; set; }
    }

    public class AT11BResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public string encWorkingKey { get; set; }
        public string KCV { get; set; }
    }


    public class AT10ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public string encWorkingKey { get; set; }
        public string KCV { get; set; }
    }



    public class AT30ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public string encPINBlock { get; set; }
       
    }


    public class AT32ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public string Result { get; set; }

    }

    public class AT31ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }
        public string NewPINBlock { get; set; }

        public string Result { get; set; }

    }

    public class AT1AResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        public string encSessionKey { get; set; }
        public string KCV { get; set; }
    }
    public class THM2ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        /// <summary>
        /// Output Initial Value
        /// </summary>
        public string OutputIV { get; set; }
        public StringBuilder Data { get; set; }
    }


    public class THM4ResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        /// <summary>
        /// Output Initial Value
        /// </summary>
        public string OutputIV { get; set; }
        public string Data { get; set; }
    }

    public class ATCAResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        /// <summary>
        /// Length of the returned PIN.
        /// </summary>
        public string PinLength { get; set; }

        public string PinBlock { get; set; }

        public string PinBlockFormat { get; set; }
    }

    public class ATEOResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        /// <summary>
        /// MAC on the public key and additional data, calculated using LMK key pair 36-37.
        /// </summary>
        public string MAC { get; set; }

        /// <summary>
        /// The imported Public Key, encoded as per field 3 of the command.
        /// </summary>
        public string EncodedPublicKey { get; set; }

        /// <summary>
        /// Delimiter, indicating that there is a trailer for the message.
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// Message trailer, as provided in the command.
        /// </summary>
        public string MessageTrailer { get; set; }
    }

    public class ATGKResponseInfo
    {
        public ATBaseResponseInfo HeaderAndReturnCode { get; set; }

        /// <summary>
        /// Initialization value for DES key.
        /// </summary>
        public string IV { get; set; }

        public int EncryptedKeyLength { get; set; }
        public string EncryptedKey { get; set; }
    }




}
