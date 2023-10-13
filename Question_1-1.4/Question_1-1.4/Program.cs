using System;
using System.Security.Cryptography;

class AsymmetricEncryption
{
    // Mã hóa dữ liệu bằng public key
    static byte[] EncryptData(string data, RSAParameters publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(publicKey);
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] encryptedData = rsa.Encrypt(dataBytes, RSAEncryptionPadding.Pkcs1);
            return encryptedData;
        }
    }

    // Giải mã dữ liệu bằng private key
    static string DecryptData(byte[] encryptedData, RSAParameters privateKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(privateKey);
            byte[] decryptedBytes = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
            string decryptedData = System.Text.Encoding.UTF8.GetString(decryptedBytes);
            return decryptedData;
        }
    }

    static void Main()
    {
        try
        {
            using (RSA rsa = RSA.Create())
            {
                RSAParameters publicKey = rsa.ExportParameters(false);
                RSAParameters privateKey = rsa.ExportParameters(true);

                string text = "Hello world !";
                Console.WriteLine($"Dữ liệu gốc: {text}");

                byte[] encryptedData = EncryptData(text, publicKey); // Mã hóa dữ liệu bằng khóa công khai

                string decryptedText = DecryptData(encryptedData, privateKey); // Giải mã dữ liệu bằng khóa riêng tư
                Console.WriteLine($"Dữ liệu được giải mã: {decryptedText}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
