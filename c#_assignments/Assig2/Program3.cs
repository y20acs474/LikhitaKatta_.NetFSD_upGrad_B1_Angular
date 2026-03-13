using System;

namespace Assig2
{
    class Program3
    {
        static void Main(string[] args)
        {
            int a = int.Parse(args[0]);
            int b = int.Parse(args[1]);

            for (int i = a + 1; i < b; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}