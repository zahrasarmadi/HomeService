﻿using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(c => c.Orders)
            .WithOne( c => c.Customer)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.Comments)
            .WithOne(c => c.Customer)
            .OnDelete(DeleteBehavior.NoAction);

        //builder.HasOne(c => c.Address)
        //    .WithOne(c => c.Customer)
        //    .OnDelete(DeleteBehavior.NoAction);

        builder.HasData
            (
            new Customer
            {
                Id = 1,
                FirstName = "سحر",
                LastName = "محمودی",
                Gender = GenderEnum.Female,
                PhoneNumber = "09123669858",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                ApplicationUserId=3
            },
            new Customer
            {
                Id = 2,
                FirstName = "محمد",
                LastName = "اصغری",
                Gender = GenderEnum.Male,
                PhoneNumber = "09123623258",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                ApplicationUserId=5
            }
            );;
    }
}