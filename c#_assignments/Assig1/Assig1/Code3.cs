using System;
using System.Collections.Generic;
using System.Text;

namespace ASSIG1
{
    internal class Code3
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number:-");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine($"{num} is even number");
            }
            else
            {
                Console.WriteLine($"{num} is odd number");
            }
        }
    }
}
