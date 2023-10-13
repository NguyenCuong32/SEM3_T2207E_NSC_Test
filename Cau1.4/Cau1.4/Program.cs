using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            try
            {
                // Mã hóa
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                string name = "Nguyen Quang Thanh T2207E";
                Console.WriteLine("Tên: " + name);

                byte[] encryptedData = Encrypt(Encoding.UTF8.GetBytes(name), publicKey);
                string encryptedText = Convert.ToBase64String(encryptedData);
                Console.WriteLine("Mã hoá: " + encryptedText);

                // Giải mã
                byte[] decryptedData = Decrypt(Convert.FromBase64String(encryptedText), privateKey);
                string maxuly = Encoding.UTF8.GetString(decryptedData);
                Console.WriteLine("Giải mã: " + maxuly);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }

    static byte[] Encrypt(byte[] data, string publicKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            return rsa.Encrypt(data, true);
        }
    }

    static byte[] Decrypt(byte[] data, string privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            return rsa.Decrypt(data, true);
        }
    }
}