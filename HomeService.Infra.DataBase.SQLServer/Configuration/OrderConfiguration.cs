using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Expert)
            .WithMany(c => c.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Service)
            .WithMany(c => c.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(o=>o.Suggestions)
            .WithOne(s=>s.Order)
            .OnDelete(DeleteBehavior.NoAction);

      

        builder.HasData(
            new Order
            {
                Id=1,
                CreatedAt = DateTime.Now,
                CustomerId=1,
                IsDeleted=false,
                Description="نظافت خونه صد متری هب طور کامل",
                ExpertId=1,
                DoneAt= DateTime.Now,
                RequestedAt= DateTime.Now,
                ServiceId=1,
                Title="نظافت",
                Status=StatusEnum.Confirmed,
            }
            );
    }
}