using Bank_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Demo.DataBase
{
    public class AppDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SJP5TP37\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}