using System;
using System.Collections.Generic;
using System.Text;

namespace ASSIG1
{
    internal class Code2
    {
        public static void Main()
        {
            Console.WriteLine("Enter the 1st number:-");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number:-");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 3rd number:-");
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 4th number:-");
            int num4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 5th number:-");
            int num5 = int.Parse(Console.ReadLine());
            Console.WriteLine($"The sum of 5 numbers {num1 + num2 + num3 + num4 + num5}");
        }
    }
}

