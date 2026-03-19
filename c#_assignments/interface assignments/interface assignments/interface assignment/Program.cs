using System;


public interface GovtRules
{
    double EmployeePF(double basicSalary);
    string LeaveDetails();
    double gratuityAmount(float serviceCompleted, double basicSalary);
}

public class TCS : GovtRules
{
   
    private int empid;
    private string name, dept, desg;
    private double basicSalary;

  
    public TCS(int empid, string name, string dept, string desg, double basicSalary)
    {
        this.empid = empid;
        this.name = name;
        this.dept = dept;
        this.desg = desg;
        this.basicSalary = basicSalary;
    }


    public int EmpId { get { return empid; } }
    public string Name { get { return name; } }
    public string Dept { get { return dept; } }
    public string Desg { get { return desg; } }
    public double Salary { get { return basicSalary; } }

    
    public double EmployeePF(double basicSalary)
    {
        double employeePF = 0.12 * basicSalary;
        double employerPF = 0.0833 * basicSalary;
        double pension = 0.0367 * basicSalary;

        Console.WriteLine("Employee PF (12%): " + employeePF);
        Console.WriteLine("Employer PF (8.33%): " + employerPF);
        Console.WriteLine("Pension Fund (3.67%): " + pension);

        return employeePF + employerPF;
    }

   
    public string LeaveDetails()
    {
        return "1 day Casual Leave/month\n12 days Sick Leave/year\n10 days Privilege Leave/year";
    }

   
    public double gratuityAmount(float serviceCompleted, double basicSalary)
    {
        if (serviceCompleted > 20)
            return 3 * basicSalary;
        else if (serviceCompleted > 10)
            return 2 * basicSalary;
        else if (serviceCompleted > 5)
            return 1 * basicSalary;
        else
            return 0;
    }

    
    public void Display(float service)
    {
        Console.WriteLine("\n--- TCS Employee Details ---");
        Console.WriteLine($"ID: {EmpId}, Name: {Name}, Dept: {Dept}, Designation: {Desg}");
        Console.WriteLine("Basic Salary: " + Salary);

        EmployeePF(Salary);

        Console.WriteLine("\nLeave Details:\n" + LeaveDetails());

        Console.WriteLine("\nGratuity Amount: " + gratuityAmount(service, Salary));
    }
}


public class Accenture : GovtRules
{
    private int empid;
    private string name, dept, desg;
    private double basicSalary;

  
    public Accenture(int empid, string name, string dept, string desg, double basicSalary)
    {
        this.empid = empid;
        this.name = name;
        this.dept = dept;
        this.desg = desg;
        this.basicSalary = basicSalary;
    }

  
    public int EmpId { get { return empid; } }
    public string Name { get { return name; } }
    public string Dept { get { return dept; } }
    public string Desg { get { return desg; } }
    public double Salary { get { return basicSalary; } }

 
    public double EmployeePF(double basicSalary)
    {
        double employeePF = 0.12 * basicSalary;
        double employerPF = 0.12 * basicSalary;

        Console.WriteLine("Employee PF (12%): " + employeePF);
        Console.WriteLine("Employer PF (12%): " + employerPF);

        return employeePF + employerPF;
    }

  
    public string LeaveDetails()
    {
        return "2 days Casual Leave/month\n5 days Sick Leave/year\n5 days Privilege Leave/year";
    }

   
    public double gratuityAmount(float serviceCompleted, double basicSalary)
    {
        return 0; 
    }


    public void Display(float service)
    {
        Console.WriteLine("\n--- Accenture Employee Details ---");
        Console.WriteLine($"ID: {EmpId}, Name: {Name}, Dept: {Dept}, Designation: {Desg}");
        Console.WriteLine("Basic Salary: " + Salary);

        EmployeePF(Salary);

        Console.WriteLine("\nLeave Details:\n" + LeaveDetails());

        Console.WriteLine("\nGratuity Amount: Not Applicable");
    }
}


class Program
{
    static void Main()
    {
        // TCS Employee
        TCS tcsEmp = new TCS(101, "Rahul", "IT", "Developer", 50000);
        tcsEmp.Display(12); // 12 years service

        // Accenture Employee
        Accenture accEmp = new Accenture(102, "Sneha", "HR", "Manager", 60000);
        accEmp.Display(8);
    }
}