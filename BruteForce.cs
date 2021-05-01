using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordCracker
{
    class BruteForce
    {
        public static bool found = false;
        public static int attempts = 0;
        public static string password = "";
        public static StringBuilder guessedPassword = new StringBuilder();
        const string siftString = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+[]{};:\"'/?>.<,|\\~`";

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("BRUTE FORCE");
            Console.WriteLine("-----------\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            password = SelectPasswordOption();
            Console.Clear();
            Console.WriteLine("Press any key to start password cracker...");
            Console.ReadKey();
            Run(password);
        }
        static string SelectPasswordOption()
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
        static void Run(string pwd)
        {
            Console.Clear();
            Console.WriteLine("In progress...");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Thread proc1 = new Thread(() => Crack(guessedPassword));
            string correctPwd = Crack(guessedPassword);

            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            Console.WriteLine("Done!");

            //TODO: Timeout after 30 seconds...

            switch (found)
            {
                case true:
                    Console.WriteLine("Password was successfully identified!");
                    Console.WriteLine($"The password is [{correctPwd}].");
                    break;
                case false:
                    Console.WriteLine("Unable to identify password.");
                    break;
            }
            string totalTime = $"{time.Hours}:{time.Minutes}:{time.Seconds}.{time.Milliseconds}";

            Console.WriteLine($"Time Elapsed: {totalTime}");
            Console.WriteLine($"# of attempts: {attempts}");
        }
        public static string Crack(StringBuilder input)
        {
            List<char> siftStringCollection = new List<char>();
            string guessedPwdString = "";

            for (int i = 0; i < siftString.Length; i++)
            {
                siftStringCollection[0] = siftString[0];
            }   

            while(guessedPwdString != password)
            {
                found = false;
                Random rnd = new Random();
                guessedPassword.Append(siftStringCollection[]);
                guessedPwdString += guessedPassword.ToString();
                Console.WriteLine(guessedPassword);
            }
            found = true;
            return guessedPwdString;
        }
    }
}
