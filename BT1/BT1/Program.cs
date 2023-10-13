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
                
                RSAParameters publicKey = rsa.ExportParameters(false); 
                RSAParameters privateKey = rsa.ExportParameters(true);

               
                string originalData = "Hello, world!";
                byte[] originalBytes = System.Text.Encoding.UTF8.GetBytes(originalData);
                byte[] encryptedBytes = EncryptWithPublicKey(originalBytes, publicKey);


                byte[] decryptedBytes = DecryptWithPrivateKey(encryptedBytes, privateKey);
                string decryptedData = System.Text.Encoding.UTF8.GetString(decryptedBytes);


                Console.WriteLine("Original Data: " + originalData);
                Console.WriteLine("Encrypted Data: " + BitConverter.ToString(encryptedBytes).Replace("-", ""));
                Console.WriteLine("Decrypted Data: " + decryptedData);
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }


    static byte[] EncryptWithPublicKey(byte[] data, RSAParameters publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);
            return rsa.Encrypt(data, false);
        }
    }

 
    static byte[] DecryptWithPrivateKey(byte[] data, RSAParameters privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(privateKey);
            return rsa.Decrypt(data, false);
        }
    }
}




