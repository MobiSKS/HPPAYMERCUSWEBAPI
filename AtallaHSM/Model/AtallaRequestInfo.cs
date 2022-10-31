using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AtallaHSM.Model
{
    public class AtallaRequestInfo : IDisposable
    {
        private Component component = new Component();
        // Track whether Dispose has been called. 
        private bool disposed = false;
        public String Header { get; set; }
        public string Delimiter { get; set; }
        public string CommandCode { get; set; }
        public String KeyType { get; set; }
        public string Mode { get; set; }
        public string Trailer { get; set; }

        /// <summary>
        /// The TMK that the exported TPK is to be encrypted under.
        /// </summary>
        public string TMK { get; set; }

        /// <summary>
        /// Key Scheme for exporting the TPK encrypted under the TMK.
        /// </summary>
        public string DPK_PPK_KeyScheme { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }
                // Note disposing has been done.
                disposed = true;

            }
        }

    }

    public class AT93RequestInfo : AtallaRequestInfo
    {
        public string KeyScheme { get; set; }

       

        public string TMKFlag { get; set; }

        /// <summary>
        /// The TMK that the exported TPK is to be encrypted under.
        /// </summary>
        public string TMK { get; set; }

        /// <summary>
        /// Key Scheme for exporting the TPK encrypted under the TMK.
        /// </summary>
        public string DPK_PPK_KeyScheme { get; set; }
        public string KeyLength { get; set; }

    }

    public class AT97RequestInfo : AtallaRequestInfo
    {
        public char InputFormat { get; set; }
        public char OutputFormat { get; set; }
        public string DEKAKB { get; set; }
        public string Operation { get; set; }
        public string InitializationVector { get; set; }
        public string DataFormat { get; set; }
        public string Data { get; set; }
    }

    public class ATM6RequestInfo : AtallaRequestInfo
    {
        public char InputFormatFlag { get; set; }

        public char MACSize { get; set; }

        public char MACAlgorithm { get; set; }

        public char PaddingMethod { get; set; }

        public string Key { get; set; }

        public string Message { get; set; }

        public string Delimiter { get; set; }

        public string LMKIdentifier { get; set; }
    }

    public class AT11BRequestInfo : AtallaRequestInfo
    {
        public string KEKAKB { get; set; }

        /// <summary>
        /// The Key to be imported, encrypted under the KEK.
        /// </summary>
        public string EncKey { get; set; }

        public string KeyUsage { get; set; }

        
    }

    public class AT30RequestInfo : AtallaRequestInfo
    {
        public string PMKAKB { get; set; }

        public string ClearPINBlock { get; set; }

        public string ClearPIN { get; set; }


    }


    public class AT32RequestInfo : AtallaRequestInfo
    {
        public string PINBlockFormat { get; set; }

        public string PINBlockPOS { get; set; }

        public string PINBlockHost { get; set; }
        public string PMKAKB { get; set; }
        public string PEKAKB { get; set; }


    }

    public class AT31RequestInfo : AtallaRequestInfo
    {
        public string PINBlockFormat { get; set; }

        public string PMKAKB { get; set; }

        public string PEKAKB { get; set; }
        public string PAN { get; set; } 
        public string NewPINBlock { get; set; }
    }



    public class AT1ARequestInfo : AtallaRequestInfo
    {
        public string TMKABB { get; set; }
        public string WKAKB { get; set; }
        public string Variant { get; set; }


    }


    public class AT10RequestInfo : AtallaRequestInfo
    {
        public string SessionKeyExchangeKey { get; set; }  
        public string KeyLength { get; set; }   


    }

    public class ATEORequestInfo : AtallaRequestInfo
    {
        /// <summary>
        /// Encoding rules for the public key.01 = DER encoding for ASN.1 Public Key(INTEGER uses unsigned representation).
        /// </summary>
        public string EncodingRule { get; set; }

        /// <summary>
        /// Public key, encoded as required by field 3.
        /// </summary>
        public string EncodedPublicKey { get; set; }

        /// <summary>
        /// Additional data for the MAC calculation.
        /// </summary>
        public string MACCalculationData { get; set; }

        /// <summary>
        /// Delimiter, indicating that there is a trailer for the message.
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// Message trailer, defined by user. (Max length is 32 chars.)
        /// </summary>
        public string MessageTrailer { get; set; }
    }


    public class ATCARequestInfo : AtallaRequestInfo
    {
        /// <summary>
        /// The TPK (encrypted under LMK pair 14-15 variant 0 or 36-37 variant 7, depending on whether PCI HSM compliance has been enforced) under which the PIN block is currently encrypted.
        /// </summary>
        public string InPPK_TPK_KeySpec { get; set; }

        /// <summary>
        /// The ZPK (encrypted under LMK pair 06-07 variant 0) under which the PIN block is to be encrypted.
        /// </summary>
        /// 
        public string OutZPKKeySpec { get; set; }

        /// <summary>
        /// Maximum PIN Length -must be between 04 and 12.
        /// </summary>
        public string MaxPinLength { get; set; }

        /// <summary>
        /// Source PIN Block, encrypted under the TPK/PPK.
        /// </summary>
        public string EncPinBlock { get; set; }

        /// <summary>
        /// Source PIN Block format code.01 = ISO 9564-1 & ANSI X9.8 format 0.
        /// </summary>
        public string InPinBlockFormat { get; set; }

        /// <summary>
        /// Output PIN Block format code.01 = ISO 9564-1 & ANSI X9.8 format 0.
        /// </summary>
        public string OutPinBlockFormat { get; set; }

        /// <summary>
        /// Account Number. For output PIN Block format code = 01, the 12 right-most digits of the PAN excluding the check digit.
        /// </summary>
        public StringBuilder ANB { get; set; }
    }

    public class ATGKRequestInfo : AtallaRequestInfo
    {
        public string EncryptionIdentifier { get; set; }
        public string PadModeIdentifier { get; set; }
        public string Key { get; set; }
        public string KeyCheckValue { get; set; }
        public string MAC { get; set; }
        public string PublicKey { get; set; }

        //public string SignatureIdentifier { get; set; }

        //public string EncryptedKeyOffset { get; set; }
        //public string EncryptedKeyLength { get; set; }
        //public string SignatureLength { get; set; }
        //public string Signature { get; set; }
        public string Delimiter { get; set; }
        public string KeyBlockType { get; set; }
    }

}
