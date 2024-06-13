using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class CityAppServices : ICityAppServices
{
    private readonly ICityServices _cityServices;

    public CityAppServices(ICityServices cityServices)
    {
        _cityServices = cityServices;
    }

    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
      => await _cityServices.GetAll(cancellationToken);

    public async Task<City> GetById(int cityId, CancellationToken cancellationToken)
      => await _cityServices.GetById(cityId, cancellationToken);
}