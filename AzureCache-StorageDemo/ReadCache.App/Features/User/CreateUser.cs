using MediatR;
using System;
//using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Azure.CachedStorage.Entities;

namespace ReadCache.App.Features.User
{
    public class CreateUser
    {
        public class Command : IRequest<Result>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class CreateUserValidator// : AbstractValidator<Command>
        {
            public CreateUserValidator()
            {
                //    RuleFor(user => user.FirstName).NotEmpty();
                //    RuleFor(user => user.LastName).NotEmpty();
                //    RuleFor(user => user.Email).NotEmpty().EmailAddress();
                //    RuleFor(user => user.Password).NotEmpty().MinimumLength(6)
                //        .WithMessage($"{nameof(Command.Password)} needs to have a length of at least 6 characters.");
                //
            }
        }

        public class CreateUserHandler : IRequestHandler<Command, Result>
        {
            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                Azure.CachedStorage.Entities.Models.Profile profile = new Azure.CachedStorage.Entities.Models.Profile { FirstName = request.FirstName, LastName = request.LastName };

                using (RepositoryContext rep = new RepositoryContext())
                {
                    await rep.Profiles.AddAsync(profile);
                    await rep.SaveChangesAsync();
                }

                var result = new Result { Id = Guid.NewGuid() };
                return result;
            }
        }
        
    }
}
