using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string plainText = "Hello, AES!";
			string key = "0123456789ABCDEF"; // 16-byte (128-bit) key
			string iv = "FEDCBA9876543210"; // 16-byte (128-bit) IV
			string encryptedText = Encrypt(plainText, key, iv);
			Console.WriteLine("Encrypted Text: " + encryptedText);
			string decryptedText = Decrypt(encryptedText, key, iv);
			Console.WriteLine("Decrypted Text: " + decryptedText);
			Console.ReadKey();
		}

		public static string Encrypt(string plainText, string key, string iv)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes(key);
				aesAlg.IV = Encoding.UTF8.GetBytes(iv);

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(plainText);
						}
					}
					return Convert.ToBase64String(msEncrypt.ToArray());
				}
			}
		}

		public static string Decrypt(string encryptedText, string key, string iv)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes(key);
				aesAlg.IV = Encoding.UTF8.GetBytes(iv);

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							return srDecrypt.ReadToEnd();
						}
					}
				}
			}
		}
	}
}
