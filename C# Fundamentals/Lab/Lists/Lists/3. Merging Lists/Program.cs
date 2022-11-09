using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            List<int> secondList = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            List<int> number = new List<int>(firstList.Count + secondList.Count);
            int limit = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < limit; i++)
            {
                number.Add(firstList[i]);
                number.Add(secondList[i]);
            }
            if (firstList.Count != secondList.Count)
            {
                if (firstList.Count > secondList.Count)
                {
                    number.AddRange(GetRemindingList(firstList, secondList));
                }
                else
                {
                    number.AddRange(GetRemindingList(secondList, firstList));
                }
            }
            Console.WriteLine(string.Join(" ",number));
        }

        private static List<int> GetRemindingList(List<int> longerList, List<int> shorterList)
        {
            if (longerList.Count <= shorterList.Count)
            {
                throw new ArgumentException();
            }

            List<int> result = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                result.Add(longerList[i]);
            }

            return result;
        }
    }
}
