using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IServiceCategoryAppServices
{
    Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken);
    Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken);
    Task<List<ServiceCategory>> GetAll(CancellationToken cancellationToken);
}
