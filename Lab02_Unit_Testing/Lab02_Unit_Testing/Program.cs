using System;

namespace Lab02_Unit_Testing
{
    public class Program
    {
        public static void Main(string[] args)
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
                        Console.WriteLine($"Your current balance is {myBalance:c}\n");
                        break;
                    case "2":
                        Console.WriteLine("\nHow much money would you like to withdraw?");
                        try
                        {
                            decimal myWithdrawl = Convert.ToDecimal(Console.ReadLine());

                            if (myWithdrawl > myBalance)
                                Console.WriteLine("You don't have that much money!\n");
                            else if (myWithdrawl < 0)
                                Console.WriteLine("You can't withdraw negative amounts!");

                            else
                            {
                                myBalance = Withdraw(myBalance, myWithdrawl);
                                Console.WriteLine($"Successfully withdrew {myWithdrawl:c}.");
                                Console.WriteLine($"Your current balance is {myBalance:c}.\n");
                            }
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Error: you didn't enter a valid number!");
                            Console.WriteLine("Withdrawal failed.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Withdrawal failed.");
                            throw;
                        }
                        finally
                        {
                            Console.WriteLine("Returning to main menu.\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\nHow much money would you like to deposit?");
                        try
                        {
                            decimal myDeposit = Convert.ToDecimal(Console.ReadLine());
                            myBalance = Deposit(myBalance, myDeposit);
                            Console.WriteLine($"Thank you for your deposit of {myDeposit:c}.");
                            Console.WriteLine($"Your balance is now {myBalance:c}.\n");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: you didn't enter a valid number!");
                            Console.WriteLine("Deposit failed.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Deposit failed.");
                            throw;
                        }
                        finally
                        {
                            Console.WriteLine("Returning to main menu.\n");
                        }
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

        public static decimal Withdraw(decimal myBalance, decimal myWithdrawl)
        {
            if (myWithdrawl <= myBalance && myWithdrawl >= 0)
                myBalance = myBalance - myWithdrawl;

            return myBalance;
        }

        public static decimal Deposit(decimal myBalance, decimal myDeposit)
        {
            if (myDeposit >= 0)
                myBalance += myDeposit;

            return myBalance;
        }
    }
}
