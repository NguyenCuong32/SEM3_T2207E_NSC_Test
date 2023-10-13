using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string username = "Admin";
        string password = "Awdx!@#$%xdwa";

        string hashedPassword = ComputeSHA256Hash(password);

        Console.WriteLine("Username: " + username);
        Console.WriteLine("SHA-256 Hashed Password: " + hashedPassword);
    }

    public static string ComputeSHA256Hash(string input)
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
