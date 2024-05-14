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
       

        builder.HasData
            (
            new Service { Id = 1, Name = "سرویس عادی نظافت", Price = 700000, ServiceSubCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new Service { Id = 2, Name = "سرویس لوکسن نظافت", Price = 850000, ServiceSubCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new Service { Id = 3, Name = "سرویس ویژه نظافت", Price = 1000000, ServiceSubCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new Service { Id = 4, Name = "تعمیر و سرویس کولر آبی", Price = 200000, ServiceSubCategoryId = 4, CreatedAt = DateTime.Now, IsDeleted = false }
            );
    }
}