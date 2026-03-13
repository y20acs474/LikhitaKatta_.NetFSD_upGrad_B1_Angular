using System;

namespace Class_assign1
{
    class Nurse7
    {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string Department { get; set; }
    }

    class NurseAssignment
    {
        static void Main(string[] args)
        {
            Nurse7 n = new Nurse7
            {
                NurseId = 1,
                NurseName = "Anita",
                Department = "ICU"
            };

            Console.WriteLine("Nurse Id: " + n.NurseId);
            Console.WriteLine("Name: " + n.NurseName);
            Console.WriteLine("Department: " + n.Department);
        }
    }
}