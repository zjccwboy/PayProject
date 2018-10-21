using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Pay.Base.Common.Enums.Utils
{
    public static class DESHelper
    {
        public static string Key = "12345678";

        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);
            using (var ms = new MemoryStream())
            {
                var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
        }

        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);
            using (var ms = new MemoryStream())
            {
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}
