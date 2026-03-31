using System;
using Microsoft.Data.SqlClient;

class StudentCRUD
{
    static string conStr = "Server=.\\SQLEXPRESS;Database=MyDB;Integrated Security=True;Encrypt=False;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Insert Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertStudent();
                    break;
                case 2:
                    GetStudents();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    DeleteStudent();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    // 🔹 INSERT
    static void InsertStudent()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Grade: ");
        string grade = Console.ReadLine();

        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        string query = "INSERT INTO Students (Name, Age, Grade) VALUES (@Name, @Age, @Grade)";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Age", age);
        cmd.Parameters.AddWithValue("@Grade", grade);

        cmd.ExecuteNonQuery();
        Console.WriteLine("✅ Student Inserted!");
    }

    // 🔹 READ
    static void GetStudents()
    {
        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n--- Student List ---");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]} | {reader["Name"]} | {reader["Age"]} | {reader["Grade"]}");
        }
    }

    // 🔹 UPDATE
    static void UpdateStudent()
    {
        Console.Write("Enter Student Id to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter New Grade: ");
        string grade = Console.ReadLine();

        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        string query = "UPDATE Students SET Grade=@Grade WHERE Id=@Id";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Grade", grade);
        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("✅ Updated Successfully!");
        else
            Console.WriteLine("❌ Student not found!");
    }

    // 🔹 DELETE
    static void DeleteStudent()
    {
        Console.Write("Enter Student Id to delete: ");
        int id = int.Parse(Console.ReadLine());

        using SqlConnection con = new SqlConnection(conStr);
        con.Open();

        string query = "DELETE FROM Students WHERE Id=@Id";
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Id", id);

        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine(" Deleted Successfully!");
        else
            Console.WriteLine(" Student not found!");
    }
}