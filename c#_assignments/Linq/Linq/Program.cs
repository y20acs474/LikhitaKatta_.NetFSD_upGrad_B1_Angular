using System;
using System.Collections.Generic;
using System.Linq;

// ================= MODELS =================
public class Student
{
    public int Id;
    public string Name;
    public int Age;
    public int Marks;
}

public class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
    public DateTime JoiningDate;
}

public class Customer
{
    public int Id;
    public string Name;
}

public class Order
{
    public int Id;
    public int CustomerId;
    public string CustomerName;
    public DateTime OrderDate;
    public double Amount;
    public double TotalAmount;
}

public class Product
{
    public int Id;
    public string Name;
    public string Category;
    public double Price;
    public int Stock;
}

// ================= MAIN =================
class Program
{
    static void Main()
    {
        Assignment1();
        Assignment2();
        Assignment3();
        Assignment4();
        Assignment5();
        Assignment6();
        Assignment7();
        Assignment9();
        Assignment10();

        Console.WriteLine("\n✅ All Assignments Completed");
    }

    // ================= ASSIGNMENT 1 =================
    static void Assignment1()
    {
        Console.WriteLine("\n--- Assignment 1 ---");

        var students = new List<Student>
        {
            new Student{Id=1, Name="Teja", Age=22, Marks=80},
            new Student{Id=2, Name="Ravi", Age=19, Marks=60},
            new Student{Id=3, Name="Kiran", Age=24, Marks=90}
        };

        var marks75 = students.Where(s => s.Marks > 75);
        var ageRange = students.Where(s => s.Age >= 18 && s.Age <= 25);
        var sorted = students.OrderByDescending(s => s.Marks);
        var selected = students.Select(s => new { s.Name, s.Marks });

        foreach (var s in marks75)
            Console.WriteLine($"Marks>75: {s.Name}");
    }

    // ================= ASSIGNMENT 2 =================
    static void Assignment2()
    {
        Console.WriteLine("\n--- Assignment 2 ---");

        List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

        var even = numbers.Where(x => x % 2 == 0);
        var greater = numbers.Where(x => x > 15);
        var square = numbers.Select(x => x * x);
        var count = numbers.Count(x => x % 5 == 0);

        Console.WriteLine("Even: " + string.Join(",", even));
        Console.WriteLine("Squares: " + string.Join(",", square));
        Console.WriteLine("Divisible by 5 count: " + count);
    }

    // ================= ASSIGNMENT 3 =================
    static void Assignment3()
    {
        Console.WriteLine("\n--- Assignment 3 ---");

        List<string> names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

        var startA = names.Where(x => x.StartsWith("A"));
        var sorted = names.OrderBy(x => x);
        var upper = names.Select(x => x.ToUpper());
        var length = names.Where(x => x.Length > 4);

        Console.WriteLine("Starts with A: " + string.Join(",", startA));
        Console.WriteLine("Uppercase: " + string.Join(",", upper));
    }

    // ================= ASSIGNMENT 4 =================
    static void Assignment4()
    {
        Console.WriteLine("\n--- Assignment 4 ---");

        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Teja", Department="IT", Salary=50000},
            new Employee{Id=2, Name="Ravi", Department="HR", Salary=30000},
            new Employee{Id=3, Name="Kiran", Department="IT", Salary=70000}
        };

        var itDept = employees.Where(e => e.Department == "IT");
        var highest = employees.OrderByDescending(e => e.Salary).First();
        var avg = employees.Average(e => e.Salary);

        Console.WriteLine("IT Employees: " + itDept.Count());
        Console.WriteLine("Highest Salary: " + highest.Name);
        Console.WriteLine("Average Salary: " + avg);
    }

    // ================= ASSIGNMENT 5 =================
    static void Assignment5()
    {
        Console.WriteLine("\n--- Assignment 5 ---");

        var customers = new List<Customer>
        {
            new Customer{Id=1, Name="Teja"},
            new Customer{Id=2, Name="Ravi"}
        };

        var orders = new List<Order>
        {
            new Order{Id=1, CustomerId=1, Amount=3000},
            new Order{Id=2, CustomerId=1, Amount=2500}
        };

        var join = customers.Join(orders,
            c => c.Id,
            o => o.CustomerId,
            (c, o) => new { c.Name, o.Amount });

        foreach (var j in join)
            Console.WriteLine($"{j.Name} - {j.Amount}");
    }

    // ================= ASSIGNMENT 6 =================
    static void Assignment6()
    {
        Console.WriteLine("\n--- Assignment 6 ---");

        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6 };

        var distinct = numbers.Distinct();
        var duplicates = numbers.GroupBy(x => x)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key);

        Console.WriteLine("Distinct: " + string.Join(",", distinct));
        Console.WriteLine("Duplicates: " + string.Join(",", duplicates));
    }

    // ================= ASSIGNMENT 7 =================
    static void Assignment7()
    {
        Console.WriteLine("\n--- Assignment 7 ---");

        var products = new List<Product>
        {
            new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000, Stock=5},
            new Product{Id=2, Name="Phone", Category="Electronics", Price=20000, Stock=20}
        };

        var lowStock = products.Where(p => p.Stock < 10);
        var top3 = products.OrderByDescending(p => p.Price).Take(3);

        Console.WriteLine("Low Stock: " + lowStock.Count());
    }

    // ================= ASSIGNMENT 9 =================
    static void Assignment9()
    {
        Console.WriteLine("\n--- Assignment 9 ---");

        var orders = new List<Order>
        {
            new Order{CustomerName="Teja", OrderDate=DateTime.Now, TotalAmount=5000}
        };

        var last30 = orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));

        Console.WriteLine("Last 30 days orders: " + last30.Count());
    }

    // ================= ASSIGNMENT 10 =================
    static void Assignment10()
    {
        Console.WriteLine("\n--- Assignment 10 ---");

        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Teja", Department="IT", Salary=50000, JoiningDate=DateTime.Now},
            new Employee{Id=2, Name="Ravi", Department="HR", Salary=30000, JoiningDate=DateTime.Now.AddMonths(-2)}
        };

        var sorted = employees.OrderBy(e => e.Department)
                              .ThenByDescending(e => e.Salary);

        Console.WriteLine("Sorted Employees:");
        foreach (var e in sorted)
            Console.WriteLine($"{e.Name} - {e.Department} - {e.Salary}");
    }
}