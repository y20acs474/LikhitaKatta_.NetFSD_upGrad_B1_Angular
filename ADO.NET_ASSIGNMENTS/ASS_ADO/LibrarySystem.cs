using System;
using Microsoft.Data.SqlClient;

class LibrarySystem
{
    static string conStr = "Server=.\\SQLEXPRESS;Database=MyDB;Integrated Security=True;Encrypt=False;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== LIBRARY MENU =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Search Book");
            Console.WriteLine("6. Exit");

            Console.Write("Enter choice: ");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1: AddBook(); break;
                case 2: ViewBooks(); break;
                case 3: UpdateBook(); break;
                case 4: DeleteBook(); break;
                case 5: SearchBook(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }


    static void AddBook()
    {
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("AddBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Price", price);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Added Successfully");
        }
    }


    static void ViewBooks()
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("GetBooks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n--- Book List ---");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["BookId"]} | {reader["Title"]} | {reader["Author"]} | {reader["Price"]}");
            }
        }
    }


    static void UpdateBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter New Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter New Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter New Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("UpdateBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookId", id);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Price", price);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Updated Successfully");
        }
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE BookId = @BookId", con);

            cmd.Parameters.AddWithValue("@BookId", id);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Deleted Successfully");
        }
    }


    static void SearchBook()
    {
        Console.Write("Enter Title to Search: ");
        string title = Console.ReadLine();

        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("SearchBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", title);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n--- Search Results ---");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["BookId"]} | {reader["Title"]} | {reader["Author"]} | {reader["Price"]}");
            }
        }
    }
}