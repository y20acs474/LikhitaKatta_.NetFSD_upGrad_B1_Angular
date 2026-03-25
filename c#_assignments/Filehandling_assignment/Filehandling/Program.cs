using System;
using System.IO;
using System.Collections.Generic;

class EmployeeLog
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
            Console.Write("Enter choice: ");
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
        Console.Write("Employee ID: ");
        string id = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        string loginTime = DateTime.Now.ToString();

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine($"{id}|{name}|{loginTime}|");
        }

        Console.WriteLine("Login recorded!");
    }

    static void UpdateLogout()
    {
        Console.Write("Enter Employee ID: ");
        string id = Console.ReadLine();

        var lines = new List<string>(File.ReadAllLines(filePath));

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith(id + "|") && lines[i].EndsWith("|"))
            {
                lines[i] += DateTime.Now.ToString();
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