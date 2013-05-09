using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Com.Powergrid.Intranet.Bll
{
    public class BllEncryption
    {
        public static string RSAEncrypt(string plaintext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "PowerGridIndia";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(plaintext);
                byte[] encryptdata = rsa.Encrypt(plaindata, false);
                string encryptstring = Convert.ToBase64String(encryptdata);
                return encryptstring;
            }
        }

        public static string RSADecrypt(string encryptedString)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "PowerGridIndia";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                int len = encryptedString.Length;
                encryptedString = encryptedString.Replace(" ", "+");
                byte[] encryptdata = Convert.FromBase64String(encryptedString);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                string plaindata = System.Text.Encoding.Default.GetString(decryptdata);
                return plaindata;
            }
        }

        public static string UrlEncode(string url)
        {
            string encodedData = String.Empty;
            try
            {
                byte[] data_byte = Encoding.UTF8.GetBytes(url);
                encodedData = HttpUtility.UrlEncode(Convert.ToBase64String(data_byte));
                //Log exception
            }
            catch (Exception exception)
            {
            }
            return encodedData;
        }

        public static string UrlDecode(string url)
        {
            string decodedData = String.Empty;
            try
            {
                byte[] data_byte = Convert.FromBase64String(HttpUtility.UrlDecode(url));
                decodedData = Encoding.UTF8.GetString(data_byte);
                //Log exception
            }
            catch (Exception exception)
            {
            }
            return decodedData;
        }
    }
}
