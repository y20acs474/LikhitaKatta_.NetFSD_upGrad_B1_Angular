using System;

namespace Assig2
{
    class Program5
    {
        static void Main(string[] args)
        {
            int odd = 0, even = 0;

            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter number: ");
                int n = int.Parse(Console.ReadLine());

                if (n % 2 == 0)
                    even++;
                else
                    odd++;
            }

            Console.WriteLine("Even count: " + even);
            Console.WriteLine("Odd count: " + odd);
        }
    }
}