using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Configuration;
using System.Net.Sockets;
using System.IO;
using AtallaHSM.Common;
using AtallaHSM.Model;
using static AtallaHSM.AttalaHSMServiceProvider;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;


namespace AtallaHSM
{
    public partial class AtallaHSMProvider
    {
        static String ipAddr = null;
        static String port = null;
        public readonly string header;
        public readonly string delimeter;
        public readonly string trailer;
        static int headerLength = 4;
        public string MFKAKB;
        public string DEKAKB;
        public string KEKAKB;
        public string PMKAKB;
        public string IMKAKB;
        public static string BinaryLoggingValue;
        private readonly IConfiguration _configuration;
        private AtallaHSMProvider(IConfiguration configuration)
        {
            MFKAKB = _configuration.GetSection("HSMAppSettings:MFKAKB").Value.ToString();
            DEKAKB = _configuration.GetSection("HSMAppSettings:DEKAKB").Value.ToString();
            KEKAKB = _configuration.GetSection("HSMAppSettings:KEKAKB").Value.ToString();
            PMKAKB = _configuration.GetSection("HSMAppSettings:PMKAKB").Value.ToString();
            BinaryLoggingValue = _configuration.GetSection("HSMAppSettings:BinaryLoggingValue").Value.ToString();
            //HSMIP = _configuration.GetSection("HSMAppSettings:HSMIP").Value.ToString();
            //HSMPORT = _configuration.GetSection("HSMAppSettings:HSMPORT").Value.ToString();
        }
        public AtallaHSMProvider(String ipaddr, String port)
        {
            AtallaHSMProvider.ipAddr = ipaddr;
            AtallaHSMProvider.port = port;
            //MFKAKB = ConfigurationManager.AppSettings.Get("MFKAKB").ToString();
            //DEKAKB = ConfigurationManager.AppSettings.Get("DEKAKB").ToString();
            //KEKAKB = ConfigurationManager.AppSettings.Get("KEKAKB").ToString();
            //PMKAKB = ConfigurationManager.AppSettings.Get("PMKAKB").ToString();
            //IMKAKB = ConfigurationManager.AppSettings.Get("IMKAKB").ToString();

            try
            {
                header = "<";
                delimeter = "#";
                trailer = ">";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static String SendAndReceiveHSM(byte[] inputData)
        {
            String strResponse;
            try
            {
                int responseDataLength = 0;
                byte[] lengthByte = new byte[2];            //Length of Data 



                logAtallaCall("AtllaHSMReq", inputData);
                using (TcpClient clientSock = new TcpClient(ipAddr, int.Parse(port)))
                {
                    NetworkStream outNetworkStrm = clientSock.GetStream();
                    //bouts = new BufferedStream(outNetworkStrm);
                    outNetworkStrm.Write(inputData, 0, inputData.Length);
                    outNetworkStrm.Flush();
                    NetworkStream inNetworkStrm = clientSock.GetStream();
                    BufferedStream bufferStrmReader = new BufferedStream(inNetworkStrm);

                    byte[] outputData = new byte[16 * 1024];
                    int nread = bufferStrmReader.Read(outputData, 0, outputData.Length);// length_of_response);
                    byte[] resData = new byte[nread];
                    Array.Copy(outputData, resData, nread);
                    //strResponse = ConversionManager.BytesToHexStr(outputData);
                    strResponse = ConversionManager.BytesToString(resData);
                    logAtallaCall("AtallaHSMResp", outputData);

                    //strResponse = ConversionManager.BytesToString(outputData);
                }
            }
            catch (Exception ex)
            {
                LoggerUtility.Logging(new LogInfo() { Level = LogLevel.ERROR, ShortDescription = "AtallaHSM.AtallaHSMProvider.SendAndReceiveHSM Exception", Message = ex.Message });
                throw ex;
            }
            return strResponse;
        }



        static void logAtallaCall(string logName, byte[] outData)
        {
            int truncatedPacketLength = Convert.ToInt32(BinaryLoggingValue);
            StringBuilder logres = new StringBuilder();
            if (outData.Length > truncatedPacketLength - 9)
            {
                logres = new StringBuilder(BitConverter.ToString(outData.Take(truncatedPacketLength - 9).ToArray()).Replace("-", ""));
            }
            else
            {
                logres = new StringBuilder(BitConverter.ToString(outData).Replace("-", " "));
            }
            LoggerUtility.Logging(new LogInfo() { Level = LogLevel.INFO, ShortDescription = logName, Message = logres.ToString() });

            //  log.Info(logName + ":" + logres);
        }



        public HSMResponseInfo GenerateKey(string keyScheme, string keyType)
        {
            var request = new AT93RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_GENR_KEY_API,
                Mode = KeyValueType.HexaDecimalType,
                KeyType = keyType,// KeyType.TPK,
                KeyScheme = keyScheme,
                KeyLength = Convert.ToString((int)KeyLengthType.U),
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion

            return RequestHSM(request.CommandCode, request);
        }
        public HSMResponseInfo GenerateKey(string keyScheme, string keyType, string keyToEncUnder, char keyTypeFlagToEncUnder, string encryptionKeyScheme)
        {
            var request = new AT93RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_GENR_KEY_API,
                Mode = ModeFlag.GeneratekeyAndEncryptUnderTMK,
                KeyType = keyType,// KeyType.TPK,
                KeyScheme = keyScheme,
                Delimiter = delimeter,
                TMKFlag = keyTypeFlagToEncUnder.ToString(),
                TMK = keyToEncUnder,
                DPK_PPK_KeyScheme = encryptionKeyScheme // KeyScheme.EncryptUnderTheTMK

            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion

            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo GenerateKey(string keyScheme, string keyType, string keyToEncUnder)
        {
            var request = new AT93RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_GENR_KEY_API,
                Mode = ModeFlag.GeneratekeyAndEncryptUnderTMK,
                KeyType = keyType,// KeyType.TPK,
                KeyScheme = keyScheme,
                Delimiter = Delimiter.DelimiterASCHI,
                TMKFlag = ModeFlag.GeneratekeyAndEncryptUnderZMK,
                TMK = keyToEncUnder,
                DPK_PPK_KeyScheme = KeyScheme.EncryptUnderTheTMK
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion

            return RequestHSM(request.CommandCode, request);
        }


        public HSMResponseInfo EncryptTMK(string DEK, string DataKey)
        {
            var request = new AT97RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_ENC_DATA_API,
                Mode = Operation.ENCRYPT,
                DEKAKB = DEK,// KeyType.TPK,
                Data = DataKey,
                Operation = ModeFlag.TripleDESCipherBlockChaining,
                InitializationVector = InitilzationVector.ZERO,
                DataFormat = DataFormat.HEXADECIMAL,
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion

            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo ImportTMKUnderKEK(string KEK, string EncTMK)
        {
            var request = new AT11BRequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_IMPORT_KEY_API,
                KEKAKB = KEK,// KeyType.TPK,
                EncKey = EncTMK,
                KeyUsage = "0", // No variant was applied to
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo GenerateSK(string keyExchangekey)
        {
            var request = new AT10RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_GENR_SK_API,
                SessionKeyExchangeKey = keyExchangekey,// KeyType.TPK,
                KeyLength = KeyScheme.DoubleLengthKey,

                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo EncryptSKunderTMK(string TMKAKB, string WKAKB)
        {
            var request = new AT1ARequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_ENCR_SK_TMK_API,
                TMKABB = TMKAKB,
                WKAKB = WKAKB,
                Variant = "0",

                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo DecryptTrack2PAN(string DEKAKB, string encryptedData)
        {
            var request = new AT97RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_ENC_DATA_API,
                Mode = Operation.DECRYPT,
                DEKAKB = DEKAKB,// KeyType.TPK,
                Data = encryptedData,
                Operation = ModeFlag.TripleDESCipherBlockChaining,
                InitializationVector = InitilzationVector.ZERO,
                DataFormat = DataFormat.HEXADECIMAL,
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }


        public HSMResponseInfo PINBlockGenerate(string PMKAKBParam, string PanNo, string PIN)
        {
            var request = new AT30RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_GENERATE_PINBLOCK_API,

                PMKAKB = PMKAKBParam,
                ClearPINBlock = PanNo,
                ClearPIN = PIN,
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo PINBlockVerification(string PEKAKBParam, string POSPinBlock, string HostPINBlock, string PMKAKBParam)
        {
            var request = new AT32RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_VERIFY_PINBLOCK_API,
                PINBlockFormat = PinBlockFormat.Format08,
                PEKAKB = PEKAKBParam,
                PINBlockPOS = POSPinBlock,
                PINBlockHost = HostPINBlock,
                PMKAKB = PMKAKBParam,
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }

        public HSMResponseInfo PINChange(string PMKAKBParam, string PEKAKBParam, string NewPinBlockParam, string CardPAN)
        {
            var request = new AT31RequestInfo()
            {
                Header = header,
                CommandCode = FunctionCode.Atalla_CHANGE_PINBLOCK_API,
                PINBlockFormat = PinBlockFormat.Format01,
                PMKAKB = PMKAKBParam,
                PEKAKB = PEKAKBParam,
                NewPINBlock = NewPinBlockParam,
                PAN = CardPAN,
                Delimiter = delimeter,
                Trailer = trailer
            };

            #region Pre request validation
            var response = IsValidRequestData(request);
            if (response == null || response.ReturnCode != ReturnCode.Success)
            {
                //validation failed
                return response;
            }
            #endregion
            return RequestHSM(request.CommandCode, request);
        }
        HSMResponseInfo IsValidRequestData(AtallaRequestInfo hsmRequest)
        {
            HSMResponseInfo response = new HSMResponseInfo();
            try
            {
                response.ReturnCode = ReturnCode.Success;
            }
            catch (Exception ex)
            {
                response.ReturnCode = ReturnCode.ValidationError;
                response.ReturnCode = ex.Message;
            }
            return response;

        }

        HSMResponseInfo RequestHSM(string fnCode, object obj)
        {
            HSMResponseInfo response = new HSMResponseInfo();
            try
            {

                //Create request  string
                var stRequest = CreateRequestString(fnCode, obj);

                //       var stRequest = "<1101#>";


                byte[] reqByte = ConversionManager.HexStringToByteArray(ConversionManager.StringToHex(stRequest)); //buildRequest(stRequest);
                //Send and receive request
                String stResp = SendAndReceiveHSM(reqByte);

                //          var stRequest1 =  "<9A#ID#>";


                //byte[] reqByte1 = ConversionManager.HexStringToByteArray(ConversionManager.StringToHex(stRequest1)); //buildRequest(stRequest);
                ////Send and receive request
                //String stResp1 = SendAndReceiveHSM(reqByte);

                //Console.WriteLine("02");
                //if (log.IsInfoEnabled) log.Info("HSM RESPONSE:" + stResp.Substring(0, PACKET_WATCH_LENGTH));
                //if (log.IsInfoEnabled) log.Info("HSM  RESPONSE:" + stResp);

                //if (log.IsInfoEnabled) Console.WriteLine(" 02 [" + stResp.Substring(0, PACKET_WATCH_LENGTH) + "]");

                //Parse data
                response = ParseHSMResponse(fnCode, new StringBuilder(stResp));
            }
            catch (Exception ex)
            {
                LoggerUtility.Logging(new LogInfo() { Level = LogLevel.ERROR, ShortDescription = "AtallaHSM.AtallaHSMProvider.RequestHSM Exception", Message = ex.Message });
                throw ex;
                response.ReturnCode = ReturnCode.ExceptionError;
                response.ReturnMessage = ex.Message;
                //string mobile = ConfigurationManager.AppSettings["SMS_ALERT"];  //"356";//19
                //string resultMessage = NotificationUtility.SendSMS(mobile, "HSM-ALERT: " + ex.Message);
                //  NotificationUtility.SendAlert("HSM-ALERT: ", ex.Message, 3);
            }
            return response;
        }

        string CreateRequestString(string commandCode, object Obj)
        {
            String stRequest = string.Empty;
            string FM = string.Empty;
            switch (commandCode)
            {
                case FunctionCode.Atalla_GENR_KEY_API:
                    using (var reqObj = (AT93RequestInfo)Obj)
                    {
                        StringBuilder sbReq = new StringBuilder();
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                            reqObj.Mode, reqObj.Delimiter, reqObj.KeyLength, reqObj.Delimiter, reqObj.Trailer);

                        if (reqObj.TMK != null)
                            sbReq.Append(ConversionManager.StringToHex(reqObj.TMK));
                        if (reqObj.DPK_PPK_KeyScheme != null)
                            sbReq.Append(ConversionManager.StringToHex(reqObj.DPK_PPK_KeyScheme));

                    }
                    break;
                case FunctionCode.Atalla_ENC_DATA_API:
                    using (var reqObj = (AT97RequestInfo)Obj)
                    {
                        StringBuilder sbReq = new StringBuilder();
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                            reqObj.Mode, reqObj.Delimiter, reqObj.Operation, reqObj.Delimiter, reqObj.DEKAKB,
                            reqObj.Delimiter, reqObj.InitializationVector, reqObj.Delimiter, reqObj.DataFormat,
                            reqObj.Delimiter, reqObj.Data.Length.ToString(), reqObj.Delimiter,
                            reqObj.Data, reqObj.Delimiter, reqObj.Trailer);

                    }
                    break;
                case FunctionCode.Atalla_IMPORT_KEY_API:
                    using (var reqObj = (AT11BRequestInfo)Obj)
                    {
                        StringBuilder sbReq = new StringBuilder();
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                            reqObj.KeyUsage, reqObj.Delimiter, reqObj.EncKey, reqObj.Delimiter, reqObj.KEKAKB,
                            reqObj.Delimiter, reqObj.Trailer);
                        //         sbReq.Append(ConversionManager.StringToHex(stRequest));
                        //         stRequest = sbReq.ToString();
                    }
                    break;


                case FunctionCode.Atalla_GENR_SK_API:
                    using (var reqObj = (AT10RequestInfo)Obj)
                    {
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                         reqObj.SessionKeyExchangeKey, reqObj.Delimiter, reqObj.Delimiter, reqObj.KeyLength,
                         reqObj.Delimiter, reqObj.Trailer);
                    }
                    break;

                case FunctionCode.Atalla_ENCR_SK_TMK_API:
                    using (var reqObj = (AT1ARequestInfo)Obj)
                    {
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                        reqObj.Variant, reqObj.Delimiter, reqObj.TMKABB, reqObj.Delimiter,
                        reqObj.WKAKB, reqObj.Delimiter, reqObj.Trailer);

                    }
                    break;
                case FunctionCode.Atalla_GENERATE_PINBLOCK_API:
                    using (var reqObj = (AT30RequestInfo)Obj)
                    {
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                         reqObj.PMKAKB, reqObj.Delimiter, reqObj.ClearPIN, reqObj.Delimiter,
                         reqObj.ClearPINBlock, reqObj.Delimiter, reqObj.Trailer);
                    }
                    break;
                case FunctionCode.Atalla_IMPO_PUB_KEY_API:
                    using (var reqObj = (ATEORequestInfo)Obj)
                    {
                        stRequest = string.Concat(reqObj.Header + reqObj.CommandCode + reqObj.EncodingRule);
                        StringBuilder sbReq = new StringBuilder();
                        sbReq.Append(ConversionManager.StringToHex(stRequest));
                        sbReq.Append(reqObj.EncodedPublicKey + reqObj.MACCalculationData);
                        sbReq.Append(reqObj.Delimiter);
                        sbReq.Append(ConversionManager.StringToHex(reqObj.MessageTrailer));
                        stRequest = sbReq.ToString();
                    }
                    break;
                case FunctionCode.Atalla_ENC_PUB_KEY_API:
                    using (var reqObj = (ATGKRequestInfo)Obj)
                    {
                        StringBuilder sbReq = new StringBuilder();
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.EncryptionIdentifier, reqObj.PadModeIdentifier, reqObj.KeyType, reqObj.Mode, reqObj.Key, reqObj.KeyCheckValue);
                        sbReq.Append(ConversionManager.StringToHex(stRequest));
                        sbReq.Append(reqObj.MAC);
                        sbReq.Append(reqObj.PublicKey);
                        sbReq.Append(ConversionManager.StringToHex(reqObj.Delimiter + reqObj.KeyBlockType));
                        stRequest = sbReq.ToString();
                    }
                    break;

                case FunctionCode.Atalla_VERIFY_PINBLOCK_API:
                    using (var reqObj = (AT32RequestInfo)Obj)
                    {

                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                          reqObj.PINBlockFormat, reqObj.Delimiter, reqObj.PINBlockPOS, reqObj.Delimiter,
                          reqObj.PEKAKB, reqObj.Delimiter, reqObj.PINBlockHost, reqObj.Delimiter, reqObj.PMKAKB,
                          reqObj.Delimiter, reqObj.Trailer);
                    }
                    break;

                case FunctionCode.Atalla_CHANGE_PINBLOCK_API:
                    using (var reqObj = (AT31RequestInfo)Obj)
                    {
                        stRequest = string.Concat(reqObj.Header, reqObj.CommandCode, reqObj.Delimiter,
                           reqObj.PINBlockFormat, reqObj.Delimiter, reqObj.PEKAKB, reqObj.Delimiter,
                           reqObj.PMKAKB, reqObj.Delimiter, reqObj.NewPINBlock, reqObj.Delimiter, reqObj.PAN,
                           reqObj.Delimiter, reqObj.Trailer);
                    }
                    break;

                default:
                    return string.Empty;
            }
            return stRequest;
        }

