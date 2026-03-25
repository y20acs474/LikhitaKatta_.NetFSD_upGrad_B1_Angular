using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    
    // ASSIGNMENT 1 VARIABLES
    
    static int[] partialSums = new int[5];

    static void Main(string[] args)
    {
        Console.WriteLine("===== ASSIGNMENT 1: PARALLEL NUMBER PROCESSING =====\n");

        RunAssignment1();

        Console.WriteLine("\n===== ASSIGNMENT 2: BANK ACCOUNT (WITHOUT LOCK) =====\n");

        RunAssignment2_WithoutLock();

        Console.WriteLine("\n===== ASSIGNMENT 2: BANK ACCOUNT (WITH LOCK) =====\n");

        RunAssignment2_WithLock();

        Console.ReadLine();
    }

    
    // ASSIGNMENT 1: MULTITHREADING NUMBER PROCESS
    
    static void RunAssignment1()
    {
        List<int> numbers = new List<int>();

        for (int i = 1; i <= 50; i++)
        {
            numbers.Add(i);
        }

        Thread[] threads = new Thread[5];

        int partSize = 10;

        for (int i = 0; i < 5; i++)
        {
            int start = i * partSize;
            int end = start + partSize;

            int threadIndex = i;

            threads[i] = new Thread(() => ProcessNumbers(numbers, start, end, threadIndex));
            threads[i].Start();
        }

        // Wait for all threads
        for (int i = 0; i < 5; i++)
        {
            threads[i].Join();
        }

        // Final sum
        int finalSum = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Thread {i + 1} Sum: {partialSums[i]}");
            finalSum += partialSums[i];
        }

        Console.WriteLine($"\nFinal Sum: {finalSum}");
    }

    static void ProcessNumbers(List<int> numbers, int start, int end, int index)
    {
        int sum = 0;

        Console.WriteLine($"\nThread {index + 1} processing:");

        for (int i = start; i < end; i++)
        {
            Console.Write(numbers[i] + " ");
            sum += numbers[i];
        }

        Console.WriteLine();

        partialSums[index] = sum;
    }

    
    // ASSIGNMENT 2: WITHOUT SYNCHRONIZATION
    
    static void RunAssignment2_WithoutLock()
    {
        BankAccount account = new BankAccount(100);

        Thread t1 = new Thread(() => account.WithdrawWithoutLock(70));
        Thread t2 = new Thread(() => account.WithdrawWithoutLock(50));
        Thread t3 = new Thread(() => account.WithdrawWithoutLock(30));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Final Balance (No Lock): {account.Balance}");
    }

    
    // ASSIGNMENT 2: WITH SYNCHRONIZATION (LOCK)
   
    static void RunAssignment2_WithLock()
    {
        BankAccount account = new BankAccount(100);

        Thread t1 = new Thread(() => account.WithdrawWithLock(70));
        Thread t2 = new Thread(() => account.WithdrawWithLock(50));
        Thread t3 = new Thread(() => account.WithdrawWithLock(30));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Final Balance (With Lock): {account.Balance}");
    }
}

// ============================================
// BANK ACCOUNT CLASS
// ============================================
class BankAccount
{
    public int Balance;
    private object lockObj = new object();

    public BankAccount(int balance)
    {
        Balance = balance;
    }

    // Without lock (Wrong behavior)
    public void WithdrawWithoutLock(int amount)
    {
        if (Balance >= amount)
        {
            Console.WriteLine($"Withdrawing {amount}...");
            Thread.Sleep(500); // simulate delay
            Balance -= amount;
            Console.WriteLine($"Remaining Balance: {Balance}");
        }
        else
        {
            Console.WriteLine($"Cannot withdraw {amount}, insufficient balance!");
        }
    }

    // With lock (Correct behavior)
    public void WithdrawWithLock(int amount)
    {
        lock (lockObj)
        {
            if (Balance >= amount)
            {
                Console.WriteLine($"Withdrawing {amount}...");
                Thread.Sleep(500);
                Balance -= amount;
                Console.WriteLine($"Remaining Balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"Cannot withdraw {amount}, insufficient balance!");
            }
        }
    }
}