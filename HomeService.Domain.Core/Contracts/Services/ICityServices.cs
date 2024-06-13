using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Services;

public interface ICityServices
{
    Task<City> GetById(int cityId, CancellationToken cancellationToken);
    Task<List<City>> GetAll(CancellationToken cancellationToken);
}
