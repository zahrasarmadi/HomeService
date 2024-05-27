using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.AppServices;

public class ServiceCategoryAppServices: IServiceCategoryAppServices
{
    private readonly IServiceCategoryServices _serviceCategoryServices;
    private readonly IBaseSevices _baseSevices;

    public ServiceCategoryAppServices(IServiceCategoryServices serviceCategoryServices, IBaseSevices baseSevices)
    {
        _serviceCategoryServices = serviceCategoryServices;
        _baseSevices = baseSevices;
    }

    public async Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, IFormFile image, CancellationToken cancellationToken)
    {
        var imageAddress =  _baseSevices.UploadImage(image);
        serviceCategoryCreateDto.Image =await imageAddress;
        return await _serviceCategoryServices.Create(serviceCategoryCreateDto, cancellationToken);
    }

    public async Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
       =>await _serviceCategoryServices.Delete(serviceCategoryId, cancellationToken);

    public async Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken)
      =>await _serviceCategoryServices.GetAll(cancellationToken);

    public async Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
      =>await _serviceCategoryServices.GetById(serviceCategoryId, cancellationToken);

    public async Task<List<CategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
      =>await _serviceCategoryServices.GetCategorisName(cancellationToken);

    public async Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, IFormFile image, CancellationToken cancellationToken)
    {
        var imageAddress =  _baseSevices.UploadImage(image);
        serviceCategoryUpdateDto.Image = await imageAddress;
        return  await _serviceCategoryServices.Update(serviceCategoryUpdateDto, cancellationToken);
    }
}
