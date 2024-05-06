using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IServicCategoryServices
{
    Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken);
    Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken);
    Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken);
}
