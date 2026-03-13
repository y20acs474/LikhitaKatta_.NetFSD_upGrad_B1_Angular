using System;
using System.Collections.Generic;
using System.Text;

namespace ASSIG1
{
    internal class Code4
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number1:-");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number2:-");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 > num2)
                Console.WriteLine($"{num1} is highest Number");
            else
                Console.WriteLine($"{num2} is highest Number");
        }
    }
}
