using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            // Create an instance of RSA.
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Generate keys
                string publicKey = rsa.ToXmlString(false); // Public key
                string privateKey = rsa.ToXmlString(true);  // Private key

                // Get user input
                Console.Write("Enter a message: ");
                string plaintext = Console.ReadLine();

                byte[] data = System.Text.Encoding.UTF8.GetBytes(plaintext);
                byte[] encryptedData = rsa.Encrypt(data, false);

                // Decrypt data using the private key
                byte[] decryptedData = rsa.Decrypt(encryptedData, false);
                string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedData);

                Console.WriteLine($"Original: {plaintext}");
                Console.WriteLine($"Encrypted: {Convert.ToBase64String(encryptedData)}");
                Console.WriteLine($"Decrypted: {decryptedText}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}
