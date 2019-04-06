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
                    Console.WriteLine($"The value searched for, {valueToLookUp}, has been found. Total guess {guessCount} times.");
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
    }
}
