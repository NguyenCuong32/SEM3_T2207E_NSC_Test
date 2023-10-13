using System;
using System.Text;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        string combinedData = username + password;

        string hashedPassword = CalculateSHA256Hash(combinedData);

        Console.WriteLine("SHA-256 Hash of the password: " + hashedPassword);
    }

    static string CalculateSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
              return builder.ToString();
        }
    }
}