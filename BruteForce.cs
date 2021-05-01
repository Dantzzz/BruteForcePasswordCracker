using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordCracker
{
    class BruteForce
    {

        public static bool found = false;
        public static int attempts = 0;
        public static string password = "";

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

            Thread proc1 = new Thread(() => CrackSectorA(String.Empty));
            proc1.Start();
            Thread proc2 = new Thread(() => CrackSectorB(String.Empty));
            proc2.Start();
            Thread proc3 = new Thread(() => CrackSectorC(String.Empty));
            proc3.Start();
            Thread proc4 = new Thread(() => CrackSectorD(String.Empty));
            proc4.Start();

            proc1.Join();
            proc2.Join();
            proc3.Join();
            proc4.Join();

            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            Console.WriteLine("Done!");

            switch (found)
            {
                case true:
                    Console.WriteLine("Password was successfully identified!");
                    break;
                case false:
                    Console.WriteLine("Unable to identify password.");
                    break;
            }
            string totalTime = $"{time.Hours}:{time.Minutes}:{time.Seconds}.{time.Milliseconds}";
            Console.WriteLine($"Time Elapsed: {totalTime}");
            Console.WriteLine($"# of attempts: {attempts}");
        }

        static void CrackSectorA(string input)
        {
            attempts++;
            if(input == password)
            {
                found = true;
                return;
            }

            char temp = ' ';
            for (int i = 32; i < 56; i++)
            {
                if (found == true || input.Length >= password.Length)
                { 
                    return; 
                }
                temp = (char)i;
                CrackSectorA(input + temp);
            }
        }
        static void CrackSectorB(string input)
        {
            attempts++;
            if (input == password)
            {
                found = true;
                return;
            }

            char temp = ' ';
            for (int i = 56; i < 79; i++)
            {
                if (found == true || input.Length >= password.Length)
                {
                    return;
                }
                temp = (char)i;
                CrackSectorA(input + temp);
            }
        }
        static void CrackSectorC(string input)
        {
            attempts++;
            if (input == password)
            {
                found = true;
                return;
            }

            char temp = ' ';
            for (int i = 79; i < 103; i++)
            {
                if (found == true || input.Length >= password.Length)
                {
                    return;
                }
                temp = (char)i;
                CrackSectorA(input + temp);
            }
        }
        static void CrackSectorD(string input)
        {
            attempts++;
            if (input == password)
            {
                found = true;
                return;
            }

            char temp = ' ';
            for (int i = 103; i < 127; i++)
            {
                if (found == true || input.Length >= password.Length)
                {
                    return;
                }
                temp = (char)i;
                CrackSectorA(input + temp);
            }
        }
    }
}
