using System;

namespace Assig2
{
    class Program13
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            int c = int.Parse(Console.ReadLine());

            int max = Math.Max(a, Math.Max(b, c));

            Console.WriteLine("Largest number: " + max);
        }
    }
}