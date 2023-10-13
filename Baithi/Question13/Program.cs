using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Tạo cặp khóa RSA (public key và private key)
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Lấy public key
            string publicKey = rsa.ToXmlString(true);
            Console.WriteLine($"Public Key:\n {publicKey}\n");

            // Lấy private key
            string privateKey = rsa.ToXmlString(false);
            Console.WriteLine($"Private Key:\n {privateKey}\n");

            // Chuỗi cần mã hóa
            string tukhoa = "T2207ENguyenCanhHieu";

            // Mã hóa
            byte[] encryptedData = RSAEncrypt(tukhoa, privateKey);

            // Giải mã
            string decryptedData = RSADecrypt(encryptedData,  publicKey);

            // hiển thị 
            Console.WriteLine($"Tu khoa: {tukhoa}");
            Console.WriteLine($"Encrypted Data: {Convert.ToBase64String(encryptedData)}");
            Console.WriteLine($"Decrypted Data: {decryptedData}");
        }
    }

    // Hàm mã hóa RSA
    static byte[] RSAEncrypt(string tukhoa, string  privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            //sử dụng public key đã lấy từ trên để encrypt
            rsa.FromXmlString(privateKey);
        
            byte[] data = Encoding.UTF8.GetBytes(tukhoa);

            return rsa.Encrypt(data, false);
        }
    }

    // Hàm giải mã RSA
    static string RSADecrypt(byte[] dataToDecrypt, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // sử dụng private key để giải mã
            rsa.FromXmlString(publicKey);
            // chuyển văn bản đã mã hóa về dạng mảng byte
            byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
