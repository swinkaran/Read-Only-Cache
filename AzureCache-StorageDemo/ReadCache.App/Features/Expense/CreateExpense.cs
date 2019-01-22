using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
namespace ReadCache.App.Features.Expense
{
    public class CreateExpense
    {
        public class Command : IRequest<Result>
        {
            public string ExpenseName { get; set; }
            public string Description { get; set; }
            public float Amount { get; set; }
            public DateTime SpentOn { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

    }
}
