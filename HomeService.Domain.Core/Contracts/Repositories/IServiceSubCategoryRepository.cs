using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceSubCategoryRepository
{
    public Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken);
    public Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken);
    public Task<List<ServiceSubCategory>> GetAll( CancellationToken cancellationToken);
}
