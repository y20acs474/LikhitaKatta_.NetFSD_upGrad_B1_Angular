using System;

namespace Assig2
{
    class Program7
    {
        static void Main(string[] args)
        {
            double total = 0;

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Enter product number: ");
                int p = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity: ");
                int q = int.Parse(Console.ReadLine());

                if (p == 1)
                    total += q * 22.5;
                else if (p == 2)
                    total += q * 44.50;
                else if (p == 3)
                    total += q * 9.98;
            }

            Console.WriteLine("Total price: " + total);
        }
    }
}