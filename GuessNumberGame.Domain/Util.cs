using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame.Domain
{
    public class Util
    {
        //Recursive binary search an element in the list. return index number if value found, 
        //if value not found, return a negative number that is the bitwise complement of the index of 
        //the next element that is larger than item or, if there is no larger element, 
        //the bitwise complement of Count.

        //O(NlogN) to sort and O(logN) to search
        public static int BinarySearch(List<int> a, int valueToLookUp, bool sorted = false, bool verbose = true)
        {
            //for general list, need to sort first. O(NlogN) here
            if (!sorted) a.Sort();
            return verbose? BinarySearchSortedListVerbose(a, valueToLookUp) : BinarySearchSortedList(a, valueToLookUp);
        }

        //Given a sorted list, O(logN) to search. Code is from my own whiteboard practice.
        public static int BinarySearchSortedList(List<int> a, int valueToLookUp)
        {
            //Assume the list passed in has been sorted.
            if (a is null || a.Count < 1) return -1;
            int helper(List<int> sub, int startIndex, int endIndex, int value)
            {
                int midpoint = (startIndex + endIndex) / 2;
                if (sub[midpoint] == value) return midpoint;
                //if value not found, return a negative number that is the bitwise complement of the index of 
                //the next element that is larger than item or, if there is no larger element, 
                //the bitwise complement of Count.
                else if (startIndex > endIndex) return ~startIndex;
                else if (value < sub[midpoint])

                {
                    return helper(sub, startIndex, midpoint - 1, value);
                }

                else
                {
                    return helper(sub, midpoint + 1, endIndex, value);
                }
            }

            return helper(a, 0, a.Count - 1, valueToLookUp);
        }

        //the Verbose version
        public static int BinarySearchSortedListVerbose(List<int> a, int valueToLookUp)
        {
            //Assume the list passed in has been sorted.
            if (a is null || a.Count < 1)
            {
                Console.WriteLine("The list is empty. ");
                return -1;
            }
            //keep track of how many guesses
            int guessCount = 0;
            int helper(List<int> sub, int startIndex, int endIndex, int value)
            {
                guessCount++;
                //Print the current list
                Console.Write("\nThe list is now { ");
                for (int i=startIndex; i<=endIndex;++i)
                {
                    Console.Write($"{sub[i]} ");
                }
                Console.Write("}\n");
                int midpoint = (startIndex + endIndex) / 2;
                Console.WriteLine($"The middle value/guessed value is {sub[midpoint]}.");
                if (sub[midpoint] == value)
                {
                    Console.WriteLine($"The value searched for, {valueToLookUp}, has been found. Total guess {guessCount} times.\n");
                    return midpoint;
                }
                //if value not found, return a negative number that is the bitwise complement of the index of 
                //the next element that is larger than item or, if there is no larger element, 
                //the bitwise complement of Count.
                else if (startIndex > endIndex)
                {
                    Console.WriteLine($"Value {valueToLookUp} not found. Value should be insert to index {startIndex}.");
                    return ~startIndex;
                }
                else if (value < sub[midpoint])
                {
                    Console.WriteLine($"The value is lower than {sub[midpoint]}.");
                    return helper(sub, startIndex, midpoint - 1, value);
                }

                else
                {
                    Console.WriteLine($"The value is higher than {sub[midpoint]}.");
                    return helper(sub, midpoint + 1, endIndex, value);
                }
            }

            return helper(a, 0, a.Count - 1, valueToLookUp);
        }

        public static int Guess(int startnum, int endnum, int guessCount = 0)
        {
            int midpoint = (startnum + endnum) / 2;
            //make sure the guessed is no less than 1
            if (midpoint <= 0)
            {
                Console.WriteLine($"That's impossible. Check the number you write down. Is it outside [1,n]?\n");
                return -1;
            }
            Console.WriteLine($"My guess is {midpoint}. \n");
            switch (UI.PromptForInputInline("Is that right? (Q to quit) Y/[N] >\n"))
            {
                case ConsoleKey.Y:
                    guessCount++;
                    Console.WriteLine($"I guess {midpoint} right! That took me {guessCount} guesses.\n");
                    return midpoint;

                case ConsoleKey.N:
                    if (startnum >= endnum)
                    {
                        Console.WriteLine($"That's impossible. Check the number you write down. Is it outside [1,n]?\n");
                        return -1;
                    }
                    switch (UI.PromptForInputInline($"Is {midpoint} too [H]igh or too [L]ow?  (Q to quit)  H/L >\n"))
                    {
                        case ConsoleKey.H:
                            Console.WriteLine($"You say {midpoint} is too high.\n");
                            return Guess(startnum, midpoint - 1, guessCount + 1);
                        case ConsoleKey.L:
                            Console.WriteLine($"You say {midpoint} is too low.\n");
                            return Guess(midpoint + 1, endnum, guessCount + 1);
                        case ConsoleKey.Q:
                            Console.WriteLine($"User Abort. \n");
                            return -1;
                        default:
                            Console.WriteLine("Invalid key. Let's try again.\n");
                            return Guess(startnum, endnum, guessCount);
                    }

                case ConsoleKey.Q:
                    Console.WriteLine($"User Abort. \n");
                    return -1;
                default:
                    Console.WriteLine("Invalid key. Let's try again.\n");
                    return Guess(startnum, endnum, guessCount);
            }

        }

    }
}
