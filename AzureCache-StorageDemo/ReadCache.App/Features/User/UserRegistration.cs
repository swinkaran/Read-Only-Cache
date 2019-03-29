using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azure.CachedStorage.Entities;
using MediatR;

namespace ReadCache.App.Features.User
{
    public class UserRegistration
    {
        public class Command : IRequest<Result>
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class Result
        {
            public long Id { get; set; }
        }

        public class UserRegistrationValidator { }

        public class MappingProfile : AutoMapper.Profile
        {
        }

        public class UserRegistrationHandler : IRequestHandler<Command, Result>
        {
            private readonly RepositoryContext rep;
            private readonly IMapper _mapper;

            public UserRegistrationHandler(IMapper mapper)
            {
                rep = new RepositoryContext();
                _mapper = mapper;
            }

            public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
            {
                Azure.CachedStorage.Entities.Models.Expense expense;
                using (RepositoryContext rep = new RepositoryContext())
                {
                    await rep.Profiles.AddAsync(new Azure.CachedStorage.Entities.Models.Profile { FirstName = command.Name, Email = command.Email });
                    await rep.SaveChangesAsync();
                }

                var result = new Result { Id = 1111 };
                return result;
            }
        }
    }
}