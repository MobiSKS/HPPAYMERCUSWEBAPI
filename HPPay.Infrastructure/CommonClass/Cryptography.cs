using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Asn1;
namespace HPPay.Infrastructure.CommonClass
{
    public class RSADataUtiltiy
    {
        public RSADataUtiltiy()
        {

        }
        const int keySize = 1024 * 2; //128 bytes (128*8=1024 bits)
        public RSAParameters GetRSAParameters(string key, out string outKey)
        {
            try
            {

                RSAParameters rs = GetPublicKeyRSAParameters(Convert.FromBase64String(key));

                //        removeCharPosition = ConfigurationManager.AppSettings["PKICONTROL"].ToString();
                using (var provider = new RSACryptoServiceProvider(keySize))
                {
                    string actualKey = key;
                    byte[] keyByte = Convert.FromBase64String(actualKey);
                    //if (removeCharPosition.Length > 0)
                    //    keyByte = RemoveExtraBytes(keyByte, removeCharPosition);
                    outKey = BitConverter.ToString(keyByte).Replace("-", "");
                    //   var rsaParam = GetPublicKey(keyByte);
                    var rsaParam = rs;
                    // provider.ImportParameters(GetPublicKey(keyByte));
                    provider.ImportParameters(rs);
                    //var encryptedByte = provider.Encrypt(byteData, _optimalAsymmetricEncryptionPadding);
                    return rsaParam;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hash Converstion Error");
            }
        }

        public static RSAParameters GetPublicKeyRSAParameters(byte[] subjectPublicKeyInfoBytes)
        {
            var publicKeyObject = (DerSequence)Asn1Object.FromByteArray(subjectPublicKeyInfoBytes);
            var rsaPublicKeyParametersBitString = (DerBitString)publicKeyObject[1];

            var rsaPublicKeyParametersObject = (DerSequence)Asn1Object.FromByteArray(rsaPublicKeyParametersBitString.GetBytes());

            var modulus = ((DerInteger)rsaPublicKeyParametersObject[0]).Value.ToByteArray().Skip(1).ToArray();
            var exponent = ((DerInteger)rsaPublicKeyParametersObject[1]).Value.ToByteArray();

            return new RSAParameters() { Modulus = modulus, Exponent = exponent };
        }


        public string Hash(string key, byte[] byteData)
        {
            try
            {
                RSAParameters rs = GetPublicKeyRSAParameters(Convert.FromBase64String(key));
                //       removeCharPosition = ConfigurationManager.AppSettings["PKICONTROL"].ToString();
                using (var provider = new RSACryptoServiceProvider(keySize))
                {
                    string actualKey = key;
                    byte[] keyByte = Convert.FromBase64String(actualKey);
                    //         if (removeCharPosition.Length > 0)
                    //             keyByte = RemoveExtraBytes(keyByte, removeCharPosition);
                    provider.ImportParameters(rs);
                    var encryptedByte = provider.Encrypt(byteData, RSAEncryptionPadding.Pkcs1);
                    //    return encryptedByte;

                    //string s = BitConverter.ToString(keyByte).Replace("-", " ");
                    //var byteData = Encoding.UTF8.GetBytes(textBox3.Text.Trim());
                    //var byteData = GetBinary(textBox3.Text.Trim());
                    return Convert.ToBase64String(encryptedByte);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hash Converstion Error");
            }
        }

        public string EncryptData(string strData, string strKey)
        {
            byte[] key = { }; //Encryption Key   
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xcd };
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                // DESCryptoServiceProvider is a cryptography class defind in c#.  
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(strData);
                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                return Convert.ToBase64String(Objmst.ToArray());//encrypted string  
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
