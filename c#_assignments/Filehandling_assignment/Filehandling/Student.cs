using System;
using System.IO;

namespace StudentApp
{
    internal class Student
    {
        public string Name;
        public string Roll;
        public int M1, M2, M3;

        public int GetTotal()
        {
            return M1 + M2 + M3;
        }

        public double GetAverage()
        {
            return GetTotal() / 3.0;
        }

        public string GetGrade()
        {
            double avg = GetAverage();

            if (avg >= 75) return "A";
            else if (avg >= 50) return "B";
            else if (avg >= 35) return "C";
            else return "Fail";
        }
    }

    class Program
    {
        static void Main()
        {
            Student s = new Student();

            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();

            Console.Write("Enter Roll Number: ");
            s.Roll = Console.ReadLine();

            Console.Write("Enter Marks (3 subjects): ");
            s.M1 = int.Parse(Console.ReadLine());
            s.M2 = int.Parse(Console.ReadLine());
            s.M3 = int.Parse(Console.ReadLine());

            string content =
                $"Name: {s.Name}\n" +
                $"Roll: {s.Roll}\n" +
                $"Marks: {s.M1}, {s.M2}, {s.M3}\n" +
                $"Total: {s.GetTotal()}\n" +
                $"Average: {s.GetAverage()}\n" +
                $"Grade: {s.GetGrade()}";

            File.WriteAllText(s.Roll + ".txt", content);

            Console.WriteLine("Report saved!");

            // Read file
            Console.Write("Enter Roll to view report: ");
            string r = Console.ReadLine();

            if (File.Exists(r + ".txt"))
            {
                Console.WriteLine(File.ReadAllText(r + ".txt"));
            }
            else
            {
                Console.WriteLine("File not found!");
            }
        }
    }
}