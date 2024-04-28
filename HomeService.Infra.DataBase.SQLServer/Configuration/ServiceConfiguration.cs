using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasOne(s => s.ServiceSubCategory)
            .WithMany(s => s.Services)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(s => s.Experts)
            .WithMany(e => e.Services);
           // .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(s=>s.Orders)
            .WithOne(o=>o.Service)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s=>s.Image)
            .WithOne(i=>i.Service)
            .OnDelete(DeleteBehavior.NoAction);
    }
}