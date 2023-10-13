using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace HashFunction.Hash
{
    public class SHA1Hash
    {
         

        public static string SHA256(string text)
        {
            SHA256Managed sha256 = new SHA256Managed();
            StringBuilder hashSb = new StringBuilder();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("x3"));
            }
            return hashSb.ToString();
        }
    }

}
