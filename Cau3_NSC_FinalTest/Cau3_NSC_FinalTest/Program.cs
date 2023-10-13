using System;
using System.Security.Cryptography;
using System.Text;

class PasswordEncryptionExample
{
    static void Main()
    {
        string username = "Admin";
        string password = "Awdx!@#$%xdwa";

        string hashedUsername = ComputeSHA256Hash(username);
        string hashedPassword = ComputeSHA256Hash(password);

        Console.WriteLine("Username: " + hashedUsername);
        Console.WriteLine("Hashed Password: " + hashedPassword);
        Console.ReadKey();
    }

    static string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
