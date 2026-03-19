using System;

// Custom Exception
public class TicketLimitException : Exception
{
    public TicketLimitException(string message) : base(message)
    {
    }
}

class MovieBooking
{
    static int availableTickets = 15;

    public static void BookTickets(int tickets)
    {
        if (tickets > availableTickets)
        {
            throw new TicketLimitException("Not enough tickets available!");
        }
        else
        {
            availableTickets -= tickets;
            Console.WriteLine("Tickets booked successfully: " + tickets);
            Console.WriteLine("Remaining tickets: " + availableTickets);
        }
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Do you want to book tickets? (yes/no)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "yes")
            {
                Console.WriteLine("Enter number of tickets:");
                int tickets = Convert.ToInt32(Console.ReadLine());

                BookTickets(tickets);
            }
            else
            {
                Console.WriteLine("Thank you!");
            }
        }
        catch (TicketLimitException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input!");
        }
    }
}