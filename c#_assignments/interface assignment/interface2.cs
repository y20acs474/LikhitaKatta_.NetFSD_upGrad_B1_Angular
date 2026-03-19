using System;


public interface IYearlySales
{
    int YearlySales(int monthlySales);
}


public abstract class Sales
{
    protected int dailySales = 400;

    public int GetDailySales()
    {
        return dailySales;
    }

    public abstract int MonthlySales(int dailySales);
}


public class SalesReport : Sales, IYearlySales
{
   
    public override int MonthlySales(int dailySales)
    {
        return dailySales * 30;
    }

 
    public int YearlySales(int monthlySales)
    {
        return monthlySales * 12;
    }
}


class task2
{
    static void Main()
    {
        SalesReport report = new SalesReport();

        int daily = report.GetDailySales();
        int monthly = report.MonthlySales(daily);
        int yearly = report.YearlySales(monthly);

        Console.WriteLine("Daily sales: Rs." + daily);
        Console.WriteLine("Monthly sales: Rs." + monthly);
        Console.WriteLine("Annual sales: Rs." + yearly);
    }
}