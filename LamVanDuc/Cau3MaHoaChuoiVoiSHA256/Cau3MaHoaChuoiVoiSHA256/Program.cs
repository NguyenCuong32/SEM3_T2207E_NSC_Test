using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using HashFunction.Hash;

namespace HashFunction.Hash
{
    public class SHA1Hash
    {
        public static void Main()
        {
            Console.Write(" Moi ban nhap username: ");
            string username = Console.ReadLine();
            Console.Write(" Moi ban nhap password: ");
            string text = Console.ReadLine();


            string str_sha2 = SHA1Hash.SHA256(text);
            Console.WriteLine($"username: {username}; password :{str_sha2}");
            Console.ReadKey();
        }
  
        public static string SHA256(string text)
        {
            SHA256Managed sha256 = new SHA256Managed();
            StringBuilder hashSb = new StringBuilder();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("x2"));
            }
            return hashSb.ToString();
        }
    }

}

