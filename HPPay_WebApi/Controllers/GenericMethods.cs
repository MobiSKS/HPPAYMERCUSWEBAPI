using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HPPay_WebApi.Controllers
{
    public class GenericMethods
    {
        public string XMLFormation(Dictionary<string, string> tmpobj, string transaactiontype)
        {
            StringBuilder xmlstring = new StringBuilder();


            try
            {

                switch (transaactiontype)
                {
                    case "http_tranportal":
                        //<request><card>4222220000048916</card><cvv2>234</cvv2><currencycode>356</currencycode><expyear>2025</expyear>
                        //<expmonth>12</expmonth><langid>USA</langid><member>DFTEWREW</member><amt>324</amt><action>1</action><trackid>12345</trackid><udf1>UDF1</udf1><udf2>UDF2</udf2>
                        //<udf3>UDF3</udf3><udf4>UDF4</udf4><udf5>UDF5</udf5><id>963258</id><password>admin@123</password></request>

                        xmlstring.Append("<request>");

                        if (!string.IsNullOrEmpty(tmpobj["ReqCardNumber"]))
                        {
                            xmlstring.Append("<card>");
                            xmlstring.Append(tmpobj["ReqCardNumber"].ToString());
                            xmlstring.Append("</card>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqCvv"]))
                        {
                            xmlstring.Append("<cvv2>");
                            xmlstring.Append(tmpobj["ReqCvv"].ToString());
                            xmlstring.Append("</cvv2>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["reqCurrencycode"]))
                        {
                            xmlstring.Append("<currencycode>");
                            xmlstring.Append(tmpobj["reqCurrencycode"].ToString());
                            xmlstring.Append("</currencycode>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqExpYear"]))
                        {
                            xmlstring.Append("<expyear>");
                            xmlstring.Append(tmpobj["ReqExpYear"].ToString());
                            xmlstring.Append("</expyear>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqExpMonth"]))
                        {
                            xmlstring.Append("<expmonth>");
                            xmlstring.Append(tmpobj["ReqExpMonth"].ToString());
                            xmlstring.Append("</expmonth>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqLanguid"]))
                        {
                            xmlstring.Append("<langid>");
                            xmlstring.Append(tmpobj["reqLanguid"].ToString());
                            xmlstring.Append("</langid>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqstrmember"]))
                        {
                            xmlstring.Append("<member>");
                            xmlstring.Append(tmpobj["reqstrmember"].ToString());
                            xmlstring.Append("</member>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqAmt"]))
                        {
                            xmlstring.Append("<amt>");
                            xmlstring.Append(tmpobj["ReqAmt"].ToString());
                            xmlstring.Append("</amt>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqAction"]))
                        {
                            xmlstring.Append("<action>");
                            xmlstring.Append(tmpobj["ReqAction"].ToString());
                            xmlstring.Append("</action>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqTrackid"]))
                        {
                            xmlstring.Append("<trackid>");
                            xmlstring.Append(tmpobj["reqTrackid"].ToString());
                            xmlstring.Append("</trackid>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf1"]))
                        {
                            xmlstring.Append("<udf1>");
                            xmlstring.Append(tmpobj["udf1"].ToString());
                            xmlstring.Append("</udf1>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf2"]))
                        {
                            xmlstring.Append("<udf2>");
                            xmlstring.Append(tmpobj["udf2"].ToString());
                            xmlstring.Append("</udf2>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf3"]))
                        {
                            xmlstring.Append("<udf3>");
                            xmlstring.Append(tmpobj["udf3"].ToString());
                            xmlstring.Append("</udf3>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf4"]))
                        {
                            xmlstring.Append("<udf4>");
                            xmlstring.Append(tmpobj["udf4"].ToString());
                            xmlstring.Append("</udf4>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf5"]))
                        {
                            xmlstring.Append("<udf5>");
                            xmlstring.Append(tmpobj["udf5"].ToString());
                            xmlstring.Append("</udf5>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalId"]))
                        {
                            xmlstring.Append("<id>");
                            xmlstring.Append(tmpobj["ReqTranportalId"].ToString());
                            xmlstring.Append("</id>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalPassword"]))
                        {
                            xmlstring.Append("<password>");
                            xmlstring.Append(tmpobj["ReqTranportalPassword"].ToString());
                            xmlstring.Append("</password>");
                        }
                        xmlstring.Append("</request>");
                        break;

                    case "hosted_http":

                        if (!string.IsNullOrEmpty(tmpobj["ReqAmt"]))
                        {
                            xmlstring.Append("amt=");
                            xmlstring.Append(tmpobj["ReqAmt"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqAction"]))
                        {
                            xmlstring.Append("&action=");
                            xmlstring.Append(tmpobj["ReqAction"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqTrackid"]))
                        {
                            xmlstring.Append("&trackid=");
                            xmlstring.Append(tmpobj["reqTrackid"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf1"]))
                        {
                            xmlstring.Append("&udf1=");
                            xmlstring.Append(tmpobj["udf1"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf2"]))
                        {
                            xmlstring.Append("&udf2=");
                            xmlstring.Append(tmpobj["udf2"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf3"]))
                        {
                            xmlstring.Append("&udf3=");
                            xmlstring.Append(tmpobj["udf3"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf4"]))
                        {
                            xmlstring.Append("&udf4=");
                            xmlstring.Append(tmpobj["udf4"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf5"]))
                        {
                            xmlstring.Append("&udf5=");
                            xmlstring.Append(tmpobj["udf5"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqCurrencycode"]))
                        {
                            xmlstring.Append("&currencycode=");
                            xmlstring.Append(tmpobj["reqCurrencycode"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqLanguid"]))
                        {
                            xmlstring.Append("&langid=");
                            xmlstring.Append(tmpobj["reqLanguid"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqLanguid"]))
                        {
                            xmlstring.Append("&langid=");
                            xmlstring.Append(tmpobj["reqLanguid"].ToString());
                        }

                        if (!string.IsNullOrEmpty(tmpobj["responseURL"]))
                        {
                            xmlstring.Append("&responseURL=");
                            xmlstring.Append(tmpobj["responseURL"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["errorURL"]))
                        {
                            xmlstring.Append("&errorURL=");
                            xmlstring.Append(tmpobj["errorURL"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalPassword"]))
                        {
                            xmlstring.Append("&password=");
                            xmlstring.Append(tmpobj["ReqTranportalPassword"].ToString());
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalId"]))
                        {
                            xmlstring.Append("&id=");
                            xmlstring.Append(tmpobj["ReqTranportalId"].ToString());
                            xmlstring.Append("&");
                        }


                        break;

                    case "debitpin":


                        xmlstring.Append("<request>");

                        if (!string.IsNullOrEmpty(tmpobj["ReqCardNumber"]))
                        {
                            xmlstring.Append("<card>");
                            xmlstring.Append(tmpobj["ReqCardNumber"].ToString());
                            xmlstring.Append("</card>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqCvv"]))
                        {
                            xmlstring.Append("<cvv2>");
                            xmlstring.Append(tmpobj["ReqCvv"].ToString());
                            xmlstring.Append("</cvv2>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["reqCurrencycode"]))
                        {
                            xmlstring.Append("<currencycode>");
                            xmlstring.Append(tmpobj["reqCurrencycode"].ToString());
                            xmlstring.Append("</currencycode>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqExpYear"]))
                        {
                            xmlstring.Append("<expyear>");
                            xmlstring.Append(tmpobj["ReqExpYear"].ToString());
                            xmlstring.Append("</expyear>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqExpMonth"]))
                        {
                            xmlstring.Append("<expmonth>");
                            xmlstring.Append(tmpobj["ReqExpMonth"].ToString());
                            xmlstring.Append("</expmonth>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqLanguid"]))
                        {
                            xmlstring.Append("<langid>");
                            xmlstring.Append(tmpobj["reqLanguid"].ToString());
                            xmlstring.Append("</langid>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqstrmember"]))
                        {
                            xmlstring.Append("<member>");
                            xmlstring.Append(tmpobj["reqstrmember"].ToString());
                            xmlstring.Append("</member>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqAmt"]))
                        {
                            xmlstring.Append("<amt>");
                            xmlstring.Append(tmpobj["ReqAmt"].ToString());
                            xmlstring.Append("</amt>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqAction"]))
                        {
                            xmlstring.Append("<action>");
                            xmlstring.Append(tmpobj["ReqAction"].ToString());
                            xmlstring.Append("</action>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqTrackid"]))
                        {
                            xmlstring.Append("<trackid>");
                            xmlstring.Append(tmpobj["reqTrackid"].ToString());
                            xmlstring.Append("</trackid>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf1"]))
                        {
                            xmlstring.Append("<udf1>");
                            xmlstring.Append(tmpobj["udf1"].ToString());
                            xmlstring.Append("</udf1>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf2"]))
                        {
                            xmlstring.Append("<udf2>");
                            xmlstring.Append(tmpobj["udf2"].ToString());
                            xmlstring.Append("</udf2>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf3"]))
                        {
                            xmlstring.Append("<udf3>");
                            xmlstring.Append(tmpobj["udf3"].ToString());
                            xmlstring.Append("</udf3>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf4"]))
                        {
                            xmlstring.Append("<udf4>");
                            xmlstring.Append(tmpobj["udf4"].ToString());
                            xmlstring.Append("</udf4>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf5"]))
                        {
                            xmlstring.Append("<udf5>");
                            xmlstring.Append(tmpobj["udf5"].ToString());
                            xmlstring.Append("</udf5>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalId"]))
                        {
                            xmlstring.Append("<id>");
                            xmlstring.Append(tmpobj["ReqTranportalId"].ToString());
                            xmlstring.Append("</id>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalPassword"]))
                        {
                            xmlstring.Append("<password>");
                            xmlstring.Append(tmpobj["ReqTranportalPassword"].ToString());
                            xmlstring.Append("</password>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["type"]))
                        {
                            xmlstring.Append("<type>");
                            xmlstring.Append(tmpobj["type"].ToString());
                            xmlstring.Append("</type>");
                        }

                        xmlstring.Append("</request>");
                        break;

                    case "support":
                        xmlstring.Append("<request>");

                        if (!string.IsNullOrEmpty(tmpobj["reqCurrencycode"]))
                        {
                            xmlstring.Append("<currencycode>");
                            xmlstring.Append(tmpobj["reqCurrencycode"].ToString());
                            xmlstring.Append("</currencycode>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["reqLanguid"]))
                        {
                            xmlstring.Append("<langid>");
                            xmlstring.Append(tmpobj["reqLanguid"].ToString());
                            xmlstring.Append("</langid>");
                        }

                        if (!string.IsNullOrEmpty(tmpobj["ReqAmt"]))
                        {
                            xmlstring.Append("<amt>");
                            xmlstring.Append(tmpobj["ReqAmt"].ToString());
                            xmlstring.Append("</amt>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqAction"]))
                        {
                            xmlstring.Append("<action>");
                            xmlstring.Append(tmpobj["ReqAction"].ToString());
                            xmlstring.Append("</action>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqTrackid"]))
                        {
                            xmlstring.Append("<trackid>");
                            xmlstring.Append(tmpobj["reqTrackid"].ToString());
                            xmlstring.Append("</trackid>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf1"]))
                        {
                            xmlstring.Append("<udf1>");
                            xmlstring.Append(tmpobj["udf1"].ToString());
                            xmlstring.Append("</udf1>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf2"]))
                        {
                            xmlstring.Append("<udf2>");
                            xmlstring.Append(tmpobj["udf2"].ToString());
                            xmlstring.Append("</udf2>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf3"]))
                        {
                            xmlstring.Append("<udf3>");
                            xmlstring.Append(tmpobj["udf3"].ToString());
                            xmlstring.Append("</udf3>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf4"]))
                        {
                            xmlstring.Append("<udf4>");
                            xmlstring.Append(tmpobj["udf4"].ToString());
                            xmlstring.Append("</udf4>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["udf5"]))
                        {
                            xmlstring.Append("<udf5>");
                            xmlstring.Append(tmpobj["udf5"].ToString());
                            xmlstring.Append("</udf5>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalId"]))
                        {
                            xmlstring.Append("<id>");
                            xmlstring.Append(tmpobj["ReqTranportalId"].ToString());
                            xmlstring.Append("</id>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["ReqTranportalPassword"]))
                        {
                            xmlstring.Append("<password>");
                            xmlstring.Append(tmpobj["ReqTranportalPassword"].ToString());
                            xmlstring.Append("</password>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["reqstrmember"]))
                        {
                            xmlstring.Append("<member>");
                            xmlstring.Append(tmpobj["reqstrmember"].ToString());
                            xmlstring.Append("</member>");
                        }
                        if (!string.IsNullOrEmpty(tmpobj["transid"]))
                        {
                            xmlstring.Append("<transid>");
                            xmlstring.Append(tmpobj["transid"].ToString());
                            xmlstring.Append("</transid>");
                        }

                        xmlstring.Append("</request>");
                        break;

                }

            }
            catch (Exception)
            {

                throw;
            }
            return xmlstring.ToString();
        }

        public string Encrypt(string Data, string Key)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key);
            // byte[] iv = Encoding.ASCII.GetBytes("password");
            byte[] data = Encoding.ASCII.GetBytes(Data);
            byte[] enc = new byte[0];
            TripleDES tdes = TripleDES.Create();
            //tdes.IV = iv;
            tdes.Key = key;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.Zeros;
            ICryptoTransform ict = tdes.CreateEncryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            return Bin2Hex(enc);

        }

        static string Bin2Hex(byte[] bin)
        {
            StringBuilder sb = new StringBuilder(bin.Length * 2);
            foreach (byte b in bin)
            {
                sb.Append(b.ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
        public string Decrypt(string Data, string Key)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key);
            // byte[] iv = Encoding.ASCII.GetBytes("password");
            byte[] data = StringToByteArray(Data);
            byte[] enc = new byte[0];
            TripleDES tdes = TripleDES.Create();
            //  tdes.IV = iv;
            tdes.Key = key;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.Zeros;
            ICryptoTransform ict = tdes.CreateDecryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            String decryptedStr = Encoding.ASCII.GetString(enc);
            if (decryptedStr.StartsWith("<"))
            {
                decryptedStr = decryptedStr.Substring(0, decryptedStr.LastIndexOf('>') + 1);
            }
            else
            {
                decryptedStr = decryptedStr.Substring(0, decryptedStr.LastIndexOf('&') + 1);
            }
            return decryptedStr;
        }


        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length / 2;
            byte[] bytes = new byte[NumberChars];
            StringReader sr = new StringReader(hex);
            for (int i = 0; i < NumberChars; i++)
                bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            sr.Dispose();
            return bytes;
        }

        public DataTable responsedecrpt(string data)
        {
            GenericMethods objgm = new GenericMethods();
            String key = "925555866107925555866114";
            DataTable objDt = new DataTable();
            try
            {

                string result = objgm.Decrypt(data, key);
                // string result = "<resp><result>CAPTURED</result><auth>000000</auth><ref>924710000006</ref><avr>N</avr><postdate>0904</postdate><tranid>201961241330336</tranid><trackid>12345</trackid><payid>-1</payid><udf1>UDF1</udf1><udf2>UDF2</udf2><udf3>UDF3</udf3><udf4>UDF4</udf4><udf5>UDF5</udf5><amt>324.0</amt><authRespCode>00</authRespCode></resp>";
                result = "<resp>" + result + "</resp>";
                if (!string.IsNullOrEmpty(result))
                {
                    objDt = stringDataTable(result);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objDt;

        }
        DataTable stringDataTable(string result)
        {
            DataSet ds = new DataSet();

            using (StringReader stringReader = new StringReader(result))
            {
                ds = new DataSet();
                ds.ReadXml(stringReader);
            }
            DataTable dt = ds.Tables[0];

            return dt;
        }

        public Dictionary<string, string> responsedecrptwithsymbol(string data)
        {
            GenericMethods objgm = new GenericMethods();
            String key = "925555866107925555866114";
            Dictionary<string, string> objDic = new Dictionary<string, string>();
            try
            {

                string result = objgm.Decrypt(data, key);
                //    string result = "paymentid=100201961241057197&result=CAPTURED&auth=000000&avr=N&ref=924710000002&tranid=201961258932815&postdate=0904&trackid=35435&udf1=Test1&udf2=Test2&udf3=Test3&udf4=Test4&udf5=Test+5&amt=1.0&authRespCode=00&";
                string[] str = result.Split('&');


                if (str.Length > 0)
                {
                    for (int tmp = 0; tmp < str.Length - 1; tmp++)
                    {
                        string[] spl = str[tmp].Split('=');
                        if (!string.IsNullOrEmpty(spl[0]))
                        {
                            objDic.Add(spl[0], spl[1]);
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objDic;

        }

        public static async Task<HttpResponseMessage> CallPostAPI(string apiurl, string Reqdata)
        {
            string result = string.Empty;
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(Reqdata, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            return client.PostAsync(apiurl, content).Result;
        }
    }
}