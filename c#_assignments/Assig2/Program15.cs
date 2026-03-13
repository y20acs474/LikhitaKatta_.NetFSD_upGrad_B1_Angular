using System;

namespace Assig2
{
    class Program15
    {
        static void Main(string[] args)
        {
            int[] marks = new int[10];
            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter mark: ");
                marks[i] = int.Parse(Console.ReadLine());
                total += marks[i];
            }

            Array.Sort(marks);

            Console.WriteLine("Total: " + total);
            Console.WriteLine("Average: " + total / 10);
            Console.WriteLine("Minimum: " + marks[0]);
            Console.WriteLine("Maximum: " + marks[9]);

            Console.WriteLine("Ascending:");
            foreach (int m in marks)
                Console.Write(m + " ");

            Console.WriteLine("\nDescending:");
            for (int i = 9; i >= 0; i--)
                Console.Write(marks[i] + " ");
        }
    }
}