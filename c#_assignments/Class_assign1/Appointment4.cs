using System;

namespace Class_assign1
{
    class Appointment4
    {
        public int AppointmentId;
        public string PatientName;
        public string DoctorName;
        public DateTime AppointmentDate;

        public Appointment4()
        {
            DoctorName = "General Physician";
            AppointmentDate = DateTime.Today;
        }
    }

    class AppointmentAssignment
    {
        static void Main(string[] args)
        {
            Appointment4 a = new Appointment4();

            a.AppointmentId = 1;
            a.PatientName = "Ravi";

            Console.WriteLine("Doctor: " + a.DoctorName);
            Console.WriteLine("Date: " + a.AppointmentDate);
        }
    }
}