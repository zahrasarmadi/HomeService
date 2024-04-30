using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasOne(i => i.Service)
            .WithOne(s => s.Image)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i=>i.ServiceCategory)
            .WithOne(s=>s.Image)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i=>i.ServiceSubCategory)
            .WithOne(s=>s.Image)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i => i.Expert)
            .WithOne(e => e.ProfileImage)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i=>i.Order)
            .WithMany(r=>r.Images)
            .OnDelete(DeleteBehavior.NoAction);

        //service category
        builder.HasData
            (
            new Image
            {
                Id = 1,
                Alt = "ساختمان",
                ImageAddress = @"..\HomeService\HomeService.Endpoint.RazorPages.UI\wwwroot\img\ServiceCategory\f842e927-824f-49f6-8710-124e7f517ed6-mainCategory-icon.webp",
                ServiceCategoryId = 1,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                
            },
            new Image
            {
                Id = 2,
                Alt = "تعمیرات اشیاء",
                ImageAddress = @"..\HomeService\HomeService.Endpoint.RazorPages.UI\wwwroot\img\ServiceCategory\08a5087d-cd08-49a2-82dd-4738cb2182bd-mainCategory-icon.webp",
                ServiceCategoryId = 2,
                CreatedAt = DateTime.Now,
                IsDeleted=false
            }
            );

        //builder.HasData
        //   (
        //   new Image
        //   {
        //       Id = 7,
        //       Alt = "منصور آموزگار",
        //       ImageAddress = @"..\\HomeService\HomeService.Endpoint.RazorPages.UI\wwwroot\img\ExpertProfile\images.jfif",
        //       ExpertId = 1,
        //       CreatedAt = DateTime.Now,
        //   }
        //   );
    }
}