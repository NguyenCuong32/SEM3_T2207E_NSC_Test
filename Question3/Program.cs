using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Provided username and password
        string username = "Admin";
        string password = "Awdx!@#$%xdwa";

        // Encrypt the password using SHA-256
        string hashedPassword = ComputeSHA256Hash(password);

        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Hashed Password: {hashedPassword}");
    }

    static string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
