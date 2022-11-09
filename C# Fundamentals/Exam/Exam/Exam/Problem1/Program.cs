using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            
             string text = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] token = command.Split();

                if (token[0] == "Change")
                {
                    text = text.Replace(token[1], token[2]);
                    Console.WriteLine(text);
                }
                else if (token[0] == "Includes")
                {
                    if (text.Contains(token[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (token[0] == "End")
                {
                    int element = text.IndexOf(token[1]);
                    int lastIndex = text.Length - 1;

                    if (element == lastIndex)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (token[0] == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (token[0] == "FindIndex")
                {
                    int index = text.IndexOf(token[1]);
                    Console.WriteLine(index);
                }
                else if (token[0] == "Cut")
                {
                    int startIndex = int.Parse(token[1]);
                    int length = int.Parse(token[2]);
                    text = text.Substring(startIndex, length);
                    Console.WriteLine(text);
                }

                command = Console.ReadLine();
            }
        }
        
    }
}
