using System;

namespace PasswordCracker
{
    class BruteForce
    {
        public static void StartUp()
        {
            Console.Clear();
            Console.WriteLine("BRUTE FORCE");
            Console.WriteLine("-----------");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static string SelectPasswordOption()
        {
            Console.Clear();
            Console.WriteLine("To select a password, press 1.\nTo allow the computer to generate a password for you, press 2.");

            int selectedOption = Int32.Parse(Console.ReadLine());
            string password = "";

            while (selectedOption != 1 || selectedOption != 2)
            {
                Console.WriteLine("Invalid. Try again.\nPress any key to return to main menu...");
                Console.ReadKey();
            }
            if(selectedOption == 1)
            {
                password = Password.EnterPassword();
            }
            else
            {
                password = Password.GeneratePassword();
            }
            return password;
            
        }
        public static void Run(string pwd)
        {
            
        }
    }
}
