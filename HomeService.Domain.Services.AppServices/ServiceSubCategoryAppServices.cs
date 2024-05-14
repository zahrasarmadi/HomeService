using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class ServiceSubCategoryAppServices: IServicSubCategoryAppServices
{
    private readonly IServiceSubCategoryServices _serviceSubCategoryServices;

    public ServiceSubCategoryAppServices(IServiceSubCategoryServices serviceSubCategoryServices)
    {
        _serviceSubCategoryServices = serviceSubCategoryServices;
    }

    public async Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken)
      =>await _serviceSubCategoryServices.Create(serviceSubCategoryCreateDto, cancellationToken);

    public async Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken)
      =>await _serviceSubCategoryServices.Delete(serviceSubCategoryId, cancellationToken);

    public async Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
      =>await _serviceSubCategoryServices.GetAll(cancellationToken);

    public async Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
      =>await _serviceSubCategoryServices.GetById(serviceSubCategoryId, cancellationToken);

    public async Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
      =>await _serviceSubCategoryServices.GetCategorisName(cancellationToken);

    public async Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken)
      =>await _serviceSubCategoryServices.Update(serviceSubCategoryUpdateDto, cancellationToken);
}
