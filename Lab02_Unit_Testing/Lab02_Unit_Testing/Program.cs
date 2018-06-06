using System;

namespace Lab02_Unit_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Lab 02 ATM!");
            bool inService = true;
            decimal myBalance = 555.55m;
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

                switch (userChoice)
                {
                    case "1":
                        myBalance = ViewBalance(myBalance);
                        Console.WriteLine($"Your current balance is {myBalance}\n");
                        break;
                    case "2":
                        Console.WriteLine("withdraw money - placeholder for function");
                        Console.WriteLine("How much money would you like to withdraw?");
                        try
                        {
                            decimal requested = Convert.ToDecimal(Console.ReadLine());
                            if (requested > myBalance)
                            {
                                Console.WriteLine("You don't have that much money!\n");
                            }
                            else
                            {
                                myBalance = Withdraw(myBalance, requested);
                                Console.WriteLine($"Successfully withdrew ${requested}.");
                                Console.WriteLine($"Your current balance is ${myBalance}.\n");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Returning to main menu.\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("add money - placeholder for function");
                        break;
                    case "4":
                        inService = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("\nThank you for using Lab 02 ATM. Have a nice day!");
            Console.ReadLine();
        }

        public static decimal ViewBalance(decimal myBalance)
        {
            return myBalance;
        }

        public static decimal Withdraw(decimal myBalance, decimal requested)
        {
            if (requested <= myBalance)
                myBalance = myBalance - requested;

            return myBalance;
        }
    }
}
