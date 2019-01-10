//using Entities.ExtendedModels;
using Azure.CachedStorage.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.CachedStorage.Entities.DataWriter.Interfaces
{
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(Guid ExpenseId);
        //Task<ExpenseExtended> GetExpenseWithDetailsAsync(Guid ExpenseId);
        Task CreateExpenseAsync(Expense Expense);
        Task UpdateExpenseAsync(Expense dbExpense, Expense Expense);
        Task DeleteExpenseAsync(Expense Expense);
    }

}
