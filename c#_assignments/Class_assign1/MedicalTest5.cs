using System;

namespace Class_assign1
{
    class MedicalTest5
    {
        public int TestId;
        public string TestName;
        public double TestCost;

        public MedicalTest5(int id, string name, double cost)
        {
            TestId = id;
            TestName = name;
            TestCost = cost;
        }
    }

    class MedicalTestAssignment
    {
        static void Main(string[] args)
        {
            MedicalTest5 t1 = new MedicalTest5(1, "Blood Test", 500);
            MedicalTest5 t2 = new MedicalTest5(2, "X-Ray", 1000);

            Console.WriteLine(t1.TestName + " - " + t1.TestCost);
            Console.WriteLine(t2.TestName + " - " + t2.TestCost);
        }
    }
}