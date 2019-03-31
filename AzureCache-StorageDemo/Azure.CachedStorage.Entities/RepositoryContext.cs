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
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=BW-DESKTOP\\SQLEXPRESS2014; database=exp1;Trusted_Connection=True;");
        }
    }
}
