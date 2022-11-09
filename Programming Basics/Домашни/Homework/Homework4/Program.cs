using System;
using System.Drawing;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            string kind = Console.ReadLine();
            
            if (kind == "square")
            {
                double squareNum = double.Parse(Console.ReadLine());
                double squareS = (Math.Round(squareNum* squareNum ,3));
                Console.WriteLine(squareS);
            }
            else if (kind == "rectangle")
            {

                double rectangleNumOne = double.Parse(Console.ReadLine());
                double rectangleNumTwo = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(rectangleNumOne * rectangleNumTwo,3));
            }
            else if (kind == "circle")
            {
                double circleNum = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(circleNum * circleNum*Math.PI,3));
            }
            else if (kind == "triangle")
            {
                double triangleNumOne = double.Parse(Console.ReadLine());
                double trianleNumTwo = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((triangleNumOne*trianleNumTwo) / 2 ,3));
            }
        }
    }
}
