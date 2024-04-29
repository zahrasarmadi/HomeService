using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class ExpertAddressConfiguration : IEntityTypeConfiguration<ExpertAddress>
{
    public void Configure(EntityTypeBuilder<ExpertAddress> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Expert)
            .WithOne(e => e.Address)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.City)
            .WithMany(c => c.ExpertAddress)
            .OnDelete(DeleteBehavior.NoAction);
    }
}