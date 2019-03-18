using Azure.CachedStorage.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReadCache.App.Features.User
{
    public class DoesUserExist
    {
        public class Query : IRequest<bool>
        {
            public Guid UserId { get; }
            public string Email { get; }

            public Query(Guid userId)
            {
                UserId = userId;
            }
            public Query(string email)
            {
                Email = email;
            }
        }

        public class DoesUserExistHandler : IRequestHandler<Query, bool>
        {
            private readonly RepositoryContext context;

            public DoesUserExistHandler(RepositoryContext _context)
            {
                context = _context;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = from user in context.Profiles
                            where (!string.IsNullOrWhiteSpace(request.Email) && request.Email == user.Email) || (request.UserId != Guid.Empty && request.UserId == user.Id)
                            select user.Id;

                var result = await query.AnyAsync();

                return result;
            }
        }
    }
}
