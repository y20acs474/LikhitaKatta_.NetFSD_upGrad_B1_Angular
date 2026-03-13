using System;

namespace Class_assign1
{
    class Hospital3
    {
        public static string HospitalName;
        public static string HospitalAddress;

        public string PatientName;
    }

    class HospitalAssignment
    {
        static void Main(string[] args)
        {
            Hospital3.HospitalName = "Apollo Hospital";
            Hospital3.HospitalAddress = "Hyderabad";

            Hospital3 p1 = new Hospital3();
            Hospital3 p2 = new Hospital3();
            Hospital3 p3 = new Hospital3();

            p1.PatientName = "Ravi";
            p2.PatientName = "Sita";
            p3.PatientName = "Ramesh";

            Console.WriteLine("Hospital: " + Hospital3.HospitalName);
            Console.WriteLine("Patient: " + p1.PatientName);
            Console.WriteLine("Patient: " + p2.PatientName);
            Console.WriteLine("Patient: " + p3.PatientName);
        }
    }
}