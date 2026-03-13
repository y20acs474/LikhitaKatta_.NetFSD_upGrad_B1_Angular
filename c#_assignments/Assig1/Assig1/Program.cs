namespace Assig1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number1:-");
            int num1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number2:-");
            int num2=int.Parse(Console.ReadLine());
            Console.WriteLine($"The qout of two numbers is {num1/num2}");
        }
    }
}
