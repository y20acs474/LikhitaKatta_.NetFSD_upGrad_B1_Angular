using System;

namespace Assig2
{
    class Program6
    {
        static void Main(string[] args)
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double f = double.Parse(Console.ReadLine());

            double c = (f - 32) * 5 / 9;

            Console.WriteLine("Temperature in Celsius: " + c);
        }
    }
}