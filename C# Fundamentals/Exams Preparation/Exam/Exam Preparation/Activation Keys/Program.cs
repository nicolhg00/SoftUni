using System;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Generate")
                {
                    break;
                }

                string[] parts = line.Split(">>>");

                string command = parts[0];

                if (command == "Contains")
                {
                    string substr = parts[1];
                    if (text.Contains(substr))
                    {
                        Console.WriteLine($"{text} contains {substr}");

                       
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string casing = parts[1];
                    int startIdx = int.Parse(parts[2]);
                    int endIdx = int.Parse(parts[3]);

                    string substr = text.Substring(startIdx, endIdx - startIdx);
                    string replacement = substr.ToUpper();

                    
                    if (casing == "Lower")
                    {
                        replacement = substr.ToLower();
                    }

                    text = text.Replace(substr, replacement);
                    Console.WriteLine(text);
                  
                }
                else if(command == "Slice")
                {
                    int startIdx = int.Parse(parts[1]);
                    int endIdx = int.Parse(parts[2]);

                    text = text.Remove(startIdx, endIdx - startIdx);

                    Console.WriteLine(text);
                }
            }
            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
