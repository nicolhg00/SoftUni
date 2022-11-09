using System;

namespace MoreExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                bool intTrySevery = int.TryParse(input, out int intValue);
                bool doubleTrySevery = double.TryParse(input, out double doubleValue);
                bool charTrySevery = char.TryParse(input, out char charValue);
                bool boolTrySevery = bool.TryParse(input, out bool boolValue);

                if (intTrySevery)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (doubleTrySevery)
                {
                    Console.WriteLine($"{input} is floating point type");
                }  
                else if (charTrySevery)
                {
                    Console.WriteLine($"{input} is character type");
                } 
                else if (boolTrySevery)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
