using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace HPPay.Infrastructure.CommonClass
{
    public class APIHelper
    {
        public static string _connectionString;

        public static async Task<HttpResponseMessage> PostURI(Uri u, HttpContent c, string authIdPwd)
        {
            var response = new HttpResponseMessage();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Add("Authorization", "aede47db55844c07ba7309934a3629e6");
                    client.DefaultRequestHeaders.Add("Authorization", authIdPwd);
                    HttpResponseMessage result = await client.PostAsync(u, c);

                    response = result;
                }

                //Dictionary<string, object> Fasttag_param_output = new Dictionary<string, object>
                //    {
                //        { "LPG_URL", u.AbsoluteUri },
                //        { "LPG_Input", c.ReadAsStringAsync().Result.ToString() },
                //        { "LPG_Output", await response.Content.ReadAsStringAsync() },

                //};
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message.ToString())
                };
            }

            return response;
        }

        public static async Task<HttpResponseMessage> KarzaPostURI(Uri u, HttpContent c, string Karzakey)
        {
            var response = new HttpResponseMessage();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-karza-key", Karzakey);
                    HttpResponseMessage result = await client.PostAsync(u, c);

                    response = result;
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message.ToString())
                };
            }

            return response;
        }

        public static async Task<HttpResponseMessage> PostURI_Fastlane_CustomerRegistration(Uri u, HttpContent c, string action, string apikey)
        {
            var response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("ACTION", action); //"CUSTREGISTRATION"
                client.DefaultRequestHeaders.Add("APIKEY", apikey); //"TESTAGS0000000000001"
                HttpResponseMessage result = await client.PostAsync(u, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result;
                }
            }

            return response;
        }

        public static async Task<HttpResponseMessage> PostURI_Fastlane_VehicleAuthentication(Uri u, HttpContent c, string xkarzakey)
        {
            var response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-karza-key", xkarzakey);
                HttpResponseMessage result = await client.PostAsync(u, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result;
                }
            }

            return response;
        }

        public static async Task<HttpResponseMessage> PostURI_Fastlane_VehicleRegistration(Uri u, HttpContent c, string action, string apikey)
        {
            var response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("ACTION", action); //"CUSTREGISTRATION"
                client.DefaultRequestHeaders.Add("APIKEY", apikey); //"TESTAGS0000000000001"
                HttpResponseMessage result = await client.PostAsync(u, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result;
                }
            }

            return response;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
