using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        
        string username = "Admin";
        string password = "Adwx!@#$%xdwa";

        string salt = GenerateRandomSalt();

       
        string saltedPassword = password + salt;
        string hashedPassword = ComputeSHA256Hash(saltedPassword);

        Console.WriteLine("Username: " + username);
        Console.WriteLine("Salt: " + salt);
        Console.WriteLine("Hashed Password: " + hashedPassword);
    }

    static string GenerateRandomSalt()
    {
        byte[] saltBytes = new byte[16];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    // Compute SHA-256 hash
    static string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
