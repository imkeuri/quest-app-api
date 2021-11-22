using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Utils
{
    public static class Encrypt
    {
        public static string EncryptPassword(string pass)
        {
            MD5 mdHash = MD5.Create();
            byte[] data = mdHash.ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
