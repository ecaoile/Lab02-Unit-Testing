using System;

namespace Lab02_Unit_Testing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // welcome message and declaration of initial values
            Console.WriteLine("Welcome to Lab 02 ATM!");
            bool inService = true;
            decimal myBalance = 555.55m;
            try
            {
                while (inService == true)
                {
                    // main menu that appears at the beginning of every loop
                    Console.WriteLine("How can we help you today?");
                    Console.WriteLine("1. View Balance");
                    Console.WriteLine("2. Withdraw Money");
                    Console.WriteLine("3. Add Money");
                    Console.WriteLine("4. Exit");

                    string userChoice = Console.ReadLine();

                    // loops until user chooses a valid menu option
                    while (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4")
                    {
                        Console.WriteLine("You did not choose a valid option. Please choose a number between 1 and 4");
                        userChoice = Console.ReadLine();
                    }

                    // switch case to handle the different ATM operations
                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine($"Your current balance is {myBalance:c}.");
                            Console.WriteLine("Returning to main menu.\n");
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
                                if (myDeposit < 0)
                                    Console.WriteLine("You can't withdraw negative amounts!");
                                else
                                {
                                    myBalance = Deposit(myBalance, myDeposit);
                                    Console.WriteLine($"Thank you for your deposit of {myDeposit:c}.");
                                    Console.WriteLine($"Your balance is now {myBalance:c}.\n");
                                }
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
        }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                // closing message before exit
                Console.WriteLine("\nThank you for using Lab 02 ATM. Have a nice day!");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// allows user to withdraw money from their bank account
        /// </summary>
        /// <param name="myBalance">the user's current balance</param>
        /// <param name="myWithdrawl">the amount the user wishes to withdraw</param>
        /// <returns>remaining balance after withdrawal</returns>
        public static decimal Withdraw(decimal myBalance, decimal myWithdrawl)
        {
            if (myWithdrawl <= myBalance && myWithdrawl >= 0)
                myBalance = myBalance - myWithdrawl;

            return myBalance;
        }

        /// <summary>
        /// allows user to deposit money to their bank account
        /// </summary>
        /// <param name="myBalance">the user's current balance</param>
        /// <param name="myDeposit">the amount the user wishes to deposit</param>
        /// <returns>remaining balance after deposit</returns>
        public static decimal Deposit(decimal myBalance, decimal myDeposit)
        {
            if (myDeposit >= 0)
                myBalance += myDeposit;

            return myBalance;
        }
    }
}
