using System;

namespace Class_assign1
{
    class Patient1
    {
        public int PatientId;
        public string PatientName;
        public int Age;
        public string Disease;
    }

    class PatientAssignment
    {
        static void Main(string[] args)
        {
            Patient1 p = new Patient1();

            p.PatientId = 101;
            p.PatientName = "Ravi Kumar";
            p.Age = 45;
            p.Disease = "Diabetes";

            Console.WriteLine("Patient Id: " + p.PatientId);
            Console.WriteLine("Patient Name: " + p.PatientName);
            Console.WriteLine("Age: " + p.Age);
            Console.WriteLine("Disease: " + p.Disease);
        }
    }
}