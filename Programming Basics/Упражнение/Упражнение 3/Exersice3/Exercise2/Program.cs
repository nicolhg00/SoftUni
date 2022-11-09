using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int sum = 0;
            switch (operation)
            {
                case '+':
                    sum = number1 + number2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{number1} + {number2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} + {number2} = {sum} - odd");
                    }
                    break;
                case '-':
                    sum = number1 - number2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{number1} - {number2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} - {number2} = {sum} - odd");
                    }
                    break;

                   
                case '*':
                    sum = number1 * number2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{number1} * {number2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} * {number2} = {sum} - odd");
                    }
                    break;
                case '/':
                    
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        double division = number1 * 1.0 / number2;
                        Console.WriteLine($"{number1} / {number2} = {division:f2}");
                    }
                    break;
                case '%':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        sum = number1 % number2;
                        Console.WriteLine($"{number1} % {number2} = {sum}");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