        HSMResponseInfo ParseHSMResponse(string requestedFnCode, StringBuilder responseData)
        {
            HSMResponseInfo response = null;
            try
            {
                if (string.IsNullOrEmpty(responseData.ToString()))
                    return response;
                int subStrIndex = 0;
                int dataLen = 0;
                headerLength = 1;// made hex len
                response = new HSMResponseInfo();
                ATBaseResponseInfo headerResponse = new ATBaseResponseInfo();
                response.FunctionCode = requestedFnCode;
                headerResponse.Header = responseData.ToString(subStrIndex, headerLength);
                subStrIndex += headerLength;
                headerResponse.ResponseCode = responseData.ToString(subStrIndex, 2);
                headerResponse.ErrorCode = responseData.ToString(subStrIndex, 2);
                subStrIndex += 2;
                subStrIndex += 1;  // Move another delimeter

                response.ReturnCode = headerResponse.ErrorCode;
                if (string.Compare(headerResponse.ErrorCode, ReturnCode.Error, true) != 0)
                // || string.Compare(headerResponse.ErrorCode, ReturnCode.KeyParityError_Advice, true) == 0)
                {
                    switch (requestedFnCode)
                    {
                        case FunctionCode.Atalla_IMPORT_KEY_API:
                            AT11BResponseInfo resAT11B = new AT11BResponseInfo();
                            resAT11B.encWorkingKey = responseData.ToString(subStrIndex + 1, 74);
                            resAT11B.KCV = responseData.ToString(subStrIndex + 76, 6);
                            resAT11B.HeaderAndReturnCode = headerResponse;
                            //this TMKAKB needs to be stored in DB.

                            response.ResponseData = resAT11B;
                            break;

                        case FunctionCode.Atalla_GENR_KEY_API:
                            AT93ResponseInfo resATA3 = new AT93ResponseInfo();
                            resATA3.HeaderAndReturnCode = headerResponse;
                            resATA3.NoOfKeySet = 1;
                            //Get list of key sets
                            resATA3.keySet = ParseKeySets(resATA3.NoOfKeySet, responseData.Remove(0, subStrIndex));
                            response.ResponseData = resATA3;
                            break;

                        case FunctionCode.Atalla_ENC_DATA_API:
                            AT97ResponseInfo resATA7 = new AT97ResponseInfo();
                            resATA7.HeaderAndReturnCode = headerResponse;

                            //  dataLen = ConversionManager.HexToDecimal(Encoding.ASCII.GetString(ConversionManager.HexToByteArray(responseData.ToString(subStrIndex, 8))));
                            //   subStrIndex += 8;
                            resATA7.encKeyAKB = responseData.ToString(17, 74);
                            resATA7.encKey = responseData.ToString(97, 16);
                            response.ResponseData = resATA7;
                            break;

                        case FunctionCode.Atalla_GENR_SK_API:
                            AT10ResponseInfo resAT10 = new AT10ResponseInfo();
                            resAT10.HeaderAndReturnCode = headerResponse;
                            resAT10.encWorkingKey = responseData.ToString(4, 74);
                            resAT10.KCV = responseData.ToString(80, 6);
                            response.ResponseData = resAT10;


                            break;


                        case FunctionCode.Atalla_ENCR_SK_TMK_API:
                            AT1AResponseInfo resAT1A = new AT1AResponseInfo();
                            resAT1A.HeaderAndReturnCode = headerResponse;
                            resAT1A.encSessionKey = responseData.ToString(4, 32);
                            resAT1A.KCV = responseData.ToString(37, 6);
                            response.ResponseData = resAT1A;


                            break;
                        case FunctionCode.Atalla_GENERATE_PINBLOCK_API:
                            AT30ResponseInfo resAT30 = new AT30ResponseInfo();
                            resAT30.HeaderAndReturnCode = headerResponse;
                            resAT30.encPINBlock = responseData.ToString(4, 16);
                            response.ResponseData = resAT30;
                            break;
                        case FunctionCode.Atalla_VERIFY_PINBLOCK_API:
                            AT32ResponseInfo resAT32 = new AT32ResponseInfo();
                            resAT32.HeaderAndReturnCode = headerResponse;
                            resAT32.Result = responseData.ToString(4, 1);
                            response.ResponseData = resAT32;
                            break;
                        case FunctionCode.Atalla_CHANGE_PINBLOCK_API:
                            AT31ResponseInfo resAT31 = new AT31ResponseInfo();
                            resAT31.HeaderAndReturnCode = headerResponse;
                            resAT31.NewPINBlock = responseData.ToString(4, 16);
                            resAT31.Result = responseData.ToString(21, 1);
                            response.ResponseData = resAT31;
                            break;
                        case FunctionCode.Atalla_TRANS_PIN_API:
                            //Get Encrypted pin 
                            ATCAResponseInfo resTHCA = new ATCAResponseInfo();
                            resTHCA.HeaderAndReturnCode = headerResponse;
                            resTHCA.PinLength = Encoding.ASCII.GetString(ConversionManager.HexToByteArray(responseData.ToString(subStrIndex, 4)));
                            subStrIndex += 4;
                            resTHCA.PinBlock = Encoding.ASCII.GetString(ConversionManager.HexToByteArray(responseData.ToString(subStrIndex, 32)));
                            subStrIndex += 32;
                            resTHCA.PinBlockFormat = Encoding.ASCII.GetString(ConversionManager.HexToByteArray(responseData.ToString(subStrIndex, 4)));
                            response.ResponseData = resTHCA;
                            break;
                        case FunctionCode.Atalla_IMPO_PUB_KEY_API:
                            ATEOResponseInfo resTHEO = new ATEOResponseInfo();
                            resTHEO.HeaderAndReturnCode = headerResponse;
                            resTHEO.MAC = responseData.ToString(subStrIndex, 8);
                            subStrIndex += 8;
                            resTHEO.EncodedPublicKey = responseData.ToString(subStrIndex, 280);// ConversionManager.HexToBinary(responseData.ToString(subStrIndex, 280));
                            subStrIndex += 280;
                            resTHEO.Delimiter = responseData.ToString(subStrIndex, 2);
                            subStrIndex += 2;
                            resTHEO.MessageTrailer = ConversionManager.HexToPlainText(responseData.ToString(subStrIndex, 64));
                            response.ResponseData = resTHEO;
                            break;

                        case FunctionCode.Atalla_ENC_PUB_KEY_API:
                            ATGKResponseInfo resTHGK = new ATGKResponseInfo();
                            resTHGK.HeaderAndReturnCode = headerResponse;
                            //resTHGK.IV = ConversionManager.HexToPlainText(responseData.ToString(subStrIndex, 32));
                            //subStrIndex += 32;
                            resTHGK.EncryptedKeyLength = ConversionManager.UTF8EncodedHexToDecimal(responseData.ToString(subStrIndex, 8));
                            subStrIndex += 8;
                            resTHGK.EncryptedKey = responseData.ToString(subStrIndex, resTHGK.EncryptedKeyLength * 2);
                            subStrIndex += resTHGK.EncryptedKeyLength * 2;
                            response.ResponseData = resTHGK;
                            break;
                    }
                }
                //else
                //{
                //    response.ReturnCode = ReturnCode.BH_InvalidFunctionCode;
                //    response.ReturnMessage = ReturnCode.BH_InvalidFunctionCode;
                //}
                if (response.ReturnCode.Equals(ReturnCode.Error))
                {
                    //validate reponse
                    response = IsValidResponseData(response);
                }
            }
            catch (Exception ex)
            {
                LoggerUtility.Logging(new LogInfo() { Level = LogLevel.ERROR, ShortDescription = "AtallaHSM.AtallaHSMProvider.ParseHSMResponse Exception", Message = ex.Message });
                throw ex;
            }
            return response;
        }

