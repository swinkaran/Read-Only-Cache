using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.CachedStorage.Entities;
using MediatR;
namespace ReadCache.App.Features.Expense
{
    public class CreateExpense
    {
        public class Command : IRequest<Result>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            //public float Amount { get; set; }
            //public DateTime SpentOn { get; set; }
        }

        public class Result
        {
            public long Id { get; set; }
        }

        public class CreateExpenseHandler : IRequestHandler<Command, Result>
        {
            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                // Add a new expense to the database via data context
                // Temporaryly access the data from here, we can find a better design once the things are working
                //Result result;
                Azure.CachedStorage.Entities.Models.Expense expense;
                using (RepositoryContext rep = new RepositoryContext())
                {
                    await rep.Expenses.AddAsync(new Azure.CachedStorage.Entities.Models.Expense { Name = request.Name, Description = request.Description });
                    await rep.SaveChangesAsync();
                }

                var result = new Result { Id = 111 };
                return result;
                //throw new NotImplementedException();
            }
        }
    } 
}
