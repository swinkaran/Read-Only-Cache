using AutoMapper;
using Azure.CachedStorage.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReadCache.App.Features.Categories
{
    public class GetCategories
    {
        public class Query : IRequest<IList<Result>>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
        }

        public class GetCategoriesValidator { }

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Azure.CachedStorage.Entities.Models.ExpenseCategory, Result>(MemberList.Source);
            }
        }

        public class GetCategoriesHandler : IRequestHandler<Query, IList<Result>>
        {
            private readonly RepositoryContext rep;
            private readonly IMapper _mapper;

            public GetCategoriesHandler(IMapper mapper)
            {
                rep = new RepositoryContext();
                _mapper = mapper;
            }

            public Task<IList<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
