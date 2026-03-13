using System;
using System.Collections.Generic;
using System.Text;

namespace ASSIG1
{
    internal class Code6
    {
        public static void Main()
        {
            Console.WriteLine("Enter distance:");
            int distance = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter speed:");
            int speed = int.Parse(Console.ReadLine());

            int time = distance / speed;

            Console.WriteLine($"Time taken for the journey is {time}");
        }
    }
}
