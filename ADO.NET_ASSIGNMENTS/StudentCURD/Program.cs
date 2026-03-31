using System;
using Microsoft.Data.SqlClient;

class StudentCRUD
{
    static string conStr = "Server=LAPTOP-SJP5TP37\\SQLEXPRESS;Database=MyDB;Integrated Security=True;Encrypt=False;";

    static void Main()
    {
        InsertStudent();
        GetStudents();
        UpdateStudent();
        DeleteStudent();
    }

    static void InsertStudent()
    {
        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        string query = "INSERT INTO Students (Name, Age, Grade) VALUES (@Name, @Age, @Grade)";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Name", "LIKHI");
        cmd.Parameters.AddWithValue("@Age", 22);
        cmd.Parameters.AddWithValue("@Grade", "A");

        cmd.ExecuteNonQuery();
        Console.WriteLine("Inserted!");
    }

    static void GetStudents()
    {
        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Grade"]}");
        }
    }

    static void UpdateStudent()
    {
        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        string query = "UPDATE Students SET Grade='A+' WHERE Id=1";
        new SqlCommand(query, con).ExecuteNonQuery();

        Console.WriteLine("Updated!");
    }

    static void DeleteStudent()
    {
        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        string query = "DELETE FROM Students WHERE Id=1";
        new SqlCommand(query, con).ExecuteNonQuery();

        Console.WriteLine("Deleted!");
    }
}