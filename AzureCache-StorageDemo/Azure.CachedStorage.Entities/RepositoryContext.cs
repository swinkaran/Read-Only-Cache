using Azure.CachedStorage.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.CachedStorage.Entities
{
    public class RepositoryContext : DbContext
    {
   
        public DbSet<Expense> Expenses { get; set; }
        //public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=SRIKARAN\\SQLTEEHEE; database=exp1;Trusted_Connection=True;");
        }
    }
}
