﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordCracker
{
    class BruteForce
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("BRUTE FORCE");
            Console.WriteLine("-----------\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            string password = SelectPasswordOption();
            Console.Clear();
            Console.WriteLine("Press any key to start password cracker...");
            Console.ReadKey();
            Run(password);
        }
        public static string SelectPasswordOption()
        {
            Console.Clear();
            Console.WriteLine("To select a password, press 1.\nTo allow the computer to generate a password for you, press 2.");

            int selectedOption = Int32.Parse(Console.ReadLine());
            string password = "";

            if (selectedOption == 1)
            {
                password = Password.EnterPassword();
            }
            else if (selectedOption == 2)
            {
                password = Password.GeneratePassword();
            }
            else
            {
                Console.WriteLine("Invalid. Try again.\nPress any key to return to main menu...");
                Console.ReadKey();
            }
            return password;
        }
        public static void Run(string pwd)
        {
            bool found = false;
            int attempts = 0;

            Console.Clear();
            Console.WriteLine("In progress...");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread proc1 = new Thread(() => Crack(String.Empty);
            Thread proc2 = new Thread(() => Crack(String.Empty);
        }

        public static void Crack()
        {
            //TODO
        }

    }
}
