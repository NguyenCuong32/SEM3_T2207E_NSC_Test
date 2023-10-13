using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSAExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
				{
					string publicKey = rsa.ToXmlString(false); // Lấy khóa công khai
					string privateKey = rsa.ToXmlString(true); // Lấy khóa bí mật

                    string dataToEncrypt = "Hello, RSA!";

					byte[] encryptedData = EncryptData(dataToEncrypt, publicKey);

					Console.WriteLine("Encrypted Data: " + Convert.ToBase64String(encryptedData));

					string decryptedData = DecryptData(encryptedData, privateKey);

					Console.WriteLine("Decrypted Data: " + decryptedData);
					Console.ReadKey();
				}
			}
			catch (CryptographicException e)
			{
				Console.WriteLine("Error: " + e.Message);
			}
		}
		public static byte[] EncryptData(string data, string publicKey)
		{
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.FromXmlString(publicKey);
				byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
				byte[] encryptedData = rsa.Encrypt(dataBytes, false);
				return encryptedData;
			}
		}

		public static string DecryptData(byte[] encryptedData, string privateKey)
		{
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.FromXmlString(privateKey);
				byte[] decryptedData = rsa.Decrypt(encryptedData, false);
				return System.Text.Encoding.UTF8.GetString(decryptedData);
			}
		}
	}
}
