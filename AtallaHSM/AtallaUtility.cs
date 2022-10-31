using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Configuration;


namespace AtallaHSM
{
    public class ConversionManager
    {
        public static String BytesToHexString(byte[] bArray)
        {
            StringBuilder hex = new StringBuilder(bArray.Length * 2);
            foreach (byte b in bArray)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }
        public static string HexToPlainText(string hexText)
        {
            return BytesToString(HexToByteArray(hexText));
        }
        public static string HexToBinary(string strHex)
        {
            var binary = String.Join(string.Empty,
           strHex.Select(x => Convert.ToString(Convert.ToInt32(x + string.Empty, 16), 2).PadLeft(4, '0')));
            return binary;
        }


        public static byte[] HexToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The hexString cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }

        public static string BytesToString(byte[] byteArray)
        {
            return System.Text.Encoding.UTF8.GetString(byteArray);
        }

        public static string DecimalToHex(int value)
        {
            return value.ToString("X2");
        }

        public static string DecimalToHex(int value, int byteLen)
        {
            var bytes = NumericDataLengthToHexaBytes(value.ToString(), byteLen);
            return BytesToHexStr(bytes);
        }
        public static Int32 HexToDecimal(string value)
        {
            int DecimalVal = Convert.ToInt32(value, 16);
            return DecimalVal;
        }
        public static int UTF8EncodedHexToDecimal(string hexValue)
        {
            var strInt = HexToPlainText(hexValue);
            return Convert.ToInt16(strInt);
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        }
        //public static byte[] HexStringToByteArray1(string hex)
        //{
        //    return Enumerable.Range(0, hex.Length / 2).Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16)).ToArray();
        //}


        public static String BytesToHexStr(byte[] bArray)
        {
            StringBuilder hex = new StringBuilder(bArray.Length * 2);
            foreach (byte b in bArray)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }


        public static int ByteToInt(byte[] b)
        {
            int val = 0;
            int i = b.Length - 1;
            for (int j = 0; i >= 0; j++)
            {
                val += (b[i] & 0xff) << 8 * j;
                i--;
            }

            return val;
        }

        public static byte[] ConvertToBinaryCodedDecimal(bool isLittleEndian, string bcdString)
        {
            bool isValid = true;
            isValid = isValid && !String.IsNullOrEmpty(bcdString);
            // Check that the string is made up of sets of two numbers (e.g. "01" or "3456")
            isValid = isValid && Regex.IsMatch(bcdString, "^([0-9]{2})+$");
            byte[] bytes;
            if (isValid)
            {
                char[] chars = bcdString.ToCharArray();
                int len = chars.Length / 2;
                bytes = new byte[len];
                if (isLittleEndian)
                {
                    for (int i = 0; i < len; i++)
                    {
                        byte highNibble = byte.Parse(chars[2 * (len - 1) - 2 * i].ToString());
                        byte lowNibble = byte.Parse(chars[2 * (len - 1) - 2 * i + 1].ToString());
                        bytes[i] = (byte)((byte)(highNibble << 4) | lowNibble);
                    }
                }
                else
                {
                    for (int i = 0; i < len; i++)
                    {
                        byte highNibble = byte.Parse(chars[2 * i].ToString());
                        byte lowNibble = byte.Parse(chars[2 * i + 1].ToString());
                        bytes[i] = (byte)((byte)(highNibble << 4) | lowNibble);
                    }
                }
            }
            else
            {
                throw new ArgumentException(String.Format(
                    "Input string ({0}) was invalid.", bcdString));
            }
            return bytes;
        }

        public static string StringToHex(string stText)
        {
            return string.Join("", stText.Select(c => ((int)c).ToString("X2")));
        }

        public static string BinaryToHex(string strBinary)
        {
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X");
            return strHex.PadLeft(strHex.Length + strHex.Length % 2, '0');
        }

        public static byte[] fromHexString(String _in)
        {
            Int16 temp = Int16.Parse(_in);
            return BitConverter.GetBytes(temp);
        }


