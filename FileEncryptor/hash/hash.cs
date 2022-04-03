using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptor.hash
{
    internal class hash
    {
        public static string Create(string pwd)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(pwd));
            foreach (byte b in crypto)
            {
                hash += b.ToString("x2");
            }
            return hash;
        }
    }
}
