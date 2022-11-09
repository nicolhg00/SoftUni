using System;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList myList = new CustomLinkedList(new int[] { 5, 7, 12 });


            myList.AddFirst(100);

            Console.WriteLine($"Removed item :{myList.RemoveLast()}");

            int[] arr = myList.ToArray();

            myList.Foreach(Console.WriteLine);

            myList.AddLast(2);
        }
    }
}
