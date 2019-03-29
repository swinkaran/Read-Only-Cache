using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azure.CachedStorage.Entities;
using MediatR;

namespace ReadCache.App.Features.Categories
{
    public class GetCategory
    {
        public class Query : IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
        }

        public class GetCategoryValidator { }

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Azure.CachedStorage.Entities.Models.ExpenseCategory, Result>(MemberList.Source);
            }
        }

        public class GetCategoryHandler : IRequestHandler<Query, Result>
        {
            private readonly RepositoryContext rep;
            private readonly IMapper _mapper;

            public GetCategoryHandler(IMapper mapper)
            {
                rep = new RepositoryContext();
                _mapper = mapper;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
