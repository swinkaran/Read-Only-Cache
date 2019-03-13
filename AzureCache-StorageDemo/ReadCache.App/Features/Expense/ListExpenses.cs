using Azure.CachedStorage.Entities;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReadCache.App.Features.Expense
{
    public class ListExpenses
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

        public class ListExpensesValidator { }

        public class MappingProfile {
            public MappingProfile()
            {
                //CreateMap<DataModel.Models.User, Result>(MemberList.Source);
            }
        }

        public class ListExpensesHandler : IRequestHandler<Query, Result>
        {
            public ListExpensesHandler()
            {

            }

            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {

                //                IList<Azure.CachedStorage.Entities.Models.Expense> expenses;
                //                //var results =new Result();

                //                RepositoryContext rep = new RepositoryContext();

                //                foreach (Azure.CachedStorage.Entities.Models.Expense exp in rep.Expenses)
                //                {
                ////                    results.Add(new Result { ExpenseName = exp.Description, Created = exp.Date, ExpenseId = exp.Id.ToString() });
                //                }

                //                //var result = new Result { Id = new Guid(), ExpenseName = "Testing food cost" };
                //                var result = new Result { Id = new Guid() };
                //                return result;

                throw new NotImplementedException();
            }
        }
    }
}
