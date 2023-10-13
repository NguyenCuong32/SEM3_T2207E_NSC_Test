using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            Console.WriteLine("Public Key:\n" + publicKey);
            Console.WriteLine("\nPrivate Key:\n" + privateKey);

            string originalMessage = "PhamNgocDung-T2207E-finalExam";
            byte[] encryptedMessage = Encrypt(publicKey, originalMessage);
            string decryptedMessage = Decrypt(privateKey, encryptedMessage);

            Console.WriteLine("\nOriginal Message: " + originalMessage);
            Console.WriteLine("\nEncrypted Message: " + Convert.ToBase64String(encryptedMessage));
            Console.WriteLine("\nDecrypted Message: " + decryptedMessage);
        }
    }

    static byte[] Encrypt(string publicKey, string message)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);

            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(message);

            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);

            return encryptedData;
        }
    }

    static string Decrypt(string privateKey, byte[] encryptedData)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);

            byte[] decryptedData = rsa.Decrypt(encryptedData, false);

            string decryptedMessage = Encoding.UTF8.GetString(decryptedData);

            return decryptedMessage;
        }
    }
}
