using System;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadset = 0;
            int trashedMouse = 0;
            int trashedKeyboard = 0;
            int trashedDisplay = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadset += 1;
                }
                if (i % 3 == 0)
                {
                    trashedMouse += 1;
                } 
                if (i % 6 == 0)
                {
                    trashedKeyboard += 1;
                }
                if (i % 12 == 0)
                {
                    trashedDisplay += 1;
                }

            }
            double rageExpenses = trashedDisplay * displayPrice + trashedHeadset * headsetPrice + trashedKeyboard * keyboardPrice + trashedMouse * mousePrice;
            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");
        }
    }
}
