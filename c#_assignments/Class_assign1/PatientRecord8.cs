using System;

namespace Class_assign1
{
    class PatientRecord8
    {
        public int PatientId;
        public string PatientName;
        public int Age;
        public string Disease;

        public static string HospitalName;

        public PatientRecord8(int id, string name, int age, string disease)
        {
            PatientId = id;
            PatientName = name;
            Age = age;
            Disease = disease;
        }

        public void DisplayPatientRecord()
        {
            Console.WriteLine("Hospital: " + HospitalName);
            Console.WriteLine("Patient Id: " + PatientId);
            Console.WriteLine("Name: " + PatientName);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Disease: " + Disease);
            Console.WriteLine();
        }
    }

    class PatientRecordAssignment
    {
        static void Main(string[] args)
        {
            PatientRecord8.HospitalName = "Apollo Hospital";

            PatientRecord8 p1 = new PatientRecord8(101, "Ravi", 40, "Fever");
            PatientRecord8 p2 = new PatientRecord8(102, "Sita", 35, "Cold");
            PatientRecord8 p3 = new PatientRecord8(103, "Ramesh", 50, "Diabetes");

            p1.DisplayPatientRecord();
            p2.DisplayPatientRecord();
            p3.DisplayPatientRecord();
        }
    }
}