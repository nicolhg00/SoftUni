using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();

            int counter = 0;

            while (command != "END")
            {
                int greenLight = greenLightSeconds;
                int passSeconds = freeWindow;

                if (command == "green")
                {
                    while (greenLight > 0 && cars.Count != 0)
                    {
                        string firtInQueue = cars.Dequeue();
                        greenLight -= firtInQueue.Length;

                        if (greenLight >0)
                        {
                            counter++;
                        }
                        else
                        {
                            passSeconds += greenLight;
                            if (passSeconds <0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firtInQueue} was hit at {firtInQueue[firtInQueue.Length+passSeconds]}.");
                                return;
                            }
                            counter++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            if (command == "END")
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }
        }
    }
}
