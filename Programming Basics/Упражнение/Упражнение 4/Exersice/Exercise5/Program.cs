using System;


namespace Exercise5
    {
        class Program
        {
            static void Main(string[] args)
            {
                int count = int.Parse(Console.ReadLine());
                double p1 = 0;
                double p2 = 0;
                double p3 = 0;
               

                for (int i = 0; i < count; i += 1)
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num % 2 == 0)
                    {
                        p1+=1;
                    }
                    if (num % 3 == 0)
                    {
                        p2 += 1 ;
                    }
                    if (num % 4== 0)
                    {
                        p3 += 1;
                    }
                   
                  
                }
                Console.WriteLine($"{p1 / count * 100:f2}%");
                Console.WriteLine($"{p2 / count * 100:f2}%");
                Console.WriteLine($"{p3 / count * 100:f2}%");
            
            }
        }
    }


