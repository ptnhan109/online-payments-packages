using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Momo.Payment
{
    public static class StringExtentions
    {
        public static string ToSha256(this string message, string secretkey)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(secretkey);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashmessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;
            }
        }
    }
}
