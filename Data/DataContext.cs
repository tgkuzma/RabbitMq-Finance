﻿using System.Data.Entity;
using Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("FinanceDbContext")
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
