using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(c => c.Orders)
            .WithOne( c => c.Customer)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.Comments)
            .WithOne(c => c.Customer)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.Addresses)
            .WithOne(c => c.Customer)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData
            (
            new Customer
            {
                Id = 1,
                FirstName = "سارا",
                LastName = "محمودی",
                Gender = GenderEnum.Female,
                PhoneNumber = "09192365988",
                BackUpPhoneNumber = "09123669858",
                BankCardNumber = "1234123412341234",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
            },
            new Customer
            {
                Id = 2,
                FirstName = "محمد",
                LastName = "اصغری",
                Gender = GenderEnum.Male,
                PhoneNumber = "09199655988",
                BackUpPhoneNumber = "09123623258",
                BankCardNumber = "1239684412341234",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
            }
            );;
    }
}