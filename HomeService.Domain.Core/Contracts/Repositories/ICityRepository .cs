using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICityRepository
{
    public City GetById(int cityId);
    public List<City> GetAll();
}
