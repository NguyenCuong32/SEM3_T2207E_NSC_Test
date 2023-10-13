using HashFunction.Hash;
using System;

namespace HashFunction
{
    class MainClass
    {
        public static void Main()
        {
            string Username = "Admin";
            string Password =  "Awdx!@#$%xdwa";


            
            string str_sha2 = SHA1Hash.SHA256(Password);
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"Password After Encoded: {str_sha2}");

            Console.ReadKey();
        }
    }
}