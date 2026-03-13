using System;

namespace Assig2
{
    class Program10
    {
        static void Main(string[] args)
        {
            int a = 0, b = 1;

            while (a <= 40)
            {
                Console.Write(a + " ");
                int temp = a + b;
                a = b;
                b = temp;
            }
        }
    }
}