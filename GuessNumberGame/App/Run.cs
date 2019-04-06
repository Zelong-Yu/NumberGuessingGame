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
            List<int> Sample = new List<int>(Enumerable.Range(1, 1000));
            foreach (var item in Sample)
            {
             //   Console.WriteLine(item);
            }
            Util.BinarySearch(Sample, 1, true);
        }
    }
}