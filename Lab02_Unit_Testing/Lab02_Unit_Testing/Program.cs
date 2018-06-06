﻿using System;

namespace Lab02_Unit_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Lab 02 ATM!");
            bool inService = true;
            while (inService == true)
            {
                Console.WriteLine("How can we help you today?");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Add Money");
                Console.WriteLine("4. Exit");

                string userChoice = Console.ReadLine();

                while (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4")
                {
                    Console.WriteLine("You did not choose a valid option. Please choose a number between 1 and 4");
                    userChoice = Console.ReadLine();
                }

                if (userChoice == "4")
                    inService = false; 
            }
            Console.WriteLine("Thank you for using a Lab 02 ATM. Have a nice day!");
            Console.ReadLine();
        }
    }
}