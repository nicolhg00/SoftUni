using System;
using System.Text;

namespace _4._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();


            foreach (char letter in text)
            {
                char encryptedLetter = (char)(letter + 3);

                encryptedText.Append(encryptedLetter);
            }
            Console.WriteLine(encryptedText);
        }
    }
}
