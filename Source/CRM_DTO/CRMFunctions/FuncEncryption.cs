using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMFunctions
{
    public static class FuncEncryption
    {
        public static string CreateKey(string _Key)
        {
            StringBuilder builder = new StringBuilder();
            int length = _Key.Length;
            for (int i = 1; i <= length; i++)
            {
                int start = (_Key.Length - i);
                builder.Append(_Key.Substring(start, 1));
            }
            string str2 = builder.ToString();
            return builder.ToString();
        }

        public static string EncryptText(string _Input, out string _Error)
        {
            try
            {
                _Error = string.Empty;
                string sKey = "";
                if (_Input == "")
                {
                    return _Input;
                }

                sKey = CreateKey("PASSWORD");
                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateEncryptor();
                byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(_Input);
                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                _Error = FuncException.GetDetailsException(ex);
                return "";
            }
        }

        public static string DecryptText(string _Output, out string _Error)
        {
            try
            {
                _Error = string.Empty;
                if (_Output == "")
                {
                    return _Output;
                }
                string sKey = "";
                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                sKey = CreateKey("PASSWORD");
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(_Output);
                return System.Text.ASCIIEncoding.ASCII.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                _Error = FuncException.GetDetailsException(ex);
                return "";
            }
        }

        public static string MD5Hash(string _Text)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(_Text));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
