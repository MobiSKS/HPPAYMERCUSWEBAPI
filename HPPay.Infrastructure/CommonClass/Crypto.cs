using Crypto;

namespace HPPay.Infrastructure.CommonClass
{
    public class Crypto
    {
        public static string Encrypt(string data, string key)
        {
            ClsProcess objProcess = new ClsProcess();
            string data1 = objProcess.Encrypt(data, key, ClsProcess.EncryptionType.RSA);
            return data1;
        }
        public static string Decrypt(string data, string key)
        {
            ClsProcess objProcess = new ClsProcess();
            string data1 = objProcess.Decrypt(data, key, ClsProcess.EncryptionType.RSA);
            return data1;
        }
    }
}
