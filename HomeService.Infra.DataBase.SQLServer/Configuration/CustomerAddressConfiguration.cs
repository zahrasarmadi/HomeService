﻿using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.HasOne(c => c.Customer)
            .WithMany(c => c.Addresses)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.City)
            .WithMany(c=>c.CustomerAddress)
            .OnDelete(DeleteBehavior.NoAction);
    }
}