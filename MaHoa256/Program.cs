using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string taikhoan = "Admin";

        Console.Write("nhap mat khau: ");
        string matkhau = Console.ReadLine();

        string hashedPassword = HashPassword(matkhau);

        Console.WriteLine($"Username: {taikhoan}");
        Console.WriteLine($"Hashed Password: {hashedPassword}");
    }

    static string HashPassword(string matkhau)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(matkhau));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}