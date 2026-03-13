using System;

namespace Assig2
{
    class Program17
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            char[] arr = word.ToCharArray();
            Array.Reverse(arr);

            Console.WriteLine(new string(arr));
        }
    }
}