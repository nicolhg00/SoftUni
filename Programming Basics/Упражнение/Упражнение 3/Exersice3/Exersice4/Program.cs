using System;

namespace Exersice4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int hourExam = int.Parse(Console.ReadLine());
            int minutesExam = int.Parse(Console.ReadLine());
            int hourArrive = int.Parse(Console.ReadLine());
            int minutesArrive = int.Parse(Console.ReadLine());

            int examInMinutes = hourExam * 60 + minutesExam;
            int arriveInMinutes = hourArrive * 60 + minutesArrive;
            if (arriveInMinutes > examInMinutes)
            {
                Console.WriteLine("Late");
                int lateInMinutes = arriveInMinutes - examInMinutes;
                if (lateInMinutes < 60)
                {
                    Console.WriteLine($"{lateInMinutes} minutes after the start");
                }
                else
                {
                    int lateHour = lateInMinutes / 60;
                    int lateMin = lateInMinutes % 60;
                    Console.WriteLine($"{lateHour}:{lateMin:d2} hours after the start");
                }
            }
            else if (arriveInMinutes == examInMinutes || (examInMinutes-arriveInMinutes) <= 30)
            {
                Console.WriteLine("On time");
                if (arriveInMinutes != examInMinutes)
                {
                    Console.WriteLine($"{examInMinutes - arriveInMinutes} minutes before the start");
                }
            }
            else if ((examInMinutes-arriveInMinutes) > 30)
            {
                Console.WriteLine("Early");
                int earlyInMinutes = examInMinutes - arriveInMinutes;
                if (earlyInMinutes < 60)
                {
                    Console.WriteLine($"{earlyInMinutes} minutes before the start");
                }
                else
                {
                    int earlyHour = earlyInMinutes / 60;
                    int earlyMin = earlyInMinutes % 60;
                    Console.WriteLine($"{earlyHour}:{earlyMin:d2} hours before the start");
                }
            }

        }
    }
}
