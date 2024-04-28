using HomeService.Domain.Core.Entities;
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

        builder.HasMany(c => c.Addresses)
            .WithOne(c => c.Customer)
            .OnDelete(DeleteBehavior.NoAction);
    }
}