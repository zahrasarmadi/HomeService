using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

internal class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
{
    public void Configure(EntityTypeBuilder<ServiceCategory> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.ServiceSubCategories)
            .WithOne(s => s.ServiceCategory)
            .OnDelete(DeleteBehavior.NoAction);
;

        builder.HasData
            (
            new ServiceCategory() { Id = 1, Name = "تمیزکاری", CreatedAt = DateTime.Now, IsDeleted = false,Image= "\\assets\\img\\category\\broom-solid.svg" },
            new ServiceCategory() { Id = 2, Name = "ساختمان",CreatedAt=DateTime.Now,IsDeleted=false, Image = "\\assets\\img\\category\\building-solid.svg" },
            new ServiceCategory() { Id = 3, Name = "تعمیرات اشیاء", CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\category\\screwdriver-wrench-solid.svg" },
            new ServiceCategory() { Id = 4, Name = "اسباب‌کشی و حمل بار", CreatedAt = DateTime.Now, IsDeleted = false , Image = "\\assets\\img\\category\\truck-moving-solid.svg" },
            new ServiceCategory() { Id = 5, Name = "خودرو", CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\category\\car-solid.svg" },
            new ServiceCategory() { Id = 6, Name = "سازمان‌ها و مجتمع‌ها", CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\category\\building-flag-solid.svg" },
            new ServiceCategory() { Id = 7, Name = "سلامت و زیبایی", CreatedAt = DateTime.Now, IsDeleted = false , Image = "\\assets\\img\\category\\suitcase-medical-solid.svg" }
            //new ServiceCategory() { Id = 8, Name = "کشکول", CreatedAt = DateTime.Now, IsDeleted = false }
            );
    }
}