using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IServicSubCategoryAppServices
{
    Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken, IFormFile image);
    Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto,IFormFile image, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken);
    Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken);
    Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken);
    Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken);
    Task<List<GetSubCategoryDto>> GetSubCategories(CancellationToken cancellationToken);
}
