using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Customer)
            .WithMany(c => c.Addresses)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Expert)
            .WithOne(c => c.Address)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.City)
            .WithMany(c => c.Address)
            .OnDelete(DeleteBehavior.NoAction);
    }
}