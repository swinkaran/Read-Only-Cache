using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReadCache.App.Features.Expense
{
    public class ShowExpense
    {
        public class Query : IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string ExpenseId { get; set; }
            public string ExpenseName { get; set; }
            public DateTime Created { get; set; }
        }

        public class ShowExpenseValidator { }

        public class MappingProfile
        {
            public MappingProfile()
            {
                //CreateMap<DataModel.Models.User, Result>(MemberList.Source);
            }
        }
        public class ShowExpenseHandler : IRequestHandler<Query, Result>
        {
            public ShowExpenseHandler()
            {

            }

            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new Result { Id = new Guid() };
                return result;
            }
        }

    }
}
