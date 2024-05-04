using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceCategoryRepository
{
    public Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken);
    public Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken);
    public Task<List<ServiceCategory>> GetAll( CancellationToken cancellationToken);
}
