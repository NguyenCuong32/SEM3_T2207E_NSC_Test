using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string Username = "Admin";
			string Password = "Awdx!@#$%xdwa";
			string passwordHash = Encrypt(Password);
			int menuID = 0;
			Console.WriteLine($"Mat khau {Password} sau khi ma hoa la: \n {passwordHash}");
			do
			{
				menuID = menu();

				switch (menuID)
				{
					case 1:
                        Console.WriteLine("Menu 1: Dang nhap");
                        Console.WriteLine("Nhap vao user name: ");
						string userNameInput = Console.ReadLine();
						Console.WriteLine("Nhap vao mat khau: ");
						string passWordInput = Console.ReadLine();
                        if(Decrypt(passWordInput, passwordHash) && userNameInput == Username)
						{
                            Console.WriteLine("Dang nhap thanh cong");
                        } else
						{
                            Console.WriteLine("Ten tai khoan hoac mat khau khong dung");
                        }
                        break;
					case 2:
						Console.WriteLine("Thoat chuong trinh.");
						break;
				}

			} while (menuID != 2);
            Console.ReadKey();


        }

		//Menu chương trình
		public static int menu()
		{
			int menuID = 0;
			Console.WriteLine("-----Menu chuong trinh-----");
			Console.WriteLine("1. Kiem tra mat khau");
			Console.WriteLine("2. Thoat chuong trinh");
			while (!int.TryParse(Console.ReadLine(), out menuID) || menuID < 1 || menuID > 2)
			{
				Console.WriteLine("Lua chon khong hop le. Vui long chon tu 1-2.");
			}

			return menuID;
		}

		public static string Encrypt(string inputText)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] data = Encoding.UTF8.GetBytes(inputText);
				byte[] hashBytes = sha256.ComputeHash(data);
				return Convert.ToBase64String(hashBytes);
			}
		}
		public static bool Decrypt(string password, string passwordHash)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] data = Encoding.UTF8.GetBytes(password);
				byte[] hashBytes = sha256.ComputeHash(data);
				return Convert.ToBase64String(hashBytes) == passwordHash;
			}
		}
	}
}
