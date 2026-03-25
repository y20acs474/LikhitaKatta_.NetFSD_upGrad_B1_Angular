using System;
using System.IO;
using System.Collections.Generic;

namespace EmployeeApp
{
    internal class Employee
    {
        public string Id;
        public string Name;
        public string LoginTime;
        public string LogoutTime;
    }

    class Program
    {
        static string filePath = "employee_log.txt";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Login");
                Console.WriteLine("2. Update Logout");
                Console.WriteLine("3. View Logs");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddLogin();
                            break;
                        case 2:
                            UpdateLogout();
                            break;
                        case 3:
                            ViewLogs();
                            break;
                        case 4:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void AddLogin()
        {
            Employee emp = new Employee();

            Console.Write("Enter ID: ");
            emp.Id = Console.ReadLine();

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            emp.LoginTime = DateTime.Now.ToString();
            emp.LogoutTime = "";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{emp.Id}|{emp.Name}|{emp.LoginTime}|{emp.LogoutTime}");
            }

            Console.WriteLine("Login added!");
        }

        static void UpdateLogout()
        {
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split('|');

                if (parts[0] == id && string.IsNullOrEmpty(parts[3]))
                {
                    parts[3] = DateTime.Now.ToString();
                    lines[i] = string.Join("|", parts);
                    break;
                }
            }

            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Logout updated!");
        }

        static void ViewLogs()
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine(File.ReadAllText(filePath));
            }
            else
            {
                Console.WriteLine("No logs found.");
            }
        }
    }
}