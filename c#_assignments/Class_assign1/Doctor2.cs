using System;

namespace Class_assign1
{
    class Doctor2
    {
        public int DoctorId;
        public string DoctorName;
        public string Specialization;
        public double ConsultationFee;
    }

    class DoctorAssignment
    {
        static void Main(string[] args)
        {
            Doctor2 d1 = new Doctor2();
            Doctor2 d2 = new Doctor2();

            d1.DoctorId = 1;
            d1.DoctorName = "Dr Sharma";
            d1.Specialization = "Cardiologist";
            d1.ConsultationFee = 800;

            d2.DoctorId = 2;
            d2.DoctorName = "Dr Mehta";
            d2.Specialization = "Dermatologist";
            d2.ConsultationFee = 500;

            Console.WriteLine("Doctor 1: " + d1.DoctorName);
            Console.WriteLine("Doctor 2: " + d2.DoctorName);
        }
    }
}