using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class ServiceCategoryAppServices: IServiceCategoryAppServices
{
    private readonly IServiceCategoryServices _serviceCategoryServices;

    public ServiceCategoryAppServices(IServiceCategoryServices serviceCategoryServices)
    {
        _serviceCategoryServices = serviceCategoryServices;
    }

    public async Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken)
       =>await _serviceCategoryServices.Create(serviceCategoryCreateDto, cancellationToken);

    public async Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
       =>await _serviceCategoryServices.Delete(serviceCategoryId, cancellationToken);

    public async Task<List<ServiceCategory>> GetAll(CancellationToken cancellationToken)
      =>await _serviceCategoryServices.GetAll(cancellationToken);

    public async Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
      =>await _serviceCategoryServices.GetById(serviceCategoryId, cancellationToken);

    public async Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
      =>await _serviceCategoryServices.Update(serviceCategoryUpdateDto, cancellationToken);
}
