using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain == true) {
                double jackpot = 100000;
                Console.WriteLine("Welcome to Lucky Numbers! The jackpot today is $" + jackpot + " dollars!");
                Console.WriteLine("First, you decide the range to guess your 6 lucky numbers!");
                Console.WriteLine("Please enter your starting number for the range.");
                int startRange = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter your ending number for the range.");
                int endRange = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter your six lucky numbers. Do not duplicate any numbers");
                int[] luckyNums = new int[6];
                for (int i = 0; i < luckyNums.Length; i++)
                {
                    luckyNums[i] = int.Parse(Console.ReadLine());
                    if (luckyNums[i] < startRange || luckyNums[i] > endRange)
                    {
                        Console.WriteLine("Please enter a number between the range you've chosen.");
                        Console.WriteLine("Your range is: " + startRange + " to " + endRange);
                        i--;
                    }
                }

                //generates random lucky numbers
                Random rand = new Random();
                int[] randNums = new int[6];
                for (int i = 0; i < randNums.Length; i++)
                {
                    int randLucky = rand.Next(startRange, endRange + 1);
                    randNums[i] = randLucky;
                    Console.WriteLine("Lucky Number: " + randNums[i]);
                }

                //correctly guessed numbers
                int correctNums = 0;
                for (int i = 0; i < luckyNums.Length; i++)
                {
                    if (luckyNums.Contains(randNums[i]))
                    {
                        correctNums++;
                    }
                }
                Console.WriteLine("You guessed " + correctNums + " correctly!");


                //user's winnings
                double winnings = 0;
                switch (correctNums)
                {
                    case (1):
                        winnings = jackpot / 6;
                        break;

                    case (2):
                        winnings = jackpot / 5;
                        break;

                    case (3):
                        winnings = jackpot / 4;
                        break;

                    case (4):
                        winnings = jackpot / 3;
                        break;

                    case (5):
                        winnings = jackpot / 2;
                        break;

                    case (6):
                        winnings = jackpot;
                        break;

                    default:
                        winnings = 0;
                        break;
                }
                Console.WriteLine("You won $" + winnings + "!");

                Console.WriteLine("Would you like to play again? enter yes or no");
                string input = Console.ReadLine().ToLower();
                
                if(input == "no")
                {
                    playAgain = false;
                    Console.WriteLine("Thanks for playing!");
                }
            }
            
        }
    }
}
