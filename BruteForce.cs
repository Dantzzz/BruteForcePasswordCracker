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
        public static string correctPwd = "";
        public static TimeSpan time = new TimeSpan();
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
            correctPwd = Run(password);
            Complete(correctPwd);
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
        static string Run(string pwd)
        {
            string correctPwd = "";
            List<Thread> processes = new List<Thread>();

            Console.Clear();
            Console.WriteLine("In progress...");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread firstProcess = new Thread(() =>
            {
                string blank = "";
                FwdCrack(blank);
            });

            Thread secondProcess = new Thread(() => 
            {
                string blank = "";
                ReverseCrack(blank);
            });

            firstProcess.Start();
            secondProcess.Start();
            firstProcess.Join();
            secondProcess.Join();

            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Console.WriteLine("Done!");
            return correctPwd;

            //TODO: Timeout after 30 seconds...
        }
        public static void FwdCrack(string guess)
        {
            attempts++;
            char temp = ' ';

            if (guess == password)
            {
                found = true;
                correctPwd = guess;
                return;
            }
            for (int i = 32; i <= 126; i++)
            {
                if (found == true || guess.Length >= password.Length) return;
                temp = (char)i;
                FwdCrack(guess + temp);
            }
        }

        public static void ReverseCrack(string guess)
        {
            attempts++;
            char temp = ' ';

            if (guess == password)
            {
                found = true;
                correctPwd = guess;
                return;
            }
            for (int i = 126; i >= 32; i--)
            {
                if (found == true || guess.Length >= password.Length) return;
                temp = (char)i;
                FwdCrack(guess + temp);
            }
        }

        public static void Complete(string foundPassword)
        {
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
    }
}