        public static byte[] buildVarLenPrefix(int len)
        {
            int prefixLen = len / 2;
            String hexlen = prefixLen.ToString("X2");
            byte[] varLenPrefix = fromHexString(prefixLen.ToString());

            if (varLenPrefix.Length == 1 && prefixLen < 128)
            {
                //do nothing
            }
            else if (varLenPrefix.Length == 2 && prefixLen < 16384)
            {
                String s = toBinary(varLenPrefix);
                s = ReplaceFirst(s, "00", "10");
                varLenPrefix = fromBinary(s);
            }
            else if (varLenPrefix.Length == 3 && prefixLen < 2097152)
            {
                String s = toBinary(varLenPrefix);
                s = ReplaceFirst(s, "000", "110");
                varLenPrefix = fromBinary(s);
            }
            return varLenPrefix;
        }


        public static String toBinary(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * Byte.MaxValue);
            for (int i = 0; i < Byte.MaxValue * bytes.Length; i++)
                sb.Append((bytes[i / Byte.MaxValue] << i % Byte.MaxValue & 0x80) == 0 ? '0' : '1');
            return sb.ToString();
        }

        public static byte[] fromBinary(String s)
        {
            int sLen = s.Length;
            byte[] toReturn = new byte[(sLen + Byte.MaxValue - 1) / Byte.MaxValue];
            char c;
            for (int i = 0; i < sLen; i++)
                if ((c = s[i]) == '1')
                    toReturn[i / Byte.MaxValue] = (byte)(toReturn[i / Byte.MaxValue] | (0x80 >> (i % Byte.MaxValue)));
                else if (c != '0')
                    throw new ArgumentOutOfRangeException();
            return toReturn;
        }

        static string ReplaceFirst(string str, string valueToReplace, string valueToBeReplaced)
        {
            var regex = new Regex(Regex.Escape(valueToReplace));
            var newText = regex.Replace(str, valueToBeReplaced, 1);
            return newText;
        }

        public static byte[] NumericDataLengthToHexaBytes(string nibbleValue, int toByteLength)
        {
            //make even length data to put into byte 
            nibbleValue = nibbleValue.PadLeft(toByteLength * 2, '0');
            //List<byte> lstBytes = new List<byte>();
            byte[] byteArray = new byte[toByteLength];
            int arIndex = 0;
            for (int index = 0; index < nibbleValue.Length; index += 2)
            {
                byteArray[arIndex++] = Convert.ToByte(nibbleValue.Substring(index, 2));
            }
            return byteArray;
        }
    }


    public partial class AttalaHSMServiceProvider
    {
        public static bool IsPCIComplianceEnable = Convert.ToBoolean(ConfigurationManager.AppSettings["PCIComplianceEnable"]);
        internal struct FunctionCode
        {
            public const String Atalla_GENR_KEY_API = "93";//ok  Generate TPK
            public const String Atalla_IMPORT_KEY_API = "11B";
            public const String Atalla_ENC_DATA_API = "97";
            public const String Atalla_GENR_SK_API = "10";
            public const String Atalla_ENCR_SK_TMK_API = "1A";
            public const String Atalla_GENERATE_PINBLOCK_API = "30";
            public const String Atalla_TRANS_PIN_API = "CA";
            public const String Atalla_GENR_MAC_API = "M6"; // not in use 
            public const String Atalla_IMPO_PUB_KEY_API = "EO";
            public const String Atalla_ENC_PUB_KEY_API = "GK"; // C
            public const String Atalla_VERIFY_PINBLOCK_API = "32"; // C
            public const String Atalla_CHANGE_PINBLOCK_API = "31"; // C

        }
        public struct ModeFlag
        {
            public const string GenerateKey = "0";
            public const string GeneratekeyAndEncryptUnderTMK = "1";
            public const string GeneratekeyAndEncryptUnderZMK = "1";
            public const string Derivekey = "A";
            public const string DeriveKeyAndEncryptUnderZMK = "B";
            public const string TripleDESCipherBlockChaining = "6";
            public const string CBC = "01";
        }


        public struct KeyValueType
        {
            public const string DecimalType = "D";
            public const string HexaDecimalType = "H";
        }

        public struct MACModeFlag
        {
            public const char OnlyBlockOfSingleBlockMessage = '0';
            public const char FirstBlockOfMultiBlockMessage = '1';
            public const char MiddleBlockOfMultiBlockMessage = '2';
            public const char FinalBlockOfMultiBlockMessage = '3';
        }

        public struct KeyType
        {
            //Zone Master Key, ZMK,ZMK encrypted under LMK pair 04-05.
            public const string ZMK = "000";
            //Zone PIN encryption, ZPK
            public const string ZPK = "001";
            //Terminal PIN Key(TPK)=PPK, encrypted under TMK
            public static string PPK = "002";//
            //Terminal Master Key(TMK) ,encrypted under LMK pair 14-15
            public static string TMK = "80D";
            // DPK=TEK
            public static string DPK = "30B";// IsPCIComplianceEnable ? "30B" : "609";

            public const string Ignore = "FFF";
            //Type 2 BDK, encrypted under Variant LMK pair 28-29, variant 6.
            public const string DecrData = "609";

            //TAK (encrypted under LMK pair 16-17)
            public const string TAK = "003";

            //ZAK (encrypted under LMK pair 26-27)
            public const string ZAK = "008";


            public static string ForVariantLMK =  "1400";

            public const string ZEK_UNDER_LMK = "00A";
            public const string DEK_UNDER_LMK = "00B";
            public const string TEK_UNDER_LMK = "30B";

        }

        public struct EncryptionKeyTypeFlag
        {
            public const char ZMK = '0';
            public const char TMK = '1';
        }


        public struct PinBlockFormat
        {
            public const string Format01 = "1";
            public const string Format08 = "8";
        }

        public struct IOFormatFlag
        {
            public const char Binary = '0';
            public const char HexEncodedBinary = '1';
            public const char Text = '2';
        }

        public struct MACSize
        {
            public const char MACSize8HexDigits = '0';
            public const char MACSize16HexDigits = '1';
        }

        public struct MACAlgorithm
        {
            public const char ISO9797MACAlgorithm1 = '1';
            public const char ISO9797MACAlgorithm3 = '3';
            public const char CBCMAC = '5';
            public const char CMAC = '6';
        }

        public struct PaddingMethod
        {
            #region ForMACAlgorithmValues'1', '3' & '5':
            //(Overall message length must be multiple of 8 bytes for MAC Algorithm 1 & 3; and must be a multiple of 16 bytes for MAC Algorithm 5.)
            public const char NoPadding = '0';
            //(i.e. pad with 0x00).
            public const char ISO9797PaddingMethod1 = '1';
            //(i.e. add 0x80 and pad with 0x00).
            public const char ISO9797PaddingMethod2 = '2';
            //(i.e. prepend message with length, pad with 0x00).
            public const char ISO9797PaddingMethod3 = '3';

            #endregion
            #region For MAC Algorithm values '6':
            public const char AESCMACPadding = '4';
            #endregion

        }

        public struct Delimiter
        {
            public const string ControlCharSymbol = "19"; //Hex Value
            public const string DelimiterASCHI = ";"; //Hex Value
            public const string DelimiterHEX = "3B"; //Hex Value
        }

        //Identifier of algorithm used to encrypt the key
        public struct EncryptionIdentifier
        {
            public const string RSA = "01";
        }

        public struct PadModeIdentifier
        {
            public const string EME_PKCS1_v1_5 = "01";
            public const string EME_OAEP_ENCODE = "02";
        }

        public struct MessageTrailer
        {
            //this text is taken from sample code
            public const string RSAPublicKeyImport = "GF6W54G65WR456GAER54GE6R45G6E4AR";
        }

        public struct EncodingRule
        {
            public const string DEREncodingForASN1UsingUnsignedRep = "01";
            public const string DEREncodingForASN1Using2sComplement = "02";
        }

        public struct CipherMode
        {
            public const string ECB = "00";
            public const string CBC = "01";
        }

        public struct Operation
        {
            public const string ENCRYPT = "E";
            public const string DECRYPT = "D";
        }

        public struct DataFormat
        {
            public const string BINARY = "B";
            public const string HEXADECIMAL = "U";
        }

        public struct InitilzationVector
        {
            public const string ZERO = "D";
            public const string EMPTY = "E";
        }

        public struct KeyScheme
        {
            //EncryptUnderTheLMK

            public const string EncryptUnderTheLMK = "U";
            public const string EncryptUnderTheTMK = "X";
            public const string EncryptUnderTheZMK = "X"; //Y
            public const string TripleLengthKey = "T";
            public const string DoubleLengthKey="D";
        }

        public enum KeyLengthType
        {
            S = 0,//16Hex digit(8 byte len): Single Length
            U = 32,// 32 Hex(16 byte):Double Lenth 
            T = 48// 48Hex (32 byte):Triple
        }


        public struct KeyFlag
        {
            public const string SingleLength = "0";
            public const string DoubleLength = "1";
            public const string TripleLength = "2";
           
        }

        public struct ReturnCode
        {
            #region HSM Error Codes
            public const string Error = "00";
            public const string Success = "A3";
            // Verification failure or warning of imported key parity error
            public const string LengthOutOfRange = "01";
            public const string InvalidCharacter = "02";
            public const string ValueOutOfRange = "03";
            public const string InvalidNoOfParameters = "04";
            public const string ParityError = "05";
            public const string KeyUsageError = "06";
            public const string KeyUsageError07= "07";
            public const string ExecutionError = "08";
            public const string ExecutionError09 = "09";
            public const string KeyLengthError = "10";
            public const string PrintingError = "11";
            public const string MakerStringNotFound = "12";
            public const string SerialNoSetCannotModify = "20";
            public const string SerialNoNotPresent = "21";
            public const string NonExistentCommand = "22";
            public const string InvalidCommand = "23";
            public const string IncorrectChallenge = "24";
            public const string IncorrectAcknowledgment = "25";
            public const string DuplicateCommand = "26";
            public const string NoChallenge = "27";
            public const string ConfigurationCommandTooLong = "28";
            public const string UnableToAllocateMemory = "29";
            public const string ASRMTimeOut = "41";
            public const string HeaderMisMatch = "73";
            public const string AuthKeyError = "92";
            public const string FactoryKeysAleradyGeneratedInvalid = "93";
            public const string NoFactoryKeysGenerated = "94";
          
            public const string RepeatedOptionalBlock = "BC";
            public const string IncompatibleKeyTypes = "BD";
            public const string InvalidKeyblockHeaderID = "BE";

            //

            public const string ExceptionError = "100";
            public const string ValidationError = "101";
            public const string InvalidFunctionCode = "102";
            #endregion
        }

        public struct ErrorCodeForGI
        {
            public const string NoError = "00";
            public const string MACVerificationFailure = "01";
            public const string SignatureVerificationFailure = "02";
            public const string InvalidPrivateKeyType = "03";
            public const string InvalidPrivateKeyFlag = "04";
            public const string InvalidKeyType = "05";
            public const string InvalidEncryptionIdentifier = "06";
            public const string InvalidPadModeIdentifier = "07";
            public const string InvalidHMACHashIdentifierValue = "34";
            public const string InvalidHMACKeyUsageValue = "35";
            public const string InvalidHMACKeyFormatValue = "36";
            public const string InvalidHMACKeyblockTypeValue = "37";
            public const string AlgorithmNotLicensed = "47";
            public const string PublicKeyDoesNotConformToEncodingRules = "50";
            public const string InvalidMessageHeader = "51";
            public const string InvalidSignatureIdentifier = "52";
            public const string InvalidSignaturePadModeIdentifier = "53";
            public const string InvalidEncryptedKeyOffset = "54";
            public const string InvalidEncryptedKeyLength = "55";
            public const string SignatureLengthMismatch = "56";
            public const string InvalidKeyCheckValueType = "57";
            public const string CommandDisabled = "68";
            public const string InvalidDigestInfoSyntax = "74";
            public const string PublicKeyLengthError = "76";
            public const string ClearDataBlockError = "77";
            public const string PrivateKeyLengthError = "78";
            public const string HashAlgorithmObjectIdentifierError = "79";
            public const string DataBlockLengthError = "80";
            public const string InvalidCertificateHeader = "81";
            public const string InvalidCheckValueLength = "82";
            public const string KeyBlockFormatError = "83";
            public const string KeyBlockCheckValueError = "84";
            public const string InvalidOAEPMaskGenerationFunction = "85";
            public const string InvalidOAEPMGFHashFunction = "86";
            public const string OAEPParameterError = "87";
            public const string OAEPError = "88";
            //or a standard error code.
        }
    }
}
