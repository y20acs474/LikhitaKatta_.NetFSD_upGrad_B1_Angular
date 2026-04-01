using Bank_Demo.DataBase;
using Bank_Demo.Entities;

namespace Bank_Demo.Repositories
{
    public class AccountRepository
    {
        private readonly AppDBContext _context;

        public AccountRepository()
        {
            _context = new AppDBContext();
        }

        // GET ALL
        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        // GET BY ID
        public Account GetAccount(int id)
        {
            return _context.Accounts.Find(id);
        }

        // ADD
        public void AddAccount(Account acc)
        {
            _context.Accounts.Add(acc);
            _context.SaveChanges();
        }

        // UPDATE
        public void UpdateAccount(Account acc)
        {
            _context.Accounts.Update(acc);
            _context.SaveChanges();
        }

        // DELETE
        public void DeleteAccount(int id)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
            if (acc != null)
            {
                _context.Accounts.Remove(acc);
                _context.SaveChanges();
            }
        }
    }
}