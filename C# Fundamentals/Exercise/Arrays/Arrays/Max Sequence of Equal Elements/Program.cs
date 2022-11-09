using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int bestSequenceSize = 1;
            int bestSequenceNumber = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];
                int sequenceSize = 1;

                for (int j = i+1; j < arr.Length; j++)
                {
                    int rightNumber = arr[j];

                    if (currentNumber == rightNumber)
                    {
                        sequenceSize += 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sequenceSize > bestSequenceSize)
                {
                    bestSequenceSize = sequenceSize;
                    bestSequenceNumber = currentNumber;
                }
            }

            for (int i = 0; i < bestSequenceSize; i++)
            {
                Console.Write($"{bestSequenceNumber} ");
            }
        }
    }
}
