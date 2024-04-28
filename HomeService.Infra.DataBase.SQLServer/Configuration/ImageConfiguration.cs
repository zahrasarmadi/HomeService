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

        //builder.HasOne(i=>i.Expert)
        //    .WithOne(e=>e.EvidenceImage)
        //    .OnDelete(DeleteBehavior.NoAction);

        //builder.HasOne(i => i.Expert)
        //    .WithOne(e => e.ProfileImage)
        //    .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i=>i.Order)
            .WithMany(r=>r.Images)
            .OnDelete(DeleteBehavior.NoAction);

    }
}