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
            string publicKey = rsa.ToXmlString(false);
            Console.WriteLine($"Public Key:\n {publicKey}\n");

            // Lấy private key
            string privateKey = rsa.ToXmlString(true);
            Console.WriteLine($"Private Key:\n {privateKey}\n");

            // Chuỗi cần mã hóa
            string tukhoa = "T2208E";

            // Mã hóa trả về mảng byte , ta cần mảng byte để giải mã => convert mảng byte về dạng base 64 để xem được chuỗi đã mã hóa
            byte[] encryptedData = RSAEncrypt(tukhoa, publicKey);

            // Giải mã cho mảng byte đã mã hóa cùng với private key để giải mã
            string decryptedData = RSADecrypt(encryptedData, privateKey);

            // hiển thị 
            Console.WriteLine($"Tu khoa: {tukhoa}");
            Console.WriteLine($"Encrypted Data: {Convert.ToBase64String(encryptedData)}");
            Console.WriteLine($"Decrypted Data: {decryptedData}");
        }
    }

    // Hàm mã hóa RSA
    static byte[] RSAEncrypt(string tukhoa, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            //sử dụng public key đã lấy từ trên để encrypt
            rsa.FromXmlString(publicKey);
            // chuyển văn bản cần encrypt sang dạng mảng byte
            byte[] data = Encoding.UTF8.GetBytes(tukhoa);

            return rsa.Encrypt(data, false);
        }
    }

    // Hàm giải mã RSA
    static string RSADecrypt(byte[] dataToDecrypt, string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // sử dụng private key để giải mã
            rsa.FromXmlString(privateKey);

            // chuyển văn bản đã mã hóa về dạng mảng byte
            byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}

