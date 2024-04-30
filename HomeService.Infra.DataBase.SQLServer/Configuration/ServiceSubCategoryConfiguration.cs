using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class ServiceSubCategoryConfiguration : IEntityTypeConfiguration<ServiceSubCategory>
{
    public void Configure(EntityTypeBuilder<ServiceSubCategory> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.Services)
             .WithOne(s => s.ServiceSubCategory)
             .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.ServiceCategory)
            .WithMany(s => s.ServiceSubCategories)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.Image)
            .WithOne(i => i.ServiceSubCategory)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData
            (
            new ServiceSubCategory { Id = 1, Name = "نظافت و پذیرایی", ServiceCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new ServiceSubCategory { Id = 2, Name = "شستشو", ServiceCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
            new ServiceSubCategory { Id = 3, Name = "کارواش و دیتیلینگ", ServiceCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false }
            );
    }
}