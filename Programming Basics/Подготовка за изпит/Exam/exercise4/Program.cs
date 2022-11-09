using System;

namespace exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfEggs = int.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int green = 0;
            int blue = 0;
            int maxNumOfEggs = int.MinValue;
            string maxNumOfEggsColor = "";

            for (int i = 0; i < numOfEggs; i++)
            {
                string color = Console.ReadLine();

                switch (color)
                {
                    case "red":
                        red++;
                        if (red > maxNumOfEggs)
                        {
                            maxNumOfEggs = red;
                            maxNumOfEggsColor = "red";
                        }
                        break;
                    case "blue":
                        blue++;
                        if (blue > maxNumOfEggs)
                        {
                            maxNumOfEggs = blue;
                            maxNumOfEggsColor = "blue";
                        }

                        break;
                    case "orange":
                        orange++;
                        if (orange > maxNumOfEggs)
                        {
                            maxNumOfEggs = orange;
                            maxNumOfEggsColor = "orange";
                        }
                        break;
                    case "green":
                        green++;
                        if (green > maxNumOfEggs)
                        {
                            maxNumOfEggs = green;
                            maxNumOfEggsColor = "green";
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {maxNumOfEggs} -> {maxNumOfEggsColor}");


        }
    }
}
