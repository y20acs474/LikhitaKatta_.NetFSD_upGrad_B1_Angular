using System;

namespace Assig2
{
    class Program11
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine(n + " x " + i + " = " + (n * i));
            }
        }
    }
}