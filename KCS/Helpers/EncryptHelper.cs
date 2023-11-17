using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;


namespace KCS.Helpers
{
    public static class EncryptHelper
    {


        private const string m_iv = "0062F68EEC284F71";
        private const string m_key = "2A6D179737BD475EAD651799C5087282";

        public static string EncryptAES(string text)
        {
            return EncryptAES(text, m_key, m_iv);
        }

        public static string DecryptAES(string text)
        {
            return DecryptAES(text, m_key, m_iv);
        }

        private static string EncryptAES(string text, string key, string iv)
        {
            var sourceBytes = System.Text.Encoding.UTF8.GetBytes(text);
            var aes = System.Security.Cryptography.Aes.Create();
            aes.Mode = System.Security.Cryptography.CipherMode.CBC;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(iv);
            var transform = aes.CreateEncryptor();
            return System.Convert.ToBase64String(transform.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length));
        }

        private static string DecryptAES(string text, string key, string iv)
        {
            var encryptBytes = System.Convert.FromBase64String(text);
            var aes = System.Security.Cryptography.Aes.Create();
            aes.Mode = System.Security.Cryptography.CipherMode.CBC;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(iv);
            var transform = aes.CreateDecryptor();
            return System.Text.Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));
        }



    }
}
