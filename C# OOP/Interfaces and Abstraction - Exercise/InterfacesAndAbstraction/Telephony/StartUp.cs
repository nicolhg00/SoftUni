using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split().ToArray();
            string[] url = Console.ReadLine().Split().ToArray();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string phoneNumber = phoneNumbers[i];

                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Call(phoneNumber));
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < url.Length; i++)
            {
                string urls = url[i];
                try
                {
                    Console.WriteLine(smartphone.Browse(urls));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
