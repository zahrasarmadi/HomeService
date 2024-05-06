using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class ServiceAppServices : IServiceAppServices
{
    private readonly IServiceServices _serviceServices;

    public ServiceAppServices(IServiceServices serviceServices)
    {
        _serviceServices = serviceServices;
    }

    public Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken)
      => _serviceServices.Create(serviceCreateDto, cancellationToken);

    public Task<bool> Delete(int serviceId, CancellationToken cancellationToken)
       => _serviceServices.Delete(serviceId, cancellationToken);

    public Task<List<Service>> GetAll(CancellationToken cancellationToken)
      => _serviceServices.GetAll(cancellationToken);

    public Task<Service> GetById(int serviceId, CancellationToken cancellationToken)
      => _serviceServices.GetById(serviceId, cancellationToken);

    public Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken)
      => _serviceServices.Update(serviceUpdateDto, cancellationToken);
}
