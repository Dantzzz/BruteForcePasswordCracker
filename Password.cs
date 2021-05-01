using System;
using System.Text;

namespace PasswordCracker
{
    class Password
    {
        public static string GeneratePassword()
        {
            const string charOptions = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+[]{};:\"'/?>.<,|\\~`";
            StringBuilder genPwd = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                Random rnd = new Random();
                genPwd.Append(charOptions[rnd.Next(charOptions.Length)]);
            }

            string password = genPwd.ToString();
            return password;
        }
        public static string EnterPassword()
        {
            Console.Clear();
            Console.WriteLine("Please enter a password: ");
            string password = Console.ReadLine();
            while (password.Length < 8 || password.Length > 20)
            {
                Console.WriteLine("Password must be between 8 and 20 characters...\nPlease try again: ");
                password = Console.ReadLine();
            }
            return password;
        }
    }
}
