using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.AppServices;

public class ServiceSubCategoryAppServices : IServicSubCategoryAppServices
{
    private readonly IServiceSubCategoryServices _serviceSubCategoryServices;
    private readonly IBaseSevices _baseSevices;

    public ServiceSubCategoryAppServices(IServiceSubCategoryServices serviceSubCategoryServices, IBaseSevices baseSevices)
    {
        _serviceSubCategoryServices = serviceSubCategoryServices;
        _baseSevices = baseSevices;
    }

    public async Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken, IFormFile image)
    {
        var imageAddress = _baseSevices.UploadImage(image);
        serviceSubCategoryCreateDto.Image = await imageAddress;
        return await _serviceSubCategoryServices.Create(serviceSubCategoryCreateDto, cancellationToken);
    }

    public async Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken)
      => await _serviceSubCategoryServices.Delete(serviceSubCategoryId, cancellationToken);

    public async Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
      => await _serviceSubCategoryServices.GetAll(cancellationToken);

    public Task<List<GetByCategoryIdDto>> GetAllByCategoryId(int id, CancellationToken cancellationToken)
      => _serviceSubCategoryServices.GetAllByCategoryId(id, cancellationToken);

    public async Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
      => await _serviceSubCategoryServices.GetById(serviceSubCategoryId, cancellationToken);

    public async Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
      => await _serviceSubCategoryServices.GetCategorisName(cancellationToken);

    public async Task<List<GetSubCategoryDto>> GetSubCategories(CancellationToken cancellationToken)
      => await _serviceSubCategoryServices.GetSubCategories(cancellationToken);

    public async Task<ServiceSubCategoryUpdateDto> ServiceSubCategoryUpdateInfo(int id, CancellationToken cancellationToken)
      => await _serviceSubCategoryServices.ServiceSubCategoryUpdateInfo(id, cancellationToken);

    public async Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, IFormFile image, CancellationToken cancellationToken)
    {
        if (image != null)
        {
            var imageAddress = _baseSevices.UploadImage(image);
            serviceSubCategoryUpdateDto.Image = await imageAddress;
        }
        return await _serviceSubCategoryServices.Update(serviceSubCategoryUpdateDto, cancellationToken);
    }
}
