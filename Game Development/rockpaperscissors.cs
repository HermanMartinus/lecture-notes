using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        bool playAgain = (true);
        while (playAgain == true)
        {
            List<string> choices = new List<string>(){"Rock", "Paper", "Scissors"};
            List<string> win = new List<string>(){"02", "10", "21"};
            List<string> lose = new List<string>(){"01", "20", "12"};
            List<string> tie = new List<string>(){"00", "11", "22"};

            Console.WriteLine("\nWelcome To Rock Paper Scissors");
            Console.WriteLine("Enter your choice:   1.)Rock  2.)Paper  3.)Scissors");
            string playerChoiceString = Console.ReadLine();
            int playerChoice = Int16.Parse(playerChoiceString) - 1;
            Console.WriteLine("You entered {0}", choices[playerChoice]);

            Random rnd = new Random();
            int cpuChoice = rnd.Next(0, 3);

            string result = (playerChoice.ToString() + cpuChoice.ToString());//concatonates the two results to make one where it can be checked in the outcome lists
            Console.WriteLine(string.Format("Your choice: {0} | Computer choice: {1}", choices[playerChoice], choices[cpuChoice]));

            if (win.Contains(result))
            {
                Console.WriteLine("You Won!");
            }

            else if (lose.Contains(result))
            {
                Console.WriteLine("You lost!");
            }
            else if (tie.Contains(result))
            {
                Console.WriteLine("It's a tie!");
            }

            string playerInput;
            Console.WriteLine("Do you want to play again? yes or no.");
            playerInput = Console.ReadLine();

            if (playerInput == "yes")
            {
                playAgain = (true);
            }
            else if (playerInput == "no")
            {
                playAgain = (false);
            }

        }

    }

}