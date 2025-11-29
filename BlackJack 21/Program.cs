using System.Diagnostics.CodeAnalysis;
using System;

namespace BlackJack_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("Do you want to play a round? (Y/N)");
            string answerPlayer = Console.ReadLine().ToUpper();

            while (answerPlayer != "N")
            {
                bool Bust = false;
                int playerCard1 = rand.Next(1, 12);
                int playerCard2 = rand.Next(1, 12);
                int playerTotal = playerCard1 + playerCard2;
                Console.WriteLine($"Your cards: {playerCard1} and {playerCard2}. Total: {playerTotal}");
                int dealerCard1 = rand.Next(1, 12);
                int dealerCard2 = rand.Next(1, 12);
                int dealerTotal = dealerCard1 + dealerCard2;
                // Show dealer's first card, hide second
                Console.WriteLine($"Dealer's cards: {dealerCard1} and A hidden card");
                Console.WriteLine("Do you wish to hit or stand? (H/S)");
                // *** FIXED LINE BELOW ***
                string choice = Console.ReadLine().ToUpper();

                do
                {
                    if (choice == "H")
                    {
                        int PlayerCard3 = rand.Next(1, 12);
                        playerTotal += PlayerCard3;
                        Console.WriteLine($"You drew a {PlayerCard3}. Your total is now {playerTotal}");
                    }

                    if (playerTotal == 21)
                    {
                        Console.WriteLine("Blackjack!");
                        if (dealerTotal == 21) Console.WriteLine("Dealer also has Blackjack! It's a tie!");
                        else Console.WriteLine("You win!");
                        break;
                    }

                    if (playerTotal > 21)
                    {
                        Bust = true;
                        Console.WriteLine("You busted! Dealer wins.");
                        break;
                    }

                    if (choice == "S")
                    {
                        Console.WriteLine("You chose to stand.");
                        Console.WriteLine($"Dealer's hidden card was {dealerCard2}. Dealer's total is {dealerTotal}");

                        if (dealerTotal < 17)
                        {
                            int dealerCard3 = rand.Next(1, 12);
                            dealerTotal += dealerCard3;
                            Console.WriteLine($"Dealer draws a {dealerCard3}. Dealer's total is now {dealerTotal}");
                        }

                        if (dealerTotal > playerTotal) Console.WriteLine("Dealer wins!");
                        else if (dealerTotal < playerTotal) Console.WriteLine("You win!");
                        else Console.WriteLine("It's a tie!");

                        break;
                    }
                    // Second Hit or Stand (Completed)
                    Console.WriteLine("Hit or Stand? (H/S)");
                    choice = Console.ReadLine().ToUpper();

                } while (!Bust);

                Console.WriteLine("Do you want to play another round? (Y/N)");
                answerPlayer = Console.ReadLine().ToUpper();
                if (answerPlayer == "N")
                {
                    Console.WriteLine("Thanks for playing! Goodbye.");
                }
                else if (answerPlayer == "Y")
                {
                    Console.WriteLine("Starting a new round...");
                }
            }
        }
    }
}
