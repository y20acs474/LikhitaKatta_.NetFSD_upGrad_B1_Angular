using System;
using Microsoft.Data.SqlClient;

class EmployeeCRUD
{
    static string conStr = "Server=.\\SQLEXPRESS;Database=MyDB;Integrated Security=True;Encrypt=False;";

    static void Main()
    {
        InsertEmployee("Teja", 50000, "IT");
        GetEmployeesByDepartment("IT");
        UpdateSalary(1, 60000);
        DeleteEmployee(2);

        Console.ReadLine();
    }
    static void InsertEmployee(string name, decimal salary, string dept)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {

            SqlCommand cmd = new SqlCommand("InsertEmployee", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();
            cmd.ExecuteNonQuery(); 
            Console.WriteLine("Employee Inserted");
        }
    }

    static void GetEmployeesByDepartment(string dept)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("GetEmployeesByDepartment", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

  
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["EmpId"]}, Name: {reader["Name"]}, Salary: {reader["Salary"]}");
            }
        }
    }


    static void UpdateSalary(int empId, decimal salary)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("UpdateEmployeeSalary", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", empId);
            cmd.Parameters.AddWithValue("@Salary", salary);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Salary Updated");
        }
    }


    static void DeleteEmployee(int empId)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
         
            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmpId = @EmpId", con);

            cmd.Parameters.AddWithValue("@EmpId", empId);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Employee Deleted");
        }
    }
}