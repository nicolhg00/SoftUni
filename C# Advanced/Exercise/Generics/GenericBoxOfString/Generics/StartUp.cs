using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //3 and 4

           // var numberOfLines = int.Parse(Console.ReadLine());
            //var list = new List<int>();

            // for (int i = 0; i < numberOfLines; i++)
            // {
            //     var input = int.Parse(Console.ReadLine());
            //     list.Add(input);
            // }

            //  var box = new Box<int>(list);
            //  var indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            //  box.Swap(list, indexes[0], indexes[1]);
            // Console.WriteLine(box);

            //5 and 6
            //var list = new List<double>();
            //for (int i = 0; i < numberOfLines; i++)
            //{
            //    var input = double.Parse(Console.ReadLine());
            //    list.Add(input);
            //}
            //var box = new Box<double>(list);
            //var elementsToCompare = double.Parse(Console.ReadLine());
            //var count = box.CountOfGreaterElement(list, elementsToCompare);
            //Console.WriteLine(count);

            //7
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var city = $"{personInfo[2]}";

            var nameAndBear = Console.ReadLine().Split();
            var name = nameAndBear[0];

            var numberOfLiters = int.Parse(nameAndBear[1]);

            var numbersInInput = Console.ReadLine().Split();
            var intNum = int.Parse(numbersInInput[0]);
            var doubleNum = double.Parse(numbersInInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, numberOfLiters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
