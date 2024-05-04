using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICityRepository
{
    public Task<City> GetById(int cityId, CancellationToken cancellationToken);
    public Task<List<City>> GetAll(CancellationToken cancellationToken);
}
