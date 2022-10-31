using Dapper;
using HPPay.DataModel.HLFL;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace HPPay_WebApi.ActionFilters
{
    public class HLFLAPIAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly DapperContext _context;
        IConfiguration _configuration;

        public HLFLAPIAuthenticationFilter(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public class Root
        {
            public string Username;
            public string Password;
            public string SecurityToken;
            //public string ContentType;
        }
        public class RootTrans
        {
            public string ControlCardNumber;
            public string CustomerId;
            public decimal Amount;
            public string TransactionDate;
            public string TransactionNumber;
            public string HashKey;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // string authString;
            HttpRequest request = context.HttpContext.Request;
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var actionName = descriptor.ActionName;
            var controllerName = descriptor.ControllerName;

            // context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            context.HttpContext.Request.EnableBuffering();
            //StreamReader reader = new StreamReader(context.HttpContext.Request.Body);

            var bodyStr = "";
            var req = context.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            // req.EnableRewind();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }

            // Rewind, so the core is not lost when it looks the body for the request
            req.Body.Position = 0;


            // var body = reader.ReadToEnd();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            context.HttpContext.Request.Headers.TryGetValue("Username", out var OutUserName);
            context.HttpContext.Request.Headers.TryGetValue("Password", out var OutPassword);
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out var OutSecurityToken);
            //context.HttpContext.Request.Headers.TryGetValue("ContentType", out var OutContentType);

            if (actionName != "HLFLCreateCard")
            {              

                bodyStr = bodyStr.Replace("'", "''");
                Root objObject = JsonConvert.DeserializeObject<Root>(bodyStr, settings);

                bodyStr = bodyStr.Replace("'", "''");
                RootTrans objTrans = JsonConvert.DeserializeObject<RootTrans>(bodyStr, settings);

                //string transactionId = objObject.TransactionId;

                objObject.Username = OutUserName.ToString();
                objObject.Password = OutPassword.ToString();
                objObject.SecurityToken = OutSecurityToken.ToString();
                //objObject.ContentType = OutContentType.ToString();

                if (string.IsNullOrEmpty(objObject.Username))
                {
                    context.Result = new JsonResult
                         (
                         new RouteValueDictionary(new HLFLAPIAuthenticationFailureResult("Mandatory Field is missing: Username", request, actionName).Execute()
                         ));
                }
                else if (string.IsNullOrEmpty(objObject.Password))
                {
                    context.Result = new JsonResult
                         (
                         new RouteValueDictionary(new HLFLAPIAuthenticationFailureResult("Mandatory Field is missing: Password", request, actionName).Execute()
                         ));
                }
                else if (string.IsNullOrEmpty(objObject.SecurityToken))
                {
                    context.Result = new JsonResult
                         (
                         new RouteValueDictionary(new HLFLAPIAuthenticationFailureResult("Mandatory Field is missing: Authorization", request, actionName).Execute()
                         ));
                }
                 
                else
                {
                    IEnumerable<HLFLAPIValidateCredentialsModelOutput> Validation = new List<HLFLAPIValidateCredentialsModelOutput>();
                    if (objObject.Username.Length > 16 && objObject.Password.Length > 16)
                    {
                        using (AesManaged aes = new AesManaged())
                        {
                            byte[] encryptedUser = ObjectToByteArray(objObject.Username);
                            //Encrypt(objObject.Username, aes.Key, aes.IV);
                            string decryptedUser = Decrypt(encryptedUser, aes.Key, aes.IV);
                            objObject.Username = decryptedUser.Substring(8, decryptedUser.Length - 8);

                            byte[] encryptedPswd = ObjectToByteArray(objObject.Password);
                            //Encrypt(objObject.Password, aes.Key, aes.IV);
                            string dncryptedPswd = Decrypt(encryptedPswd, aes.Key, aes.IV);
                            objObject.Password = dncryptedPswd.Substring(8, dncryptedPswd.Length - 8);

                        }
                    }
                    string hashedData=null;
                    if (actionName == "HLFLProcessCustomerRecharge")
                    {
                        string plainData = objTrans.CustomerId + objTrans.ControlCardNumber + objTrans.Amount + objTrans.TransactionDate +
                        objTrans.TransactionNumber + _configuration.GetSection("HLFLSettings:SecurityToken").Value;

                        hashedData = ComputeSha256Hash(plainData);
                    }
                      if (objTrans.HashKey == null || objTrans.HashKey == hashedData)
                     
                        {
                        var procedureName = "UspHLFLAPIsValidateCredentials";
                        var parameters = new DynamicParameters();
                        parameters.Add("Username", objObject.Username, DbType.String, ParameterDirection.Input);
                        parameters.Add("Password", objObject.Password, DbType.String, ParameterDirection.Input);
                        parameters.Add("SecurityToken", objObject.SecurityToken.Substring(4), DbType.String, ParameterDirection.Input);
                        parameters.Add("CustomerId", objTrans.CustomerId, DbType.String, ParameterDirection.Input);
                        //parameters.Add("ControlCardNumber", objTrans.ControlCardNumber, DbType.String, ParameterDirection.Input);
                        //parameters.Add("Amount", objTrans.Amount, DbType.Decimal, ParameterDirection.Input);
                        //parameters.Add("TransactionDate", objTrans.TransactionDate, DbType.String, ParameterDirection.Input);
                        //parameters.Add("TransactionNumber", objTrans.TransactionNumber, DbType.String, ParameterDirection.Input);
                        //parameters.Add("ClientCheckSum", objTrans.HashKey, DbType.String, ParameterDirection.Input);
                        parameters.Add("AuthKey", _configuration.GetSection("HLFLSettings:SecurityToken").Value, DbType.String, ParameterDirection.Input);
                        using var connection = _context.CreateConnection();
                        Validation = connection.Query<HLFLAPIValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                        foreach (var obj in Validation)
                        {
                            if (obj.Status == "1")
                            {
                                context.Result = new JsonResult
                                     (
                                     new RouteValueDictionary(new HLFLAPIAuthenticationFailureResult(obj.ResponseMessage, request, actionName).Execute()
                                     ));
                            }
                            break;
                        }
                    }
                    else 
                    {                        
                        context.Result = new JsonResult
                                     (
                                     new RouteValueDictionary(new HLFLAPIAuthenticationFailureResult("Invalid hasKey", request, actionName).Execute()
                                     ));
                    }
                }
            }
                if (actionName == "HLFLCreateCard")
                {
                    HttpContext httpContext = context.HttpContext;
                    if (OutUserName.ToString() != "")
                    {
                        httpContext.Session.SetString("HLFLUsername", OutUserName);
                    }
                    if (OutPassword.ToString() != "")
                    {
                        httpContext.Session.SetString("HLFLPassword", OutPassword);
                    }
                    if (OutSecurityToken.ToString() != "")
                    if (OutSecurityToken.ToString() != "")
                    {
                        httpContext.Session.SetString("HLFLSecurityToken", OutSecurityToken.ToString().Substring(4) );
                    }
                }
        }


        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
        static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return encrypted;
        }
        static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string Dectext = null;

            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            Dectext = reader.ReadToEnd();
                    }
                }
            }
            return Dectext;
        }


        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public class HLFLAPIAuthenticationFailureResult
        {
            public string ReasonPhrase = string.Empty;
            public string MethodName = string.Empty;
            public HttpRequest Request { get; set; }

            public HLFLAPIAuthenticationFailureResult(string reasonphrase, HttpRequest request, string methodName)
            {
                MethodName = methodName;
                ReasonPhrase = reasonphrase;
                Request = request;
            }

            public HLFLAPIReponseMessage Execute()
            {

                HLFLAPIReponseMessage response = new HLFLAPIReponseMessage
                {
                    Status = "1",
                    ResponseMessage = ReasonPhrase
                };
                return (response);

            }
        }
    }
}
