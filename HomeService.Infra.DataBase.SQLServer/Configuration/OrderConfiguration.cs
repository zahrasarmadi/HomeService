using Azure.Core;
using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Expert)
            .WithMany(c => c.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Service)
            .WithMany(c => c.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(o=>o.Suggestions)
            .WithOne(s=>s.Order)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(o=>o.Images)
            .WithOne(i=>i.Order)
            .OnDelete(DeleteBehavior.NoAction);
    }
}