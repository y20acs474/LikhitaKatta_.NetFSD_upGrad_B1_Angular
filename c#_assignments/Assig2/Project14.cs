using System;

namespace Assig2
{
    class Program14
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;

            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter number: ");
                int n = int.Parse(Console.ReadLine());

                if (n < min)
                    min = n;
            }

            Console.WriteLine("Smallest number: " + min);
        }
    }
}