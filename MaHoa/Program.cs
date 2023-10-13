// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Security.Cryptography;
using System.Text;



namespace HashFunction.Hash
{
    public class SHA_Hash
    {
        

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
    class MainClass
    {
        public static void Main()
        {
            string username = "Admin";
            string pass = "Awdx!@#$%xdwa";
            string us = SHA_Hash.SHA256(username);
            string passw = SHA_Hash.SHA256(pass);
            
            Console.WriteLine($"Admin: {us}");
            Console.WriteLine($"Awdx!@#$%xdwa: {passw}");


            Console.ReadKey();
        }
    }
}