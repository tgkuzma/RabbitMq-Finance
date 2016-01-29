﻿using System.Data.Entity;
using Models;

namespace Data
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Customers.Add(new Customer
            {
                BillingAddress = new Address
                {
                    City = "Phoenix",
                    State = "AZ",
                    Street = "236 W. Berridge Ln.",
                    ZipCode = "85013"
                },
                FirstName = "Trenton",
                LastName = "Kuzma",
                MasterId = 1

            });

            context.SaveChanges();
        }
    }
}