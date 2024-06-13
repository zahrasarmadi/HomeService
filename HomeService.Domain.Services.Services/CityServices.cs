using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class CityServices : ICityServices
{
    private readonly ICityRepository _cityRepository;

    public CityServices(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
      => await _cityRepository.GetAll(cancellationToken);

    public async Task<City> GetById(int cityId, CancellationToken cancellationToken)
      => await _cityRepository.GetById(cityId, cancellationToken);
}
