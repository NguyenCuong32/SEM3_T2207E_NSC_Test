using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string userName = "Admin";
        string password = "Awdx!@#$%xdwa";

        string hashedPassword = HashPassword(password);

        Console.WriteLine($"Username: {userName}");
        Console.WriteLine($"Original Password: {password}");
        Console.WriteLine($"Hashed Password (SHA-256): {hashedPassword}");
    }

    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
