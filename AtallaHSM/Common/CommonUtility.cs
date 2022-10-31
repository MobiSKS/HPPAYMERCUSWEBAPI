using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using Newtonsoft.Json;
using NLog.Web;

namespace AtallaHSM.Common
{
    public static class LoggerUtility
    {
        //private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static void Logging(LogInfo logInfo)
        {
            var log = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            log.Info("Start logging");
            logInfo.TimeStamp = DateTime.UtcNow.ToString("o"); // 8601 ISO standard format 
            string retStr = JsonConvert.SerializeObject(logInfo, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            if (logInfo.Level.Equals(LogLevel.INFO, StringComparison.OrdinalIgnoreCase))
            {
                log.Info(retStr);
                Console.WriteLine(retStr);
            }
            else if (logInfo.Level.Equals(LogLevel.ERROR, StringComparison.OrdinalIgnoreCase))
            {
                log.Error(retStr);
                Console.Error.WriteLine(retStr);
            }
            else if (logInfo.Level.Equals(LogLevel.DEBUG, StringComparison.OrdinalIgnoreCase))
            {
                log.Debug(retStr);
                Console.WriteLine(retStr);
            }
            //log.Info("End logging");
        }

        public class CommonUtility
        {
            //   private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //   public static string APPLICATION_NAME = ConfigurationManager.AppSettings["Program"].ToString();

            //public static string ConnectionString
            //{
            //    get
            //    {
            //        if (ConfigurationManager.ConnectionStrings["ConnectionString"] == null)
            //        {
            //            throw new Exception("Connection String not specified");
            //        }
            //        return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //    }

            //}

            public static bool HasColumn(IDataRecord iDataReader, string columnName)
            {
                try
                {
                    return iDataReader.GetOrdinal(columnName) >= 0;
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }
            }
            public static string GetEmptyStringValue(object value)
            {
                try
                {
                    string strVal = string.Empty;
                    if (value != null && value != DBNull.Value)
                    {
                        strVal = Convert.ToString(value);
                    }
                    return strVal;
                }
                finally
                {
                }
            }

            public static object SetNullStringValue(string value)
            {
                try
                {
                    object objVal = null;
                    if (string.IsNullOrEmpty(value))
                        objVal = DBNull.Value;
                    else
                        objVal = value.ToString();
                    return objVal;
                }
                finally
                {
                }
            }

            //public static string GetKeyValueFromConfig(string key)
            //{
            //    try
            //    {
            //        return ConfigurationManager.AppSettings[key].ToString();
            //    }
            //    finally
            //    {
            //    }
            //}

            public static string GetFormattedDateValue(DateTime value)
            {
                try
                {
                    string stringFormattedDate = string.Empty;
                    if (value != DateTime.MinValue)
                    {
                        stringFormattedDate = value.ToString("dd/MM/yyyy");
                    }
                    return stringFormattedDate;
                }
                finally
                {
                }
            }

            public static string GetFormattedDate(DateTime value)
            {
                try
                {
                    string stringFormattedDate = string.Empty;
                    if (value != DateTime.MinValue)
                    {
                        stringFormattedDate = value.ToString("yyyy/MM/dd");
                    }
                    return stringFormattedDate;
                }
                finally
                {
                }
            }

            public static int GetZeroIntegerValue(object value)
            {
                try
                {
                    int intVal = 0;

                    if (value != null && value != DBNull.Value)
                    {
                        intVal = Convert.ToInt32(value);
                    }
                    return intVal;
                }
                finally
                {
                }
            }

            public static int GetIntegerValueFromString(string value)
            {
                try
                {
                    int intVal = 0;

                    if (!string.IsNullOrEmpty(value))
                    {
                        intVal = Convert.ToInt32(value);
                    }
                    return intVal;
                }
                finally
                {
                }
            }

            public static string GetEmptyStringFromInteger(object value)
            {
                try
                {
                    string EmptyString = string.Empty;
                    if (Convert.ToInt32(value) != 0)
                    {
                        EmptyString = value.ToString();
                    }
                    return EmptyString;
                }
                finally
                {
                }
            }

            public static long GetZeroLongValue(object value)
            {
                try
                {
                    long intVal = 0;

                    if (value != null && value != DBNull.Value)
                    {
                        intVal = Convert.ToInt64(value);
                    }
                    return intVal;
                }
                finally
                {
                }
            }

            public static Decimal GetZeroDecimalValue(object value)
            {
                try
                {
                    Decimal deVal = 0.0m;

                    if (value != null && value != DBNull.Value)
                    {
                        deVal = Convert.ToDecimal(value);
                    }
                    return deVal;
                }
                finally
                {
                }
            }

            public static float GetZeroFloatValue(object value)
            {
                try
                {
                    float fltVal = 0.0F;

                    if (value != null && value != DBNull.Value)
                    {
                        fltVal = float.Parse(value.ToString());
                    }
                    return fltVal;
                }
                finally
                {
                }
            }

            public static bool GetBooleanValue(object value)
            {
                try
                {
                    bool boolVal = false;

                    if (value != null && value != DBNull.Value)
                    {
                        boolVal = Convert.ToBoolean(value);
                    }
                    return boolVal;
                }
                finally
                {
                }
            }

            public static string GetEmptyDateTimeValue(DateTime value)
            {
                try
                {
                    string objVal = null;
                    if (DateTime.Compare(value, DateTime.MinValue) == 0 || DateTime.Compare(value, new DateTime(1900, 1, 1)) == 0)
                        objVal = string.Empty;
                    else
                        objVal = value.ToString("dd/MM/yyyy");
                    return objVal;
                }
                finally
                {
                }
            }

            public static string GetEmptyDateTimeFormat(DateTime value)
            {
                try
                {
                    string objVal = null;
                    if (DateTime.Compare(value, DateTime.MinValue) == 0 || DateTime.Compare(value, new DateTime(1900, 1, 1)) == 0)
                        objVal = string.Empty;
                    else
                        objVal = value.ToString("dd-MM-yyyy hh:mm:ss");
                    return objVal;
                }
                finally
                {
                }
            }

            public static DateTime GetEmptyDateTimeValue(object value)
            {
                try
                {
                    DateTime dateTimeVal = DateTime.MinValue;
                    if (value != null && value != DBNull.Value)
                    {
                        dateTimeVal = Convert.ToDateTime(value);
                    }
                    return dateTimeVal;
                }
                finally
                {
                }
            }

            public static string GetEmptyDateValue(object value)
            {
                try
                {
                    string objVal = null;
                    if (value != null && value != DBNull.Value)
                        objVal = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                    else
                        objVal = string.Empty;
                    return objVal;
                }
                finally
                {
                }
            }

            public static DateTime SetMinimumDateValue(DateTime value)
            {
                try
                {
                    DateTime dateTimeVal = new DateTime(1900, 1, 1);
                    if (value != dateTimeVal)
                    {
                        dateTimeVal = Convert.ToDateTime(value);
                    }
                    return dateTimeVal;
                }
                finally
                {
                }
            }

            public static object SetNullDateTimeValue(DateTime value)
            {
                try
                {
                    object objVal = null;
                    if (value == DateTime.MinValue || value == Convert.ToDateTime("1/1/1900"))
                        objVal = DBNull.Value;

                    else
                        objVal = value;
                    return objVal;
                }
                finally
                {
                }
            }
            public static object SetNullLongValue(long value)
            {
                try
                {
                    object objVal = null;
                    if (value == 0)
                        objVal = DBNull.Value;
                    else
                        objVal = value;
                    return objVal;
                }
                finally
                {
                }
            }

            public static string ExecuteCommand(string command)
            {
                try
                {
                    if (string.IsNullOrEmpty(command))
                        return string.Empty;
                    System.Diagnostics.ProcessStartInfo procStartInfo =
                            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    procStartInfo.CreateNoWindow = true;
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = procStartInfo;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();
                    return result;
                }
                finally
                {
                }
            }

            public static string ExecuteCommand(string command, string arguments)
            {
                string result = string.Empty;
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = command;
                    proc.StartInfo.Arguments = arguments;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.Start();
                    result = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit(2 * 60 * 1000);
                }
                finally
                {
                }
                return result;
            }

            public static string LeftPad(string source, char pad, int finalLength)
            {
                try
                {
                    int padLength = finalLength - source.Length;
                    if (padLength <= 0)
                        return source;
                    return new string(pad, padLength) + source;
                }
                finally
                {
                }
            }

            public static string RightPad(string source, char pad, int finalLength)
            {
                try
                {
                    int padLength = finalLength - source.Length;
                    if (padLength <= 0)
                        return source;
                    return source + new string(pad, padLength);
                }
                finally
                {
                }
            }

            public static Decimal ConvertToRupees(long paise)
            {

                try
                {
                    return Convert.ToDecimal(paise * 0.01);
                }
                finally
                {

                }
            }

            public static long ConvertToPaise(Decimal rupees)
            {

                try
                {
                    return Convert.ToInt64(rupees * 100);
                }
                finally
                {

                }
            }

            public static long ConvertToLongFromPersantage(float persantageValue)
            {

                try
                {
                    return Convert.ToInt64(persantageValue * 100);
                }
                finally
                {

                }
            }

            public static long ConvertToLongFromDecimal(Decimal distance)
            {

                try
                {
                    return Convert.ToInt64(distance * 100);
                }
                finally
                {

                }
            }

            public static long ConvertToMeterFromKm(Decimal distance)
            {

                try
                {
                    return Convert.ToInt64(distance * 1000);
                }
                finally
                {

                }
            }

            public static string ProcessTemplate(string templateHtml, Dictionary<string, string> templateVariableValues)
            {
                string processedTemplate = templateHtml;
                foreach (string variableName in templateVariableValues.Keys)
                {
                    processedTemplate = processedTemplate.Replace(variableName, templateVariableValues[variableName]);
                }
                return processedTemplate;
            }

            public static bool TryParse(string text, out int? outValue)
            {
                int parsedValue;
                bool success = int.TryParse(text, out parsedValue);
                outValue = success ? (int?)parsedValue : null;
                return success;
            }

            public static bool TryLong(string text, out long? outValue)
            {
                long parsedValue;
                bool success = long.TryParse(text, out parsedValue);
                outValue = success ? (long?)parsedValue : null;
                return success;
            }

            public static bool TryParseDateTime(string text, out DateTime? outValue)
            {
                DateTime parsedValue;
                bool success = DateTime.TryParseExact(text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedValue);
                outValue = success ? (DateTime?)parsedValue : null;
                return success;
            }

            public byte[] getHexToByteArray(string hex)
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();
            }

