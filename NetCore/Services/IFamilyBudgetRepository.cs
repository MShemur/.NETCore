using System;
using System.Collections.Generic;
using NetCore.Entities;

namespace NetCore.Services
{
    public interface IFamilyBudgetRepository
    {
        void AddIncomeTransaction(IncomeTransaction transaction);
        void AddOutcomeTransaction(OutcomeTransaction transaction);
        void DeleteIncomeTransaction(IncomeTransaction transaction);
        void DeleteOutcomeTransaction(OutcomeTransaction transaction);
        IncomeTransaction GetIncomeTransaction(Guid transactionId);
        OutcomeTransaction GetOutcomeTransaction(Guid transactionId);
        void AddIncomeCategory(IncomeCategory category);
        void AddOutcomeCategory(OutcomeCategory category);
        void DeleteIncomeCategory(IncomeCategory category);
        void DeleteOutcomeCategory(OutcomeCategory category);
        IEnumerable<CategoryBase> GetIncomeCategories();
        IEnumerable<CategoryBase> GetOutcomeCategories();
        bool Save();
        IEnumerable<TransactionBase> GetIncomeTransactions();
        IEnumerable<TransactionBase> GetOutcomeTransactions();
        bool IncomeTransactionExists(Guid transactionId);
        bool OutcomeTransactionExists(Guid transactionId);
        IncomeCategory GetIncomeCategory(Guid categoryId);
        OutcomeCategory GetOutcomeCategory(Guid categoryId);
        bool IncomeCategoryExists(Guid categoryId);
        bool OutcomeCategoryExists(Guid categoryId);
    }
}