using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class ExpertConfiguration : IEntityTypeConfiguration<Expert>
{
    public void Configure(EntityTypeBuilder<Expert> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(e => e.Services)
             .WithMany(e => e.Experts);

        builder.HasMany(e => e.Suggestions)
            .WithOne(e => e.Expert)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Address)
            .WithOne(a => a.Expert)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData
            (
            new Expert
            {
                Id = 1,
                FirstName = "علی",
                LastName = "آموزگار",
                BirthDate = new DateTime(1998, 12, 03),
                PhoneNumber = "09362356998",
                Gender = GenderEnum.Male,
                IsConfrim = true,
                BankCardNumber = "1234123412341234",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
            },
             new Expert
             {
                 Id = 2,
                 FirstName = "سارا",
                 LastName = "همتی",
                 BirthDate = new DateTime(1998, 12, 03),
                 PhoneNumber = "09362357998",
                 Gender = GenderEnum.Male,
                 IsConfrim = true,
                 BankCardNumber = "1234123412341255",
                 CreatedAt = DateTime.Now,
                 IsDeleted = false,
             }
            );
        ;
    }
}

