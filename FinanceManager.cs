using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestWork
{
    public static class FinanceManager
    {
        private static ApplicationContext _db;

        public static void Initialize(ApplicationContext db)
        {
            _db = db;
        }

        public static void AddTransaction(int userId, decimal amount, string description, TransactionType type)
        {
            var transaction = new Transaction
            {
                UserId = userId,
                Amount = amount,
                Description = description,
                Type = type,
                Date = DateTime.Now
            };

            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }

        public static List<Transaction> GetTransactions(int userId)
        {
            return _db.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToList();
        }
        public static decimal GetTotalIncome(int userId)
        {
            return _db.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Income)
                .Sum(t => t.Amount);
        }

        public static decimal GetTotalExpense(int userId)
        {
            return _db.Transactions
                .Where(t => t.UserId == userId && t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);
        }

        public static List<Transaction> FilterTransactions(int userId, TransactionType? type, DateTime? startDate, DateTime? endDate)
        {
            var query = _db.Transactions.AsQueryable();

            if (userId != 0)
            {
                query = query.Where(t => t.UserId == userId);
            }

            if (type.HasValue)
            {
                query = query.Where(t => t.Type == type.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(t => t.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(t => t.Date <= endDate.Value);
            }

            return query.ToList();
        }

        public static void PrintFinancialReport(int userId)
        {
            var totalIncome = GetTotalIncome(userId);
            var totalExpense = GetTotalExpense(userId);
            var balance = totalIncome - totalExpense;

            Console.WriteLine($"Общий доход: {totalIncome}");
            Console.WriteLine($"Общий расход: {totalExpense}");
            Console.WriteLine($"Баланс: {balance}");
        }
    }


}
