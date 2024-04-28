using HomeService.Domain.Core.Entities;
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

        builder.HasMany(e=>e.Suggestions)
            .WithOne(e=> e.Expert)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.ProfileImage)
            .WithOne(e => e.Expert)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.EvidenceImage)
            .WithOne(e => e.Expert)
            .OnDelete(DeleteBehavior.NoAction);
    }
}