        HSMResponseInfo IsValidResponseData(HSMResponseInfo response)
        {
            if (response == null)
            {
                response = new HSMResponseInfo();
                response.ReturnCode = ReturnCode.ValidationError;
                return response;
            }
            try
            {
                response.ReturnCode = ReturnCode.Success;
                //to do
            }
            catch (Exception ex)
            {
                response.ReturnCode = ReturnCode.ValidationError;
                response.ReturnCode = ex.Message;
            }
            return response;
        }

        KeySetInfo ParseKeySets(int NoOfKeySet, StringBuilder responseData)
        {
            KeySetInfo keySet = null;
            //IList<KeySetInfo> listKeySet = null;
            int subStrIndex;
            //int keyLen;
            responseData = new StringBuilder(responseData.ToString());
            for (int i = 0; i < NoOfKeySet; i++)
            {
                subStrIndex = 0;
                keySet = new KeySetInfo();
                keySet.KeyScheme = responseData.ToString(subStrIndex, 1);
                //     subStrIndex += 1;
                var keyLen = 32;

                #region Get the key length
                if (Enum.IsDefined(typeof(KeyLengthType), keySet.KeyScheme))
                {
                    switch ((KeyLengthType)Enum.Parse(typeof(KeyLengthType), keySet.KeyScheme))
                    {
                        case KeyLengthType.U:
                            keyLen = (int)KeyLengthType.U;
                            break;
                        case KeyLengthType.T:
                            keyLen = (int)KeyLengthType.T;
                            break;
                        case KeyLengthType.S:
                            keyLen = ConversionManager.UTF8EncodedHexToDecimal(responseData.ToString(subStrIndex, 4));
                            subStrIndex += 4;
                            break;
                        default:
                            keyLen = 0;
                            break;
                    }
                }
                #endregion

                keySet.KeySpecifier = keySet.KeyScheme + responseData.ToString(subStrIndex, keyLen);

                subStrIndex += keyLen;
                var mode = responseData.ToString(subStrIndex, 1);
                if (mode != "X")
                {
                    keySet.KCV = responseData.ToString(subStrIndex, 6);
                    subStrIndex += 6;
                }
                else
                {
                    //keySet.KCV = responseData.ToString(subStrIndex, 6);
                    subStrIndex += 1;
                    keySet.Key = responseData.ToString(subStrIndex, 32);
                    subStrIndex += 32;

                    keySet.KCV = responseData.ToString(subStrIndex, 6);
                    subStrIndex += 6;
                }



                //keySet.Key = responseData.ToString(subStrIndex, keyLen);
                //subStrIndex += keyLen;
                //Remove parsed text
                responseData.Remove(0, subStrIndex);
                //if (listKeySet == null)
                //    listKeySet = new List<KeySetInfo>();
                //listKeySet.Add(keySet);
            }
            return keySet;
        }


    }
}