            public static string ConvertHexToString(string hexValue)
            {
                StringBuilder sbValue = new StringBuilder();
                StringBuilder sbHex = new StringBuilder(hexValue);
                while (sbHex.Length > 0)
                {
                    sbValue.Append(System.Convert.ToChar(System.Convert.ToUInt32(sbHex.ToString(0, 2), 16)).ToString());
                    //sbHex = sbHex.Substring(2, sbHex.Length - 2);
                    sbHex.Remove(0, 2);
                }
                return sbValue.ToString();
            }
            public static string HextoString(string InputText)
            {

                byte[] bb = Enumerable.Range(0, InputText.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(InputText.Substring(x, 2), 16))
                                 .ToArray();

                //return Convert.ToBase64String(bb);
                char[] chars = new char[bb.Length / sizeof(char)];
                System.Buffer.BlockCopy(bb, 0, chars, 0, bb.Length);
                return new string(chars);
            }
        }


        public class RSADataUtility
        {
            public RSADataUtility()
            {
                
            }
            //private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            bool _optimalAsymmetricEncryptionPadding = false;
            const int keySize = 1024; //128 bytes (128*8=1024 bits)
            string removeCharPosition = "";// "1,11,21,46,75,99,144";
            public byte[] Hash(string key, byte[] byteData)
            {
                try
                {
                    using (var provider = new RSACryptoServiceProvider(keySize))
                    {
                        string actualKey = key;
                        byte[] keyByte = Convert.FromBase64String(actualKey);
                        if (removeCharPosition.Length > 0)
                            keyByte = RemoveExtraBytes(keyByte, removeCharPosition);
                        provider.ImportParameters(GetPublicKey(keyByte));
                        var encryptedByte = provider.Encrypt(byteData, _optimalAsymmetricEncryptionPadding);
                        return encryptedByte;

                        //string s = BitConverter.ToString(keyByte).Replace("-", " ");
                        //var byteData = Encoding.UTF8.GetBytes(textBox3.Text.Trim());
                        //var byteData = GetBinary(textBox3.Text.Trim());
                        //textBox3.Text = Convert.ToBase64String(encryptedByte);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Hash Converstion Error");
                }
            }
            public byte[] DeHash(string key, byte[] byteData)
            {
                try
                {
                    using (var provider = new RSACryptoServiceProvider(keySize))
                    {
                        string actualKey = key;
                        byte[] keyByte = Convert.FromBase64String(actualKey);
                        if (removeCharPosition.Length > 0)
                            keyByte = RemoveExtraBytes(keyByte, removeCharPosition);

                        provider.ImportParameters(GetPrivateKey(keyByte));
                        var dataBytes = provider.Decrypt(byteData, _optimalAsymmetricEncryptionPadding);
                        return dataBytes;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("DeHash Converstion Error");
                }
            }
            //string RemoveExtraBytes(string textHavingExtraChar, string removeCharPosition)
            //{
            //    int index = 0;
            //    int i = 1;
            //    foreach (string pos in removeCharPosition.Split(','))
            //    {
            //        index = Convert.ToInt32(pos) - i;
            //        textHavingExtraChar = textHavingExtraChar.Remove(index, 1);
            //        i += 1;
            //    }
            //    return textHavingExtraChar;
            //}
            byte[] RemoveExtraBytes(byte[] textHavingExtraChar, string removeCharPosition)
            {
                string[] garLength = null;
                if (!string.IsNullOrEmpty(removeCharPosition))
                {
                    garLength = removeCharPosition.Split(',');
                }
                else
                {
                    return textHavingExtraChar;
                }
                byte[] key = new byte[textHavingExtraChar.Length - garLength.Length];

                for (int i = 0, j = 0; i < textHavingExtraChar.Length; i++)
                {
                    if (!garLength.Contains(Convert.ToString(i + 1)))
                    {
                        key[j] = textHavingExtraChar[i];
                        j++;
                    }
                }
                return key;
            }


            //public static byte[] GetBinary(string hexMessage)
            //{
            //    SoapHexBinary shb = SoapHexBinary.Parse(hexMessage);
            //    return shb.Value;
            //}

            private RSAParameters GetPrivateKey(byte[] privkey)
            {
                // --------- Set up stream to decode the asn.1 encoded RSA private key ------
                MemoryStream mem = new MemoryStream(privkey);
                BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
                byte bt = 0;
                ushort twobytes = 0;
                RSAParameters RSAparams = new RSAParameters();
                try
                {
                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();    //advance 2 bytes
                    else
                        return RSAparams;

                    twobytes = binr.ReadUInt16();
                    if (twobytes != 0x0102) //version number
                        return RSAparams;
                    bt = binr.ReadByte();
                    if (bt != 0x00)
                        return RSAparams;
                    twobytes = binr.ReadUInt16();
                    if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
                        return RSAparams;   //advance 1 byte
                    RSAparams.Modulus = GetBytes(binr);
                    RSAparams.Exponent = GetBytes(binr);
                    twobytes = binr.ReadUInt16();
                    if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
                        return RSAparams;   //advance 1 byte
                    RSAparams.D = GetBytes(binr);
                    RSAparams.P = GetBytes(binr);
                    RSAparams.Q = GetBytes(binr);
                    RSAparams.DP = GetBytes(binr);
                    RSAparams.DQ = GetBytes(binr);
                    RSAparams.InverseQ = GetBytes(binr);
                    return RSAparams;
                }
                catch (Exception ex)
                {
                    return RSAparams;
                }
                finally
                {
                    binr.Close();
                }
            }
            private RSAParameters GetPublicKey(byte[] privkey)
            {
                // --------- Set up stream to decode the asn.1 encoded RSA private key ------
                MemoryStream mem = new MemoryStream(privkey);
                BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
                byte bt = 0;
                ushort twobytes = 0;
                RSAParameters RSAparams = new RSAParameters();
                try
                {

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();    //advance 2 bytes
                    else
                        return RSAparams;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x0102) //version number
                    {
                        bt = binr.ReadByte();
                        if (bt != 0x00)
                            return RSAparams;
                        twobytes = binr.ReadUInt16();
                        if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
                            return RSAparams;   //advance 1 byte
                    }
                    else if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
                    {
                        return RSAparams;   //advance 1 byte
                    }
                    //  return RSAparams;

                    //twobytes = binr.ReadUInt16();
                    if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
                        return RSAparams;   //advance 1 byte
                    RSAparams.Modulus = GetBytes(binr);
                    RSAparams.Exponent = GetBytes(binr);
                    //RSAparams.D = GetBytes(binr);
                    //RSAparams.P = GetBytes(binr);
                    //RSAparams.Q = GetBytes(binr);
                    //RSAparams.DP = GetBytes(binr);
                    //RSAparams.DQ = GetBytes(binr);
                    //RSAparams.InverseQ = GetBytes(binr);
                    return RSAparams;
                }
                catch (Exception ex)
                {
                    return RSAparams;
                }
                finally
                {
                    binr.Close();
                }
            }
            //private RSAParameters GetPrivateKey(byte[] privkey)
            //{
            //    // --------- Set up stream to decode the asn.1 encoded RSA private key ------
            //    MemoryStream mem = new MemoryStream(privkey);
            //    BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
            //    byte bt = 0;
            //    ushort twobytes = 0;
            //    RSAParameters RSAparams = new RSAParameters();
            //    try
            //    {
            //        twobytes = binr.ReadUInt16();
            //        if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
            //            binr.ReadByte();    //advance 1 byte
            //        else if (twobytes == 0x8230)
            //            binr.ReadInt16();    //advance 2 bytes
            //        else
            //            return RSAparams;

            //        twobytes = binr.ReadUInt16();
            //        if (twobytes != 0x0102) //version number
            //            return RSAparams;
            //        bt = binr.ReadByte();
            //        if (bt != 0x00)
            //            return RSAparams;
            //        twobytes = binr.ReadUInt16();
            //        if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
            //            return RSAparams;   //advance 1 byte
            //        RSAparams.Modulus = GetBytes(binr);
            //        RSAparams.Exponent = GetBytes(binr);
            //        RSAparams.D = GetBytes(binr);
            //        RSAparams.P = GetBytes(binr);
            //        RSAparams.Q = GetBytes(binr);
            //        RSAparams.DP = GetBytes(binr);
            //        RSAparams.DQ = GetBytes(binr);
            //        RSAparams.InverseQ = GetBytes(binr);
            //        return RSAparams;
            //    }
            //    catch (Exception ex)
            //    {
            //        return RSAparams;
            //    }
            //    finally
            //    {
            //        binr.Close();
            //    }
            //}

            //private RSAParameters GetPublicKey(byte[] privkey)
            //{
            //    // --------- Set up stream to decode the asn.1 encoded RSA private key ------
            //    MemoryStream mem = new MemoryStream(privkey);
            //    BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
            //    byte bt = 0;
            //    ushort twobytes = 0;
            //    RSAParameters RSAparams = new RSAParameters();
            //    try
            //    {
            //        twobytes = binr.ReadUInt16();
            //        if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
            //            binr.ReadByte();    //advance 1 byte
            //        else if (twobytes == 0x8230)
            //            binr.ReadInt16();    //advance 2 bytes
            //        else
            //            return RSAparams;

            //        twobytes = binr.ReadUInt16();
            //        if (twobytes != 0x0102) //version number
            //            return RSAparams;
            //        bt = binr.ReadByte();
            //        if (bt != 0x00)
            //            return RSAparams;
            //        twobytes = binr.ReadUInt16();
            //        if (twobytes != 0x8102 && twobytes == 0x8202) //actual data order for Sequence is 02 81 or 02 82
            //            return RSAparams;   //advance 1 byte
            //        RSAparams.Modulus = GetBytes(binr);
            //        RSAparams.Exponent = GetBytes(binr);
            //        //RSAparams.D = GetBytes(binr);
            //        //RSAparams.P = GetBytes(binr);
            //        //RSAparams.Q = GetBytes(binr);
            //        //RSAparams.DP = GetBytes(binr);
            //        //RSAparams.DQ = GetBytes(binr);
            //        //RSAparams.InverseQ = GetBytes(binr);
            //        return RSAparams;
            //    }
            //    catch (Exception ex)
            //    {
            //        return RSAparams;
            //    }
            //    finally
            //    {
            //        binr.Close();
            //    }
            //}

            byte[] GetBytes(BinaryReader binr)
            {
                byte bt = 0;
                int elems = 0, extraNull = 0;
                byte[] byteData;
                bt = binr.ReadByte(); //read single byte
                if (bt != 0x02)  // check for start byte
                    elems = (int)bt; //if not it is the length of the data
                else
                    elems = (int)binr.ReadByte(); // else get length of the data
                if (elems > 8) // check not Exponent value. public exponent is of 3 bytes only.
                {
                    extraNull = elems % 8; // Sometime null value(byte 0) comes. calculate extra bytes, 
                    elems = elems - extraNull; // get exact data length
                }
                if (extraNull > 0)
                    binr.ReadBytes(extraNull); //read extra null(0) value to remove 
                byteData = binr.ReadBytes(elems); // get exact data.
                return byteData;
                //End 
            }

            public static String getBytesToHexStr(byte[] bArray)
            {
                StringBuilder hex = new StringBuilder(bArray.Length * 2);
                foreach (byte b in bArray)
                    hex.AppendFormat("{0:X2}", b);
                return hex.ToString();
            }


            private bool OnlyHexInString(string test)
            {
                // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
                return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
            }
            string getBytesAsString(byte[] bytes)
            {
                string strBytes = string.Empty;
                foreach (byte bte in bytes)
                {
                    strBytes += ":" + bte;
                }
                if (strBytes.Length > 0)
                    strBytes = strBytes.Remove(0, 1);
                return strBytes;
            }

            #region Generate RSA Key

            public String ExportPublicKeyToPEMFormat1(RSACryptoServiceProvider csp)
            {
                StringBuilder sbPubKey = new StringBuilder();

                TextWriter outputStream = new StringWriter();
                var parameters = csp.ExportParameters(false);

                var format = "81";
                sbPubKey.Append(format);

                var mod = parameters.Modulus.Length.ToString("X2") + getBytesToHexStr(parameters.Modulus);
                sbPubKey.Append(mod);

                var exp = parameters.Exponent.Length.ToString("X2") + getBytesToHexStr(parameters.Exponent);
                sbPubKey.Append(exp);

                sbPubKey.Append("00");

                sbPubKey.Append("0005");

                using (var stream = new MemoryStream())
                {
                    var writer = new BinaryWriter(stream);
                    writer.Write((byte)0x30); // SEQUENCE
                    using (var innerStream = new MemoryStream())
                    {
                        var innerWriter = new BinaryWriter(innerStream);
                        EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                        EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent);

                        //All Parameter Must Have Value so Set Other Parameter Value Whit Invalid Data  (for keeping Key Structure  use "parameters.Exponent" value for invalid data)
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.D
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.P
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.Q
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.DP
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.DQ
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.InverseQ

                        var length = (int)innerStream.Length;
                        EncodeLength(writer, length);
                        writer.Write(innerStream.GetBuffer(), 0, length);
                    }
                    byte[] byteData = new Byte[stream.Length];
                    Array.Copy(stream.GetBuffer(), byteData, (int)stream.Length);
                    var base64 = getBytesToHexStr(byteData);
                    //var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length);
                    return base64;
                    //outputStream.WriteLine("-----BEGIN PUBLIC KEY-----");
                    // Output as Base64 with lines chopped at 64 characters
                    //for (var i = 0; i < base64.Length; i += 64)
                    //{
                    //    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                    //}
                    //outputStream.WriteLine("-----END PUBLIC KEY-----");
                    //return outputStream.ToString();
                }
            }

