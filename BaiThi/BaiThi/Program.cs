using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string username = "Quản trị viên";
        string password = "Awdx!@#$%xdwa";

       
        string hashedPassword = HashPassword(password);
        
        bool isAuthenticated = Authenticate(username, password, hashedPassword);

        if (isAuthenticated)
        {
            Console.WriteLine("Đăng nhập thành công!");
        }
        else
        {
            Console.WriteLine("Đăng nhập không thành công!");
        }
    }

    static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
         
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

         
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    static bool Authenticate(string username, string password, string hashedPassword)
    {

        string hashedInputPassword = HashPassword(password);

        return hashedInputPassword.Equals(hashedPassword);
    }
}