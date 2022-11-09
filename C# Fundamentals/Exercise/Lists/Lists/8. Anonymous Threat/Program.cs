using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _8._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "3:1")
                {
                    break;
                }
                string[] parts = line.Split();
                string command = parts[0];

                if (command == "merge")
                {
                    int startIdx = int.Parse(parts[1]);
                    int endIdx = int.Parse(parts[2]);

                    if (startIdx >=elements.Count || endIdx <0)
                    {
                        continue;
                    }

                    if (startIdx < 0)
                    {
                        startIdx = 0;
                    }
                    if (endIdx >= elements.Count)
                    {
                        endIdx = elements.Count - 1;
                    }
                    string merged = string.Empty;
                    for (int i = startIdx; i <= endIdx; i++)
                    {
                        string element = elements[i];
                        merged += element;
                    }
                    elements.RemoveRange(startIdx, endIdx - startIdx + 1);
                    elements.Insert(startIdx, merged);
                }
                else
                {
                    int idx = int.Parse(parts[1]);
                    int partitions = int.Parse(parts[2]);
                    string element = elements[idx];

                    elements.RemoveAt(idx);

                    int partitionSize = element.Length / partitions;
                    
                    List<string> substrings = new List<string>();
                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i*partitionSize, partitionSize);
                        substrings.Add(substring);
                    }

                    string lastSubstring = element.Substring((partitions - 1)* partitionSize);
                    substrings.Add(lastSubstring);
                    elements.InsertRange(idx, substrings);
                    
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
