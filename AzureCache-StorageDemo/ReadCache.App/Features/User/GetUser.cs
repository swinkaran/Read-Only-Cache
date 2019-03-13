using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ReadCache.App.Features.User
{
    public class GetUser
    {
        public class Query:IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Created { get; set; }
        }

        public class GetUserValidator { }

        public class MappingProfile { }

        public class GetUserHandler : IRequestHandler<Query, Result>
        {
            public GetUserHandler() {

            }

            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}