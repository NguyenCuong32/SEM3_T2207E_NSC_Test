using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static string HashPassword(string inputPassword)
    {
        using(SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }

    static void Main()
    {
        string userName = "Admin";
        string password = "Awdx!@#$%xdwa";
        string hashPassword = HashPassword(password);
        
        Console.WriteLine("UserName: " + userName);
        Console.WriteLine("Hash Password: " + hashPassword);
    }
}