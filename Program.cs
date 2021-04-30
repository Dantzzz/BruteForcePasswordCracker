using System;

namespace PasswordCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            BruteForce.StartUp();
            string password = BruteForce.SelectPasswordOption();
            BruteForce.Run()
        }
    }
}
