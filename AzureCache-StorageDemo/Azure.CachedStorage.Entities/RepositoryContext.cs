using Azure.CachedStorage.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.CachedStorage.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        //public DbSet<Account> Accounts { get; set; }
    }
}
