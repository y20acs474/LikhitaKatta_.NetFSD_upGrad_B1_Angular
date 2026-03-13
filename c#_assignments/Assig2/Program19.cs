using System;

namespace Assig2
{
    class Program19
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            char[] arr = word.ToCharArray();
            Array.Reverse(arr);

            string rev = new string(arr);

            if (word == rev)
                Console.WriteLine("Palindrome");
            else
                Console.WriteLine("Not Palindrome");
        }
    }
}