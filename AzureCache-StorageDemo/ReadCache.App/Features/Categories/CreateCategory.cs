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
    public class CreateCategory
    {
        public class Command : IRequest<Result>
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Result
        {
            public long Id { get; set; }
        }

        public class CreateCategoryValidator { }

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Azure.CachedStorage.Entities.Models.ExpenseCategory, Result>(MemberList.Source);
            }
        }

        public class CreateCategoryHandler : IRequestHandler<Command, Result>
        {
            private readonly RepositoryContext rep;
            private readonly IMapper _mapper;

            public CreateCategoryHandler(IMapper mapper)
            {
                rep = new RepositoryContext();
                _mapper = mapper;
            }

            public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
            {
                Azure.CachedStorage.Entities.Models.Expense expense;
                using (RepositoryContext rep = new RepositoryContext())
                {
                    await rep.ExpenseCategories.AddAsync(new Azure.CachedStorage.Entities.Models.ExpenseCategory { Name = command.Name, Descrption = command.Description });
                    await rep.SaveChangesAsync();
                }

                var result = new Result { Id = 111 };
                return result;
            }
        }
    }
}
