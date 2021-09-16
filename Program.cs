using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run() 
        {
            string input;
            var MainAdmin = new Admin("root", "password","salt"); // creating administrator

            while (MainAdmin.Blocked == false)
            {
                Console.Write("Enter password: ");

                input = Console.ReadLine();
                if (MainAdmin.PassCheck(input))
                {
                    Console.WriteLine($"Welcome, {MainAdmin.Login}!");
                    break;
                }
                else
                {
                    if (MainAdmin.Blocked == false)
                    {
                        Console.WriteLine($"Attempt {MainAdmin.PasswordInputCount}! After 3rd attempt your account will be blocked!");
                    }
                    else
                    {
                        Console.WriteLine($"Attempt {MainAdmin.PasswordInputCount}! Your account were blocked!");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
