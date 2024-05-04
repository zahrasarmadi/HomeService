using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceRepository
{
    public Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int serviceId, CancellationToken cancellationToken);
    public Task<Service> GetById(int serviceId, CancellationToken cancellationToken);
    public Task<List<Service>> GetAll( CancellationToken cancellationToken);
}
