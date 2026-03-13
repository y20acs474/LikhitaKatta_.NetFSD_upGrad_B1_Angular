using System;

namespace Class_assign1
{
    class Billing6
    {
        public string PatientName;
        public double ConsultationFee;
        public double TestCharges;

        public double CalculateTotalBill()
        {
            return ConsultationFee + TestCharges;
        }
    }

    class BillingAssignment
    {
        static void Main(string[] args)
        {
            Billing6 b = new Billing6();

            b.PatientName = "Ramesh";
            b.ConsultationFee = 1000;
            b.TestCharges = 500;

            double total = b.CalculateTotalBill();

            Console.WriteLine("Patient Name: " + b.PatientName);
            Console.WriteLine("Total Bill: " + total);
        }
    }
}