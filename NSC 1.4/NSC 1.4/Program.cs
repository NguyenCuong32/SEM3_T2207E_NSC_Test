using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                Console.WriteLine("nhap van ban can ma hoa:");
                string plainText = Console.ReadLine();

                byte[] encryptedData = EncryptData(plainText, publicKey);

                Console.WriteLine("van ban da ma hoa: " + Convert.ToBase64String(encryptedData));

                string decryptedText = DecryptData(encryptedData, privateKey);

                Console.WriteLine("van ban giai ma: " + decryptedText);
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("loi: " + e.Message);
        }
    }

    static byte[] EncryptData(string data, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] encryptedData = rsa.Encrypt(dataBytes, false);
            return encryptedData;
        }
    }

    static string DecryptData(byte[] encryptedData, string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false);
            return System.Text.Encoding.UTF8.GetString(decryptedData);
        }
    }
}