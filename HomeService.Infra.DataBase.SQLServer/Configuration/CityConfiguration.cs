using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Address)
            .WithOne(c => c.City)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
           new City { Id = 1, Name = "آذربایجان شرقی", CreatedAt = DateTime.Now, },
           new City { Id = 2, Name = "آذربایجان غربی", CreatedAt = DateTime.Now },
           new City { Id = 3, Name = "اردبیل", CreatedAt = DateTime.Now },
           new City { Id = 4, Name = "اصفهان", CreatedAt = DateTime.Now },
           new City { Id = 5, Name = "البرز", CreatedAt = DateTime.Now },
           new City { Id = 6, Name = "ایلام", CreatedAt = DateTime.Now },
           new City { Id = 7, Name = "بوشهر", CreatedAt = DateTime.Now },
           new City { Id = 8, Name = "تهران", CreatedAt = DateTime.Now },
           new City { Id = 9, Name = "چهارمحال و بختیاری", CreatedAt = DateTime.Now },
           new City { Id = 10, Name = "خراسان جنوبی", CreatedAt = DateTime.Now },
           new City { Id = 11, Name = "خراسان رضوی", CreatedAt = DateTime.Now },
           new City { Id = 12, Name = "خراسان شمالی", CreatedAt = DateTime.Now },
           new City { Id = 13, Name = "خوزستان", CreatedAt = DateTime.Now },
           new City { Id = 14, Name = "زنجان", CreatedAt = DateTime.Now },
           new City { Id = 15, Name = "سمنان", CreatedAt = DateTime.Now },
           new City { Id = 16, Name = "سیستان و بلوچستان", CreatedAt = DateTime.Now },
           new City { Id = 17, Name = "فارس", CreatedAt = DateTime.Now },
           new City { Id = 18, Name = "قزوین", CreatedAt = DateTime.Now },
           new City { Id = 19, Name = "قم", CreatedAt = DateTime.Now },
           new City { Id = 20, Name = "کردستان", CreatedAt = DateTime.Now },
           new City { Id = 21, Name = "کرمان", CreatedAt = DateTime.Now },
           new City { Id = 22, Name = "کرمانشاه", CreatedAt = DateTime.Now },
           new City { Id = 23, Name = "کهگیلویه و بویراحمد", CreatedAt = DateTime.Now },
           new City { Id = 24, Name = "گلستان", CreatedAt = DateTime.Now },
           new City { Id = 25, Name = "گیلان", CreatedAt = DateTime.Now },
           new City { Id = 26, Name = "لرستان", CreatedAt = DateTime.Now },
           new City { Id = 27, Name = "مازندران", CreatedAt = DateTime.Now },
           new City { Id = 28, Name = "مرکزی", CreatedAt = DateTime.Now },
           new City { Id = 29, Name = "هرمزگان", CreatedAt = DateTime.Now },
           new City { Id = 30, Name = "همدان", CreatedAt = DateTime.Now },
           new City { Id = 31, Name = "یزد", CreatedAt = DateTime.Now }
           );
    }
}