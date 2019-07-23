using Azure.CachedStorage.Entities;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReadCache.App.Features.Expense
{
    public class ListExpenses
    {
        public class Query : IRequest<IList<Result>>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string ExpenseId { get; set; }
            public string Title { get; set; }
            public float Amount { get; set; }
            public DateTime BilledDate { get; set; }
            public string Description { get; set; }

        }

        public class ListExpensesValidator { }

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Azure.CachedStorage.Entities.Models.Expense, Result>(MemberList.Source);
            }
        }

        public class ListExpensesHandler : IRequestHandler<Query, IList<Result>>
        {
            private readonly RepositoryContext rep;
            private readonly IMapper _mapper;
            
            public ListExpensesHandler(IMapper mapper)
            {
                rep = new RepositoryContext();
                _mapper = mapper;
            }

            public async Task<IList<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                IList<Azure.CachedStorage.Entities.Models.Expense> expenses = await rep.Expenses.Include(e => e.ExpenseCategory).ToAsyncEnumerable().ToList();
                var results = _mapper.Map<IList<Azure.CachedStorage.Entities.Models.Expense>, IList<Result>>(expenses);
                return results;
            }
        }
    }
}
