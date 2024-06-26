﻿using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasData(
            new Admin
            {
                Id=1,
                FirstName = "زهرا",
                LastName = "سرمدی",
                Gender = GenderEnum.Female,
                CreatedAt = DateTime.Now,
                IsDeleted=false,
                ApplicationUserId = 1
            }
        );
    }
}
