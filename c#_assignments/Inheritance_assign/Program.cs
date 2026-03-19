using System;
using System.Collections.Generic;

namespace Inheritance_assign
{
    // =========================
    // ASSIGNMENT 1 - Healthcare
    // =========================

    class Staff
    {
        public int StaffId;
        public string Name;
        public double BaseSalary;

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Doctor : Staff
    {
        public double ConsultationFee;

        public override double CalculateSalary()
        {
            return BaseSalary + ConsultationFee;
        }
    }

    class Nurse : Staff
    {
        public double NightShiftAllowance;

        public override double CalculateSalary()
        {
            return BaseSalary + NightShiftAllowance;
        }
    }

    class LabTechnician : Staff
    {
        public double EquipmentAllowance;

        public override double CalculateSalary()
        {
            return BaseSalary + EquipmentAllowance;
        }
    }


    // =========================
    // ASSIGNMENT 2 - Banking
    // =========================

    class Account
    {
        public int AccountNumber;
        public double Balance;

        public void CalculateInterest()
        {
            Console.WriteLine("Base account interest calculation");
        }
    }

    class SavingsAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Savings Account Interest: 5%");
        }
    }

    class CurrentAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Current Account Interest: 3%");
        }
    }


    // =========================
    // ASSIGNMENT 3 - E-Commerce
    // =========================

    class Order
    {
        public int OrderId;
        public double OrderAmount;

        public virtual double CalculateShippingCost()
        {
            return 50;
        }
    }

    class StandardOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 50;
        }
    }

    class ExpressOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 100;
        }
    }

    class InternationalOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 500;
        }
    }


    // =========================
    // ASSIGNMENT 4 - Vehicle
    // =========================

    class Vehicle
    {
        public string VehicleNumber;
        public string Brand;

        public void StartVehicle()
        {
            Console.WriteLine("Vehicle Started");
        }
    }

    class Car : Vehicle
    {
        public string FuelType;
    }

    sealed class ElectricCar : Car
    {
        public int BatteryCapacity;
    }

    // This will cause compile error if uncommented
    // class Tesla : ElectricCar { }


    // =========================
    // ASSIGNMENT 5 - Education
    // =========================

    class Student
    {
        public int StudentId;
        public string Name;
        public int Marks;

        public virtual void CalculateGrade()
        {
            if (Marks > 50)
                Console.WriteLine(Name + " : Pass");
            else
                Console.WriteLine(Name + " : Fail");
        }
    }

    class SchoolStudent : Student
    {
        public override void CalculateGrade()
        {
            if (Marks > 40)
                Console.WriteLine(Name + " : Pass");
            else
                Console.WriteLine(Name + " : Fail");
        }
    }

    class CollegeStudent : Student
    {
        public override void CalculateGrade()
        {
            if (Marks > 50)
                Console.WriteLine(Name + " : Pass");
            else
                Console.WriteLine(Name + " : Fail");
        }
    }

    class OnlineStudent : Student
    {
        public override void CalculateGrade()
        {
            if (Marks > 60)
                Console.WriteLine(Name + " : Pass");
            else
                Console.WriteLine(Name + " : Fail");
        }
    }


    // =========================
    // ASSIGNMENT 6 - Furniture
    // =========================

    class Furniture
    {
        public int OrderId;
        public string OrderDate;
        public string FurnitureType;
        public int Qty;
        public double TotalAmt;
        public string PaymentMode;

        public virtual void GetData()
        {
            Console.Write("Order Id: ");
            OrderId = int.Parse(Console.ReadLine());

            Console.Write("Order Date: ");
            OrderDate = Console.ReadLine();

            Console.Write("Quantity: ");
            Qty = int.Parse(Console.ReadLine());

            Console.Write("Payment Mode: ");
            PaymentMode = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine("OrderId: " + OrderId);
            Console.WriteLine("OrderDate: " + OrderDate);
            Console.WriteLine("Quantity: " + Qty);
            Console.WriteLine("Payment Mode: " + PaymentMode);
        }
    }

    class Chair : Furniture
    {
        public string ChairType;
        public string Purpose;
        public double Rate;

        public override void GetData()
        {
            base.GetData();

            Console.Write("Chair Type (Wood/Steel/Plastic): ");
            ChairType = Console.ReadLine();

            Console.Write("Purpose (Home/Office): ");
            Purpose = Console.ReadLine();

            Console.Write("Rate: ");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            base.ShowData();

            Console.WriteLine("Chair Type: " + ChairType);
            Console.WriteLine("Purpose: " + Purpose);
            Console.WriteLine("Total Amount: " + TotalAmt);
        }
    }

    class Cot : Furniture
    {
        public string CotType;
        public string Capacity;
        public double Rate;

        public override void GetData()
        {
            base.GetData();

            Console.Write("Cot Type (Wood/Steel): ");
            CotType = Console.ReadLine();

            Console.Write("Capacity (Single/Double): ");
            Capacity = Console.ReadLine();

            Console.Write("Rate: ");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            base.ShowData();

            Console.WriteLine("Cot Type: " + CotType);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Total Amount: " + TotalAmt);
        }
    }


    // =========================
    // MAIN PROGRAM
    // =========================

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Assignment 1: Healthcare -----");

            Doctor d = new Doctor { StaffId = 1, Name = "Ravi", BaseSalary = 50000, ConsultationFee = 20000 };
            Nurse n = new Nurse { StaffId = 2, Name = "Anitha", BaseSalary = 30000, NightShiftAllowance = 5000 };
            LabTechnician l = new LabTechnician { StaffId = 3, Name = "Kiran", BaseSalary = 25000, EquipmentAllowance = 3000 };

            Console.WriteLine("Doctor Salary: " + d.CalculateSalary());
            Console.WriteLine("Nurse Salary: " + n.CalculateSalary());
            Console.WriteLine("Lab Tech Salary: " + l.CalculateSalary());


            Console.WriteLine("\n----- Assignment 2: Banking -----");

            Account acc = new SavingsAccount();
            acc.CalculateInterest();


            Console.WriteLine("\n----- Assignment 3: E-Commerce -----");

            List<Order> orders = new List<Order>()
            {
                new StandardOrder(),
                new ExpressOrder(),
                new InternationalOrder()
            };

            foreach (Order o in orders)
            {
                Console.WriteLine("Shipping Cost: " + o.CalculateShippingCost());
            }


            Console.WriteLine("\n----- Assignment 4: Vehicle -----");

            ElectricCar ec = new ElectricCar();
            ec.VehicleNumber = "EV123";
            ec.Brand = "Tesla";
            ec.StartVehicle();


            Console.WriteLine("\n----- Assignment 5: Education -----");

            Student[] students =
            {
                new SchoolStudent { Name="Aman", Marks=45 },
                new CollegeStudent { Name="Priya", Marks=55 },
                new OnlineStudent { Name="Rahul", Marks=58 }
            };

            foreach (Student s in students)
            {
                s.CalculateGrade();
            }


            Console.WriteLine("\n----- Assignment 6: Furniture -----");

            Chair chair = new Chair();
            chair.GetData();
            chair.ShowData();
        }
    }
}