using HomeService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;

public class ExpertAddressConfiguration : IEntityTypeConfiguration<ExpertAddress>
{
    public void Configure(EntityTypeBuilder<ExpertAddress> builder)
    {
        throw new NotImplementedException();
    }
}