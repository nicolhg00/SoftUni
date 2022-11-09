using System;
using System.Linq;

namespace Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split().ToArray();
            string[] truckTokens = Console.ReadLine().Split().ToArray();
            string[] busTokens = Console.ReadLine().Split().ToArray();

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentLine = Console.ReadLine().Split().ToArray() ;
                string command = currentLine[0];
                string type = currentLine[1];
                double amount = double.Parse(currentLine[2]);

                if (command is "Drive")
                {
                    if (type is "Car")
                    {
                        CanDrive(car, amount);
                    }
                    else if (type is "Truck")
                    {
                        CanDrive(truck, amount);
                    }
                    else
                    {
                        bus.IsEmpty = false;
                        CanDrive(bus, amount);
                    }
                }
                else if (command is "Refuel")
                {
                    try
                    {
                        if (type is "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (type is "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }

                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, amount);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;
            string result = canDrive
                ? $"{vehicleType} travelled {distance} km"
                : $"{vehicleType} needs refueling";

            Console.WriteLine(result);
        }
    }
}
