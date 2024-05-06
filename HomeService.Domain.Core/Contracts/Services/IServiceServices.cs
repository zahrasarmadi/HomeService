using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IServiceServices
{
    Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceId, CancellationToken cancellationToken);
    Task<Service> GetById(int serviceId, CancellationToken cancellationToken);
    Task<List<Service>> GetAll(CancellationToken cancellationToken);
}
