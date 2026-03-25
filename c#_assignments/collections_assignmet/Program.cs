using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== COLLECTIONS MENU =====");
            Console.WriteLine("1. Product List");
            Console.WriteLine("2. Student Dictionary");
            Console.WriteLine("3. Email HashSet");
            Console.WriteLine("4. Stack (Undo)");
            Console.WriteLine("5. Queue (Patients)");
            Console.WriteLine("6. LinkedList (Playlist)");
            Console.WriteLine("0. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: ProductList(); break;
                case 2: StudentDictionary(); break;
                case 3: EmailHashSet(); break;
                case 4: StackDemo(); break;
                case 5: QueueDemo(); break;
                case 6: LinkedListDemo(); break;
                case 0: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    // 1. LIST
    static void ProductList()
    {
        List<Product> products = new List<Product>()
        {
            new Product{Id=1, Name="Laptop", Price=50000, Category="Electronics"},
            new Product{Id=2, Name="Shoes", Price=1500, Category="Fashion"},
            new Product{Id=3, Name="Watch", Price=3000, Category="Accessories"}
        };

        Console.WriteLine("\nAll Products:");
        products.ForEach(p => Console.WriteLine($"{p.Name} - {p.Price}"));

        var filtered = products.Where(p => p.Price > 1000);
        Console.WriteLine("\nPrice > 1000:");
        foreach (var p in filtered)
            Console.WriteLine(p.Name);
    }

    // 2. DICTIONARY
    static void StudentDictionary()
    {
        Dictionary<int, Student> students = new Dictionary<int, Student>()
        {
            {1, new Student{Id=1, Name="Princess Likhita", Marks=85}},
            {2, new Student{Id=2, Name="Rahul", Marks=70}}
        };

        Console.WriteLine("\nStudent ID 1: " + students[1].Name);

        if (students.ContainsKey(2))
            Console.WriteLine("Student exists");

        students[2].Marks = 75;

        foreach (var s in students.Values)
            Console.WriteLine($"{s.Name} - {s.Marks}");
    }

    // 3. HASHSET
    static void EmailHashSet()
    {
        HashSet<string> emails = new HashSet<string>()
        {
            "a@gmail.com", "b@gmail.com", "a@gmail.com"
        };

        Console.WriteLine("\nUnique Emails:");
        foreach (var e in emails)
            Console.WriteLine(e);

        Console.WriteLine("Exists? " + emails.Contains("a@gmail.com"));
    }

    // 4. STACK
    static void StackDemo()
    {
        Stack<string> actions = new Stack<string>();

        actions.Push("Type A");
        actions.Push("Delete B");

        Console.WriteLine("Undo: " + actions.Pop());
        Console.WriteLine("Top: " + actions.Peek());
    }

    // 5. QUEUE
    static void QueueDemo()
    {
        Queue<Patient> queue = new Queue<Patient>();

        queue.Enqueue(new Patient { Id = 1, Name = "Ravi", Disease = "Fever" });
        queue.Enqueue(new Patient { Id = 2, Name = "Anu", Disease = "Cold" });

        queue.Dequeue();

        Console.WriteLine("Next Patient: " + queue.Peek().Name);
    }

    // 6. LINKED LIST
    static void LinkedListDemo()
    {
        LinkedList<Song> playlist = new LinkedList<Song>();

        var s1 = new Song { Id = 1, Title = "Song1", Artist = "A" };
        var s2 = new Song { Id = 2, Title = "Song2", Artist = "B" };

        playlist.AddFirst(s1);
        playlist.AddLast(s2);

        Console.WriteLine("\nPlaylist:");
        foreach (var s in playlist)
            Console.WriteLine(s.Title);
    }
}