using AutoMapper;
using Azure.CachedStorage.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public class MappingProfile:AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Azure.CachedStorage.Entities.Models.Expense, Result>(MemberList.Source);
            }
        }
        public class ShowExpenseHandler : IRequestHandler<Query, Result>
        {
            private readonly IMapper _mapper;

            public ShowExpenseHandler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                RepositoryContext rep = new RepositoryContext();

                var user = await rep.Profiles.FirstOrDefaultAsync(u => u.Id == request.Id);

                if (user is null)
                {
                    throw new ArgumentNullException($"{nameof(user)} was not found");
                }

                var result = _mapper.Map<DataModel.Models.User, Result>(user);

                return result;
            }
        }

    }
}
