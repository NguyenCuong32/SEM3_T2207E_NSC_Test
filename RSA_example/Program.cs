using System.Security.Cryptography;
using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

class Program
{
    static void Main()
    {
        // Tạo cặp khóa RSA
        AsymmetricCipherKeyPair keyPair = GenerateKeyPair();

        // Mã hóa văn bản
        string plaintext = "Hello, RSA!";
        byte[] encryptedData = Encrypt(plaintext, (RsaKeyParameters)keyPair.Public);

        Console.WriteLine($"Plaintext: {plaintext}");
        Console.WriteLine($"Encrypted: {Convert.ToBase64String(encryptedData)}");

        // Giải mã dữ liệu đã được mã hóa
        byte[] decryptedData = Decrypt(encryptedData, (RsaKeyParameters)keyPair.Private);
        string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedData);

        Console.WriteLine($"Decrypted: {decryptedText}");
    }

    static AsymmetricCipherKeyPair GenerateKeyPair()
    {
        // Tạo generator khóa RSA
        var keyGenerationParameters = new KeyGenerationParameters(new SecureRandom(), 2048);
        var keyPairGenerator = GeneratorUtilities.GetKeyPairGenerator("RSA");
        keyPairGenerator.Init(keyGenerationParameters);

        // Tạo cặp khóa RSA
        return keyPairGenerator.GenerateKeyPair();
    }

    static byte[] Encrypt(string plaintext, RsaKeyParameters publicKey)
    {
        // Chuyển đổi văn bản thành mảng byte
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

        // Tạo bộ mã hóa RSA
        var cipher = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");
        cipher.Init(true, publicKey);

        // Mã hóa dữ liệu
        return cipher.DoFinal(inputBytes);
    }

    static byte[] Decrypt(byte[] encryptedData, RsaKeyParameters privateKey)
    {
        // Tạo bộ giải mã RSA
        var cipher = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");
        cipher.Init(false, privateKey);

        // Giải mã dữ liệu
        return cipher.DoFinal(encryptedData);
    }
}