using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    //Maggie Reilly 09/14/18
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain == true) {
                double jackpot = 100;
                double div = 6;
                Random rand = new Random();
                int[] luckyNums = new int[6];               
                int[] randNums = new int[6];
                int correctNums = 0;
                

                Console.WriteLine("Welcome to Lucky Numbers! The jackpot today is $" + jackpot + " dollars!");
                Console.WriteLine("You decide the range to guess your 6 lucky numbers!");

                //user inputs starting and ending numbers for the range
                Console.WriteLine("Please enter your starting number for the range.");
                int startRange = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter your ending number for the range.");
                int endRange = int.Parse(Console.ReadLine());

                //user inputs 6 lucky numbers
                Console.WriteLine("Enter your six lucky numbers within your range " + startRange + " to " + endRange + ".");
                Console.WriteLine("Please do not duplicate any numbers");
                //6 numbers saved in array
                for (int i = 0; i < luckyNums.Length; i++)
                {
                    luckyNums[i] = int.Parse(Console.ReadLine());
                    //checks for valid number within the range set by user
                    if (luckyNums[i] < startRange || luckyNums[i] > endRange)
                    {
                        Console.WriteLine("Please enter a valid number between the range: " + startRange + " to " + endRange);                       
                        i--;
                    }
                }

                //generates six random lucky numbers               
                for (int i = 0; i < randNums.Length; i++)
                {
                    int randLucky = rand.Next(startRange, endRange + 1);
                    //checks for duplicate random numbers
                    if (randNums.Contains(randLucky))
                    {
                        i--;
                    }
                    else
                    {
                        randNums[i] = randLucky;                        
                    }                                      
                }
                //displays the six random lucky numbers
                foreach(int random in randNums)
                {
                    Console.WriteLine("Lucky Number: " + random);
                }

                //checks users guessed numbers to the randomly generated numbers
                //number of correctly guessed numbers saved into int variable                
                for (int i = 0; i < luckyNums.Length; i++)
                {
                    if (luckyNums.Contains(randNums[i]))
                    {
                        correctNums++;
                        div --;
                    }
                }
                Console.WriteLine("You guessed " + correctNums + " numbers correctly!");


                //calculates user's winnings
                double winnings = jackpot/div;
                //if there are no correcly guessed numbers, winnings is $0
                if (correctNums == 0)
                {
                    winnings = 0;
                }                
                Console.WriteLine("You won $" + winnings + "!");

                //asks user if they want to play again
                Console.WriteLine("Would you like to play again? enter yes or no");
                string input = Console.ReadLine().ToLower();
                //if input is no, the application ends
                if(input == "no")
                {
                    playAgain = false;
                    Console.WriteLine("Thanks for playing!");
                }
            }
            
        }
    }
}
