using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
       builder.HasKey(c => c.Id);

       builder.HasOne(c => c.Customer)
            .WithMany(c => c.Comments)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c=>c.Expert)
            .WithMany(c => c.Comments)
            .OnDelete(DeleteBehavior.NoAction);
    }
}