using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

internal class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
{
    public void Configure(EntityTypeBuilder<ServiceCategory> builder)
    {
        builder.HasKey(s=>s.Id);

        builder.HasMany(s => s.ServiceSubCategories)
            .WithOne(s => s.ServiceCategory)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.Image)
            .WithOne(i => i.ServiceCategory)
            .OnDelete(DeleteBehavior.NoAction);
    }
}