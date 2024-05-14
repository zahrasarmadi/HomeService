using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IServiceCategoryAppServices
{
    Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, IFormFile image, CancellationToken cancellationToken);
    Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto,IFormFile image, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken);
    Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken);
    Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken);
    Task<List<CategoryNameDto>> GetCategorisName(CancellationToken cancellationToken);
}
