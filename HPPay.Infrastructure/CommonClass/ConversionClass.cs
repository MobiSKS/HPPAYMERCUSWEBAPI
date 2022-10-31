using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HPPay.Infrastructure.CommonClass
{
    public class ConversionClass
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

        //public static byte[] HexToByteArray(string hex)
        //{
        //    return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        //}
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

        //public static byte[] ConvertToBinaryCodedDecimal(bool isLittleEndian, string bcdString)
        //{
        //    bool isValid = true;
        //    isValid = isValid && !String.IsNullOrEmpty(bcdString);
        //    // Check that the string is made up of sets of two numbers (e.g. "01" or "3456")
        //    isValid = isValid && Regex.IsMatch(bcdString, "^([0-9]{2})+$");
        //    byte[] bytes;
        //    if (isValid)
        //    {
        //        char[] chars = bcdString.ToCharArray();
        //        int len = chars.Length / 2;
        //        bytes = new byte[len];
        //        if (isLittleEndian)
        //        {
        //            for (int i = 0; i < len; i++)
        //            {
        //                byte highNibble = byte.Parse(chars[2(len - 1) - 2  i].ToString());
        //                byte lowNibble = byte.Parse(chars[2(len - 1) - 2  i + 1].ToString());
        //                bytes[i] = (byte)((byte)(highNibble << 4) | lowNibble);
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 0; i < len; i++)
        //            {
        //                byte highNibble = byte.Parse(chars[2 * i].ToString());
        //                byte lowNibble = byte.Parse(chars[2 * i + 1].ToString());
        //                bytes[i] = (byte)((byte)(highNibble << 4) | lowNibble);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentException(String.Format(
        //            "Input string ({0}) was invalid.", bcdString));
        //    }
        //    return bytes;
        //}

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
}
