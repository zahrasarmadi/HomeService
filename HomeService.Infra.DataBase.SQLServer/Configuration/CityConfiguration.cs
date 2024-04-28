using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.CustomerAddress)
            .WithOne(c => c.City)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.ExpertAddress)
            .WithOne(c => c.City)
            .OnDelete(DeleteBehavior.NoAction); 
    }
}