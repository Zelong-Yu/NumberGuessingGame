using GuessNumberGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Run
    {
        public Run()
        {
            bool End = false;
            List<string> Mainmenu = new List<string>();
            Mainmenu.Add("1. Implement bisection algorithm");
            Mainmenu.Add("2. Guess my number, human plays");
            Mainmenu.Add("3. Guess my number, computer plays");
            do
            {
                Console.Clear();
                int selected = UI.SelectionMenu(Mainmenu);
                End = HandleSelection(selected);

            } while (!End) ;

        }

        private bool HandleSelection(int selected)
        {
            switch (selected)
            {
                case -1:
                    return true;
                case 0:
                    Console.Clear();
                    bisectionPresentation();
                    return false;
                case 1:
                    Console.Clear();
                    HumanGuess();
                    return false;
                case 2:
                    Console.Clear();
                    ComputerGuess();
                    return false;
                default:
                    return false;
            }
        }

        private void ComputerGuess()
        {
            bool end = false;
            do
            {
                int length = UI.AcceptValidInt("===================================================================================\n" +
                    "Let the computer guess a number between 1 and n. Enter n: (Hit Enter for default = 100. Enter 0 to quit) \n>", 100, 0);
                if (length == 0) break;
                Console.WriteLine($"Pick a number between 1 and {length}. Write it down.");

                Util.Guess(1, length);
            } while (!end);           
        }

        private void HumanGuess()
        {
            bool end = false;
            do
            {
                Random rnd = new Random();
                Console.WriteLine("The computer randomly chooses a number between 1 and 1000. Do your best to guess the number with least guesses.");
                if (ConsoleKey.N == UI.PromptForInputInline("Continued? [Y] / N \n")) break;
                int value = rnd.Next(1, 1000);
                //Console.WriteLine(value); //maintainance check for rnd value
                int guesscount = 0;
                do
                {
                    int guess = UI.AcceptValidInt($"Take a guess from 1 to 1000: Enter 0 to quit) \n>", 1, 0, 1000);
                    if (guess == 0)
                    {
                        end = true;
                        break;
                    }
                    guesscount++;

                    if (guess == value)
                    {
                        Console.WriteLine($"Congrats! <You guessed the number {value} right!> It took you {guesscount} guesses.\n");
                        break;
                    }
                    else if (guess < value) Console.WriteLine($"<Your guess {guess} was too low>. You have guessed {guesscount} times.\n");
                    else Console.WriteLine($"<Your guess {guess} was too high>. You have guessed {guesscount} times.\n");

                } while (true);
            } while (!end);
        }

        private static void bisectionPresentation()
        {
            do
            {
                int length = UI.AcceptValidInt("Will generate a list 1,2,...n. Enter n: (hit Enter for default = 10. Enter 0 to quit) \n>", 10, 0, 130000000);
                if (length == 0) break;
                Console.WriteLine($"n is {length}. ");
                //if range is big, silence mode
                bool verbose = true;
                if (length > 65536)
                {
                    Console.WriteLine("Generated List too large. Silent mode on.");
                    verbose = false;
                }


                int value = UI.AcceptValidInt($"Select a number from 1 to {length}: (hit Enter for default = 1. Enter 0 to quit) \n>", 1, 0, length);
                if (value == 0) break;

                List<int> Sample = new List<int>(Enumerable.Range(1, length));

                int indexOfValue=Util.BinarySearch(Sample, value, true, verbose);

                Console.WriteLine($"Value {value} is at index {indexOfValue}.\n");
            } while (true);
        }
    }
}