            public String ExportPublicKeyToPEMFormat(RSACryptoServiceProvider csp)
            {
                TextWriter outputStream = new StringWriter();
                var parameters = csp.ExportParameters(false);
                using (var stream = new MemoryStream())
                {
                    var writer = new BinaryWriter(stream);
                    writer.Write((byte)0x30); // SEQUENCE
                    using (var innerStream = new MemoryStream())
                    {
                        var innerWriter = new BinaryWriter(innerStream);
                        EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                        EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent);

                        //All Parameter Must Have Value so Set Other Parameter Value Whit Invalid Data  (for keeping Key Structure  use "parameters.Exponent" value for invalid data)
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.D
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.P
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.Q
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.DP
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.DQ
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent); // instead of parameters.InverseQ

                        var length = (int)innerStream.Length;
                        EncodeLength(writer, length);
                        writer.Write(innerStream.GetBuffer(), 0, length);
                    }
                    byte[] byteData = new Byte[stream.Length];
                    Array.Copy(stream.GetBuffer(), byteData, (int)stream.Length);
                    var base64 = getBytesToHexStr(byteData);
                    //var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length);
                    return base64;
                    //outputStream.WriteLine("-----BEGIN PUBLIC KEY-----");
                    // Output as Base64 with lines chopped at 64 characters
                    //for (var i = 0; i < base64.Length; i += 64)
                    //{
                    //    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                    //}
                    //outputStream.WriteLine("-----END PUBLIC KEY-----");
                    //return outputStream.ToString();
                }
            }

            public string ExportPrivateKeyToPEMFormat(RSACryptoServiceProvider csp)
            {
                TextWriter outputStream = new StringWriter();
                if (csp.PublicOnly) throw new ArgumentException("CSP does not contain a private key", "csp");
                var parameters = csp.ExportParameters(true);
                using (var stream = new MemoryStream())
                {
                    var writer = new BinaryWriter(stream);
                    writer.Write((byte)0x30); // SEQUENCE
                    using (var innerStream = new MemoryStream())
                    {
                        var innerWriter = new BinaryWriter(innerStream);
                        EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                        EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                        EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                        EncodeIntegerBigEndian(innerWriter, parameters.D);
                        EncodeIntegerBigEndian(innerWriter, parameters.P);
                        EncodeIntegerBigEndian(innerWriter, parameters.Q);
                        EncodeIntegerBigEndian(innerWriter, parameters.DP);
                        EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                        EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                        var length = (int)innerStream.Length;
                        EncodeLength(writer, length);
                        writer.Write(innerStream.GetBuffer(), 0, length);
                    }

                    var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length);
                    return base64;
                    //outputStream.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
                    // Output as Base64 with lines chopped at 64 characters
                    //for (var i = 0; i < base64.Length; i += 64)
                    //{
                    //    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                    //}
                    //outputStream.WriteLine("-----END RSA PRIVATE KEY-----");
                    //return outputStream.ToString();
                }
            }

            private void EncodeLength(BinaryWriter stream, int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException("length", "Length must be non-negative");
                if (length < 0x80)
                {
                    // Short form
                    stream.Write((byte)length);
                }
                else
                {
                    // Long form
                    var temp = length;
                    var bytesRequired = 0;
                    while (temp > 0)
                    {
                        temp >>= 8;
                        bytesRequired++;
                    }
                    stream.Write((byte)(bytesRequired | 0x80));
                    for (var i = bytesRequired - 1; i >= 0; i--)
                    {
                        stream.Write((byte)(length >> (8 * i) & 0xff));
                    }
                }
            }

            private void EncodeIntegerBigEndian(BinaryWriter stream, byte[] value, bool forceUnsigned = true)
            {
                stream.Write((byte)0x02); // INTEGER
                var prefixZeros = 0;
                for (var i = 0; i < value.Length; i++)
                {
                    if (value[i] != 0) break;
                    prefixZeros++;
                }
                if (value.Length - prefixZeros == 0)
                {
                    EncodeLength(stream, 1);
                    stream.Write((byte)0);
                }
                else
                {
                    if (forceUnsigned && value[prefixZeros] > 0x7f)
                    {
                        // Add a prefix zero to force unsigned if the MSB is 1
                        EncodeLength(stream, value.Length - prefixZeros + 1);
                        stream.Write((byte)0);
                    }
                    else
                    {
                        EncodeLength(stream, value.Length - prefixZeros);
                    }
                    for (var i = prefixZeros; i < value.Length; i++)
                    {
                        stream.Write(value[i]);
                    }
                }
            }
            #endregion
        }


        public static class TripleDESEncryption
        {
            public static string Encrypt(string input, string key)
            {
                byte[] firstArray = GetBinary(input);
                // byte[] inputArray = new byte[input.Length];
                //Set Default values
                //for (int i = 0; i < inputArray.Length; i++)
                //{
                //    inputArray[i] = 0xFF;
                //}
                //for (int i = 0; i < firstArray.Length; i++)
                //{
                //    inputArray[i] = firstArray[i];
                //}
                byte[] keys = Encoding.ASCII.GetBytes(key);
                String keyHEX = BitConverter.ToString(keys).Replace("-", " ");

                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = GetBinary(keyHEX);

                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(firstArray, 0, firstArray.Length);
                tripleDES.Clear();
                //string value = BitConverter.ToString(resultArray).Replace("-", " ");
                //value = value.Replace("FF", "");
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }

            public static string Decrypt(string input, string key)
            {
                byte[] inputArray = Convert.FromBase64String(input);
                byte[] keys = Encoding.ASCII.GetBytes(key);
                String keyHEX = BitConverter.ToString(keys).Replace("-", " ");
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = GetBinary(keyHEX);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                string value = BitConverter.ToString(resultArray).Replace("-", "");
                //value = value.Replace("F", "");
                return value;
            }

            public static string EncryptDigitWithHexKey(string input, string key)
            {
                // byte[] keys = Encoding.ASCII.GetBytes(key);
                //String keyHEX = key;// BitConverter.ToString(keys).Replace("-", " ");
                byte[] firstArray = GetBinary(input);
                //byte[] inputArray = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

                //for (int i = 0; i < firstArray.Length; i++)
                //{
                //    inputArray[i] = firstArray[i];
                //}
                // byte[] keys = Encoding.ASCII.GetBytes(key);
                String keyHEX = key;// BitConverter.ToString(keys).Replace("-", " ");

                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = GetBinary(keyHEX);
                //tripleDES.GenerateIV();
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(firstArray, 0, firstArray.Length);
                tripleDES.Clear();
                //string value = BitConverter.ToString(resultArray).Replace("-", " ");
                //value = value.Replace("FF", "");
                string pnBlock = BitConverter.ToString(resultArray).Replace("-", "");
                return pnBlock;
                //return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            public static string DecryptDigitWithHexKey(string input, string key)
            {
                byte[] inputArray = GetBinary(input); // Convert.FromBase64String(input);
                                                      // byte[] keys = Encoding.ASCII.GetBytes(key);
                String keyHEX = key;// BitConverter.ToString(keys).Replace("-", " ");
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = GetBinary(keyHEX);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                string value = BitConverter.ToString(resultArray).Replace("-", string.Empty);
                //value = value.Replace("F", string.Empty);
                return value;
            }
            public static string EncryptDigit(string input, string key)
            {
                byte[] firstArray = GetBinary(input);
                byte[] inputArray = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

                for (int i = 0; i < firstArray.Length; i++)
                {
                    inputArray[i] = firstArray[i];
                }
                byte[] keys = Encoding.ASCII.GetBytes(key);
                String keyHEX = BitConverter.ToString(keys).Replace("-", " ");

                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = GetBinary(keyHEX);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                //string value = BitConverter.ToString(resultArray).Replace("-", " ");
                //value = value.Replace("FF", "");
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }

            public static string DecryptDigit(string input, string key)
            {
                byte[] inputArray = Convert.FromBase64String(input);
                byte[] keys = Encoding.ASCII.GetBytes(key);
                String keyHEX = BitConverter.ToString(keys).Replace("-", " ");
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = GetBinary(keyHEX);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                string value = BitConverter.ToString(resultArray).Replace("-", string.Empty);
                value = value.Replace("F", string.Empty);
                return value;
            }

            public static byte[] GetBinary(String hex)
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }

            public static string GetBinaryByte(byte[] ba)
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            }

            //static byte[] GetBinary1(string hexMessage)
            //{
            //    SoapHexBinary shb = SoapHexBinary.Parse(hexMessage);
            //    return shb.Value;
            //}

            static TripleDES CreateDES(byte[] key)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                TripleDES des = new TripleDESCryptoServiceProvider();
                des.Key = md5.ComputeHash(key);// md5.ComputeHash(GetBinary(key));//md5.ComputeHash(
                                               //des.IV = new byte[des.BlockSize / 8];
                des.Padding = PaddingMode.None;
                des.Mode = CipherMode.ECB;
                return des;
            }
            public static string EncryptionTest(byte[] input, byte[] key)
            {
                TripleDES des = CreateDES(key);
                ICryptoTransform ct = des.CreateEncryptor();
                // byte[] input = GetBinary(PlainText);
                var resultArray = ct.TransformFinalBlock(input, 0, input.Length);
                return BitConverter.ToString(resultArray).Replace("-", "");
            }
        }

        public class FileWriter
        {
            public static void WriteTextInFile(string path, string data)
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(data);
                        //tw.WriteLine("");
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(data);
                        //sw.WriteLine("");
                        sw.Close();
                    }
                }
            }
        }

        public enum ProcCodeType
        {
            MTmk = 960310,
            STmk = 960311,
            Tmk = 960300,
            Tdk = 960301,
            Tsk = 960400,
            Bzk = 960500,
            Buk = 960600,
        }
        public enum KeyType
        {
            KTM = 1,
            TMK = 2,
            DPK = 3,
            PPK = 4,
            ZPK = 5,

        }

        public enum HSMType
        {
            BonusHub = 1,
            SafeNet = 2,
            Thales = 3,
        }

        //public static class ConstantValue
        //{
        //    public static bool IS_AB_KEY_UNIQUE_PER_TERMINAL
        //    {
        //        get
        //        {
        //            return Convert.ToBoolean(ConfigurationManager.AppSettings["IS_AB_KEY_UNIQUE_PER_TERMINAL"]);
        //        }
        //    }
        //}
    }
}

