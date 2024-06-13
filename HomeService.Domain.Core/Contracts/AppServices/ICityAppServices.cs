using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface ICityAppServices
{
    Task<City> GetById(int cityId, CancellationToken cancellationToken);
    Task<List<City>> GetAll(CancellationToken cancellationToken);
}