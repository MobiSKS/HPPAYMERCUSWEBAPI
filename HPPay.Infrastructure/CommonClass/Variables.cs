using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.Infrastructure.CommonClass
{

    public class Variables
    {
        private readonly IConfiguration _configuration;
        public Variables(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string FunGenerateStaticStringUId()
        {
            //byte[] bytBuffer = Guid.NewGuid().ToByteArray();
            return DateTime.Now.ToString("yyMMddfff"); //BitConverter.ToInt64(bytBuffer, 0).ToString();
        }
        //public string GetConnection()
        //{
        //    return ConfigurationManager.AppSettings["ConnectionString"].ToString();
        //}
        public bool Chk_APIKey_Validation(string API_Key)
        {
            if (API_Key == StrAPI_Key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Chk_SecretKey_Validation(string Secret_Key)
        {
            if (Secret_Key == StrSecretKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Chk_API_Key_SecretKey_Validation(string API_Key, string Secret_Key)
        {
            if (Secret_Key == StrSecretKey && API_Key == StrAPI_Key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void PostSMSRequest(string Url, out string Result)
        {
            string Ststus;
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                Ststus = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Ststus = ex.Message;
            }
            Result = Ststus;
        }

        public static bool IsPhoneNumber(string number)
        {
            //return Regex.Match(number, @"^(\+[6-9]{10})$").Success;
            string CheckMobileNo = number[..1];
            //string CheckMobileNo = number.Substring(0, 1);
            bool IsResult;
            if (CheckMobileNo.Contains('6') || CheckMobileNo.Contains('7') || CheckMobileNo.Contains('8') || CheckMobileNo.Contains('9'))
                IsResult = true;
            else
                IsResult = false;
            return IsResult;
        }

        public static string RightString(string value, int length)
        {
            //return value.Substring(value.Length - length);
            return value[^length..];
        }

        public string StrStoreCode
        {
            get
            {
                return _configuration.GetSection("TokenSettings:StoreCode").Value.ToString();
            }
        }

        public string StrSecretKey
        {
            get
            {
                return _configuration.GetSection("TokenSettings:SecretKey").Value.ToString();
            }
        }

        public string StrAPI_Key
        {
            get
            {
                return _configuration.GetSection("TokenSettings:API_Key").Value.ToString();
            }
        }

        public string StrAPI_HPPayConnectionString
        {
            get
            {
                return _configuration.GetSection("ConnectionStrings:HPPayConnectionString").Value.ToString();
            }
        }

        public static async Task<HttpResponseMessage> APICalls(string apiurl, string data, string authIdPwd, string BaseAddress)
        {
            try
            {
                //http://13.126.163.22:9090/api/HPPay/checkCustomerTxnStatus

                string result = string.Empty;
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://13.126.163.22:9090");
                client.DefaultRequestHeaders.Accept.Clear();
                if (authIdPwd != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", authIdPwd);
                }
                var res = client.PostAsync(apiurl, content).Result;
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }

        }

        public static async Task<HttpResponseMessage> CallPostAPI(string apiurl, string data, string authorizationToken = "")
        {
            string result = string.Empty;
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://dtplus-test1.cargofl.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            if (authorizationToken != "")
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", authorizationToken);
            }

            return client.PostAsync(apiurl, content).Result;

        }
        public static async Task<HttpResponseMessage> CallAPI(string apiurl, string data, string authIdPwd)
        {
            try
            {


                string result = string.Empty;
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://dtplus-test1.cargofl.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                if (authIdPwd != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(authIdPwd)));
                }
                return client.PostAsync(apiurl, content).Result;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }

        }



        public static async Task<HttpResponseMessage> CallIciciAPI(string apiurl, string data, string APIClient_ID, string API_KEY)
        {
            try
            {


                string result = string.Empty;
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://dtplus-test1.cargofl.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("APIClient_ID", APIClient_ID);
                client.DefaultRequestHeaders.Add("API_KEY", API_KEY);

                return client.PostAsync(apiurl, content).Result;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }

        }
        public static async Task<HttpResponseMessage> CallLnTAPI(string apiurl, string data)
        {
            try
            {
                string result = string.Empty;
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "362450350df94c8b8322e6bae9b83e0c");

                return client.PostAsync(apiurl, content).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetUniqueNumber()
        {
            DateTime _now = DateTime.Now;
            string _dd = _now.ToString("dd"); //
            string _mm = _now.ToString("MM");
            string _yy = _now.ToString("yyyy");
            string _hh = _now.Hour.ToString();
            string _min = _now.Minute.ToString();
            string _ss = _now.Second.ToString();

            return _dd + _hh + _mm + _min + _ss + _yy;
        }
    }
}
