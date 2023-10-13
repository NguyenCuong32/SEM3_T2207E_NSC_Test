using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Tạo một cặp khóa RSA
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Văn bản cần mã hoá
            string originalText;
            Console.WriteLine("Vui lòng nhập mật khẩu: ");
            originalText = Console.ReadLine();

            // Mã hoá văn bản bằng khóa công khai
            string encryptedText = Encrypt(originalText, rsa.ExportParameters(false));

            Console.WriteLine("Văn bản sau khi mã hoá: " + encryptedText);

            string decryptedText = Decrypt(encryptedText, rsa.ExportParameters(true));

            Console.WriteLine("Văn bản ban đầu: " + decryptedText);
        }
    }

    public static string Encrypt(string text, RSAParameters publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(text);
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(encryptedData);
        }
    }

    public static string Decrypt(string encryptedText, RSAParameters privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(privateKey);
            byte[] encryptedData = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
