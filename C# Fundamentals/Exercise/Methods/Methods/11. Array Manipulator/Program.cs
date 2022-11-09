using System;
using System.Linq;


namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split();

                string command = parts[0];

                if (command == "exchange")
                {
                    int idx = int.Parse(parts[1]);
                    Exchange(numbers, idx);

                }
                else if (command == "max")
                {
                    string paramater = parts[1];

                    int idx = GetMax(numbers, paramater);

                    if (idx == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(idx);
                    }
                }
                else if (command == "min")
                {
                    string paramater = parts[1];

                    int idx = GetMin(numbers, paramater);

                    if (idx == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(idx);
                    }
                }
                else if (command == "first")
                {
                    int count = int.Parse(parts[1]);
                    string parameter = parts[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] firstElements = GetFirstElement(numbers, count, parameter);

                    PrintArray(firstElements);

                }
                else if (command == "last")
                {
                    int count = int.Parse(parts[1]);
                    string parameter = parts[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] lastElement = GetLastElement(numbers, count, parameter);

                    PrintArray(lastElement);
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void PrintArray(int[] elements)
        {
            Console.Write("[");

            bool printed = false;
            foreach (var element in elements)
            {
                if (element != -1)
                {
                    if (printed)
                    {
                        Console.Write($", {element} ");
                    }
                    else
                    {
                        Console.Write($"{element}");
                        printed = true;
                    }
                }
            }
            Console.WriteLine("]");
        }

        private static int[] GetLastElement(int[] numbers, int count, string parameter)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            int parity = GetParity(parameter);
            int idx = 0;

            for (int i = numbers.Length; i >= 0; i--)
            {
                int number = numbers[i];
                if (number % 2 == parity)
                {
                    result[idx] = number;
                    idx++;

                    if (idx >= result.Length)
                    {
                        break;
                    }
                }
            }
            return result.Reverse().ToArray();
        }

        private static int[] GetFirstElement(int[] numbers, int count, string parameter)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            int parity = GetParity(parameter);
            int idx = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == parity)
                {
                    result[idx] = number;
                    idx++;

                    if (idx >= result.Length)
                    {
                        break;
                    }
                }
            }
            return numbers;
        }

        private static int GetParity(string parameter)
        {
            if (parameter == "even")
            {
                return 0;
            }
            return 1;
        }

        private static int GetMin(int[] numbers, string paramaeter)
        {
            int parity = GetParity(paramaeter);

            int minNumber = int.MaxValue;
            int idx = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber <= minNumber
                    && currentNumber % 2 == parity)
                {
                    minNumber = currentNumber;
                    idx = i;

                }
            }
            return idx;
        }

        private static int GetMax(int[] numbers, string parameter)
        {
            int parity = GetParity(parameter);
            int maxNumber = int.MinValue;
            int idx = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber >= maxNumber && currentNumber % 2 == parity)
                {
                    maxNumber = currentNumber;
                    idx = i;

                }
            }
            return idx;
        }

        private static void Exchange(int[] numbers, int idx)
        {

            if (idx < 0 || idx >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            for (int rotation = 0; rotation <= idx; rotation++)
            {
                int firstNumber = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    numbers[i - 1] = numbers[i];
                }
                numbers[numbers.Length - 1] = firstNumber;
            }
        }
    }
}
