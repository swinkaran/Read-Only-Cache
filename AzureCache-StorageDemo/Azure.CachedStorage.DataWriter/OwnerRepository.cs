using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Entities.ExtendedModels;
using Entities.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Azure.CachedStorage.Entities;
using Azure.CachedStorage.Entities.Models;
using Azure.CachedStorage.Entities.DataWriter.Interfaces;

namespace Azure.CachedStorage.Entities.DataWriter
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            var Expenses = await FindAllAsync();
            return Expenses.OrderBy(x => x.Name);
        }

        public async Task<Expense> GetExpenseByIdAsync(Guid ExpenseId)
        {
            var Expense = await FindByConditionAync(o => o.Id.Equals(ExpenseId));
            return Expense.DefaultIfEmpty(new Expense())
                    .FirstOrDefault();
        }

        //public async Task<ExpenseExtended> GetExpenseWithDetailsAsync(Guid ExpenseId)
        //{
        //    var Expense = await GetExpenseByIdAsync(ExpenseId);

        //    return new ExpenseExtended(Expense)
        //    {
        //        Accounts = await RepositoryContext.Accounts
        //            .Where(a => a.ExpenseId == ExpenseId).ToListAsync()
        //    };
        //}

        public async Task CreateExpenseAsync(Expense Expense)
        {
            Expense.Id = Guid.NewGuid();
            Create(Expense);
            await SaveAsync();
        }

        public async Task UpdateExpenseAsync(Expense dbExpense, Expense Expense)
        {
            dbExpense.Map(Expense);
            Update(dbExpense);
            await SaveAsync();
        }

        public async Task DeleteExpenseAsync(Expense Expense)
        {
            Delete(Expense);
            await SaveAsync();
        }
    }

}
