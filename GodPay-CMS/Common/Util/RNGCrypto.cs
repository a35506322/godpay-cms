using System;
using System.Security.Cryptography;

namespace GodPay_CMS.Common.Util
{
    public static class RNGCrypto
    {
        /// <summary>
        /// 雜湊HMACSHA256
        /// </summary>
        /// <param name="message">訊息</param>
        /// <param name="key">金鑰</param>
        /// <returns></returns>
        public static string HMACSHA256(string message, string key)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacSHA256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
            }
        }
    }
}
