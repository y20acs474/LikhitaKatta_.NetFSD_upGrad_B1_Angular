using System;


public class CheckBalanceException : Exception
{
    public CheckBalanceException(string message) : base(message)
    {
    }
}


public class BankAccount
{
    public int AccountNumber;
    public string Name;
    public static double balance;
    public char transactionType;
    public double amount;

    public BankAccount(int accNo, string name, double bal)
    {
        AccountNumber = accNo;
        Name = name;
        balance = bal;
    }

    public void Transaction(char type, double amt)
    {
        transactionType = type;
        amount = amt;

        if (type == 'd') 
        {
            balance += amt;
            Console.WriteLine("Deposited: " + amt);
        }
        else if (type == 'c') 
        {
            if (balance - amt < 500)
            {
                throw new CheckBalanceException("Insufficient balance! Minimum balance should be 500.");
            }
            balance -= amt;
            Console.WriteLine("Withdrawn: " + amt);
        }

        Console.WriteLine("Current Balance: " + balance);
    }
}


class Program
{
    static void Main()
    {
        try
        {
            BankAccount acc = new BankAccount(101, "John", 1000);

            acc.Transaction('d', 500);
            acc.Transaction('c', 1200);
        }
        catch (CheckBalanceException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}
