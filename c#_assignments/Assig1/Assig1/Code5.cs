using System;
using System.Collections.Generic;
using System.Text;

namespace ASSIG1
{
    internal class Code5
    {
        public static void Main()
        {
            Console.WriteLine("Enter length of rectangle:");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter breadth of rectangle:");
            int breadth = int.Parse(Console.ReadLine());

            int rectArea = length * breadth;
            Console.WriteLine($"Area of Rectangle = {rectArea}");

            Console.WriteLine("Enter side of square:");
            int side = int.Parse(Console.ReadLine());

            int squareArea = side * side;
            Console.WriteLine($"Area of Square = {squareArea}");
        }
    }
}
