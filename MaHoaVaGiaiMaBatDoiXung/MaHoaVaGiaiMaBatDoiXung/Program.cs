using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            string plaintext;

            Console.WriteLine("Nhập dữ liệu muốn mã hóa: ");
            plaintext = Console.ReadLine();

            byte[] data = Encoding.UTF8.GetBytes(plaintext);

            byte[] encryptedData = rsa.Encrypt(data, false);

            string encryptedText = Encoding.UTF8.GetString(encryptedData);

            byte[] decryptedData = rsa.Decrypt(encryptedData, false);

            string decryptedText = Encoding.UTF8.GetString(decryptedData);

            Console.WriteLine("Dữ liệu sau khi mã hóa: " + encryptedText);
            Console.WriteLine("Dữ liệu sau khi giải mã: " + decryptedText);

            Console.ReadKey();
        }
    }
}
