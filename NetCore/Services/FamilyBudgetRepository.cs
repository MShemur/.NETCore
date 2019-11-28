using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.DbContexts;
using NetCore.Entities;

namespace NetCore.Services
{
    public class FamilyBudgetRepository : IDisposable, IFamilyBudgetRepository
    {

        private readonly FamilyBudgetContext _context;

        public FamilyBudgetRepository(FamilyBudgetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddIncomeTransaction(IncomeTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            transaction.Id = Guid.NewGuid();
            _context.IncomeTransactions.Add(transaction);
        }

        public void AddOutcomeTransaction(OutcomeTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            transaction.Id = Guid.NewGuid();
            _context.OutcomeTransactions.Add(transaction);
        }

        public void DeleteIncomeTransaction(IncomeTransaction transaction)
        {
            _context.IncomeTransactions.Remove(transaction);
        }

        public void DeleteOutcomeTransaction(OutcomeTransaction transaction)
        {
            _context.OutcomeTransactions.Remove(transaction);
        }

        public IncomeTransaction GetIncomeTransaction(Guid transactionId)
        {
            if (transactionId == Guid.Empty) throw new ArgumentNullException(nameof(transactionId));
            return _context.IncomeTransactions
                            .Include(s => s.Category)
                            .FirstOrDefault(c => c.Id == transactionId);

        }

        public OutcomeTransaction GetOutcomeTransaction(Guid transactionId)
        {
            if (transactionId == Guid.Empty) throw new ArgumentNullException(nameof(transactionId));

            return _context.OutcomeTransactions
                .Include(s => s.Category)
                .FirstOrDefault(c => c.Id == transactionId);
        }

        public IEnumerable<TransactionBase> GetIncomeTransactions()
        {
            return _context.IncomeTransactions
                .Include(s => s.Category)
                .ToList();
        }

        public IEnumerable<TransactionBase> GetOutcomeTransactions()
        {
            return _context.OutcomeTransactions
                .Include(s => s.Category)
                .ToList();
        }

        public bool IncomeTransactionExists(Guid transactionId)
        {
            if (transactionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            return _context.IncomeTransactions.Any(a => a.Id == transactionId);
        }

        public bool OutcomeTransactionExists(Guid transactionId)
        {
            if (transactionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            return _context.OutcomeTransactions.Any(a => a.Id == transactionId);
        }

        public bool IncomeCategoryExists(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.IncomeCategories.Any(a => a.Id == categoryId);
        }

        public bool OutcomeCategoryExists(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.OutcomeCategories.Any(a => a.Id == categoryId);
        }

        public IncomeCategory GetIncomeCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty) throw new ArgumentNullException(nameof(categoryId));
            return _context.IncomeCategories
                .FirstOrDefault(c => c.Id == categoryId);
        }

        public OutcomeCategory GetOutcomeCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty) throw new ArgumentNullException(nameof(categoryId));
            return _context.OutcomeCategories
                .FirstOrDefault(c => c.Id == categoryId);
        }

        public void AddIncomeCategory(IncomeCategory category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            category.Id = new Guid();

            _context.IncomeCategories.Add(category);
        }

        public void AddOutcomeCategory(OutcomeCategory category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            category.Id = new Guid();

            _context.OutcomeCategories.Add(category);
        }

        public void DeleteIncomeCategory(IncomeCategory category)
        {
            _context.IncomeCategories.Remove(category);
        }

        public void DeleteOutcomeCategory(OutcomeCategory category)
        {
            _context.OutcomeCategories.Remove(category);
        }

        public IEnumerable<CategoryBase> GetIncomeCategories()
        {
            return _context.IncomeCategories.ToList();
        }

        public IEnumerable<CategoryBase> GetOutcomeCategories()
        {
            return _context.OutcomeCategories.ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
