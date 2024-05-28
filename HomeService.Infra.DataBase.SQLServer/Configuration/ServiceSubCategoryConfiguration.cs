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


        builder.HasData
            (
            new ServiceSubCategory { Id = 1, Name = "نظافت و پذیرایی", ServiceCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamiz-kari\\nezafat-pazirayi.webp" },
            new ServiceSubCategory { Id = 2, Name = "شستشو", ServiceCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamiz-kari\\shosteshu.webp" },
            new ServiceSubCategory { Id = 3, Name = "کارواش و دیتیلینگ", ServiceCategoryId = 1, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamiz-kari\\carwash.webp" },
            new ServiceSubCategory { Id = 4, Name = "سرمایش و گرمایش", ServiceCategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamirat\\sarmayesh-garmayesh.webp" },
            new ServiceSubCategory { Id = 5, Name = "نصب وتعمیر لوازم خانگی", ServiceCategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamirat\\tamir-lavazem-khanegi.webp" },
            new ServiceSubCategory { Id = 7, Name = "خذمات کامپیوتری", ServiceCategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamirat\\khadamat-computer.webp" },
            new ServiceSubCategory { Id = 8, Name = "تعمیرات موبایل", ServiceCategoryId = 3, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\tamirat\\tamirat-mobile.webp" },
            new ServiceSubCategory { Id = 9, Name = "سرمایش و گرمایش", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\sarmayesh-garmayesh.webp" },
            new ServiceSubCategory { Id = 10, Name = "تعمیرا ساختمان", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\tamirat-sakhteman.webp" },
            new ServiceSubCategory { Id = 11, Name = "لوله کشی", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\lule-keshi.webp" },
            new ServiceSubCategory { Id = 12, Name = "طراحی و بازسازی ساختمان", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\tarahi-sakhtemen.webp" },
            new ServiceSubCategory { Id = 13, Name = "برق کاری", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\bargh-kari.webp" },
            new ServiceSubCategory { Id = 14, Name = "چوب و کابینت", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\chub-cabinet.webp" },
            new ServiceSubCategory { Id = 15, Name = "خدمات شیشه ای ساختمان", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\khadamat-shishei.webp" },
            new ServiceSubCategory { Id = 16, Name = "باغبانی و فضای سبز", ServiceCategoryId = 2, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\sakhtemen\\baghbani.webp" },
            new ServiceSubCategory { Id = 17, Name = "باربری و جا به جایی", ServiceCategoryId = 4, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\barbari.webp" },
            new ServiceSubCategory { Id = 18, Name = "خدمات و تعمیرات خودرو", ServiceCategoryId = 5, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\khodro\\khdamet-khodro.webp" },
            new ServiceSubCategory { Id = 19, Name = "کارواش و دیتیلینگ", ServiceCategoryId = 5, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\khodro\\carwash.webp" },
            new ServiceSubCategory { Id = 20, Name = "خدمات شرکتی", ServiceCategoryId = 6, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\khadamat-sherkati.webp" },
            new ServiceSubCategory { Id = 21, Name = "زیبایی بانوان", ServiceCategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-banovan.webp" },
            new ServiceSubCategory { Id = 22, Name = "پیرایش و زیبایی آقایان", ServiceCategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\salamat-zibayi\\zibayi-aghayan.webp" },
            new ServiceSubCategory { Id = 23, Name = "پزشکی و پرستاری", ServiceCategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\salamat-zibayi\\pezeshki.webp" },
            new ServiceSubCategory { Id = 24, Name = "حیوانات خانگی", ServiceCategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\salamat-zibayi\\pet.webp" },
            new ServiceSubCategory { Id = 25, Name = "تندرستی و ورزش", ServiceCategoryId = 7, CreatedAt = DateTime.Now, IsDeleted = false, Image = "\\assets\\img\\sub-category\\salamat-zibayi\\varzesh.webp" }
            //new ServiceSubCategory { Id = 26, Name = "خیاطی و تعمیرات لباس", ServiceCategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
            //new ServiceSubCategory { Id = 27, Name = "مجالس و رویداد‌ها", ServiceCategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
            //new ServiceSubCategory { Id = 28, Name = "آموزش", ServiceCategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
            //new ServiceSubCategory { Id = 29, Name = "همه‌فن حذیف", ServiceCategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
            //new ServiceSubCategory { Id = 30, Name = "خدمات فوری آیدو", ServiceCategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
            //new ServiceSubCategory { Id = 31, Name = "کودک", ServiceCategoryId = 8, CreatedAt = DateTime.Now, IsDeleted = false }
            );
    }
}