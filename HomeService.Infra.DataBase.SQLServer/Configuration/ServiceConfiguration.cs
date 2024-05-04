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

        builder.HasMany(s => s.Orders)
            .WithOne(o => o.Service)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.Image)
            .WithOne(i => i.Service)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData
            (
            new Service { Id = 1, Name = "سرویس عادی نظافت", Price = 700000, SubCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new Service { Id = 2, Name = "سرویس لوکسن نظافت", Price = 850000, SubCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new Service { Id = 3, Name = "سرویس ویژه نظافت", Price = 1000000, SubCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false}
            );
    }
}