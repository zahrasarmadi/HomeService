using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class ServiceServices : IServiceServices
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceServices(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken)
      =>_serviceRepository.Create(serviceCreateDto, cancellationToken);

    public Task<bool> Delete(int serviceId, CancellationToken cancellationToken)
       =>_serviceRepository.Delete(serviceId, cancellationToken);

    public Task<List<Service>> GetAll(CancellationToken cancellationToken)
      =>_serviceRepository.GetAll(cancellationToken);

    public Task<Service> GetById(int serviceId, CancellationToken cancellationToken)
      =>_serviceRepository.GetById(serviceId, cancellationToken);

    public Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken)
      =>_serviceRepository.Update(serviceUpdateDto, cancellationToken);
}
