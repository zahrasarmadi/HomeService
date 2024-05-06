using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class ServiceCategoryAppServices: IServiceCategoryAppServices
{
    private readonly IServiceCategoryServices _serviceCategoryServices;

    public ServiceCategoryAppServices(IServiceCategoryServices serviceCategoryServices)
    {
        _serviceCategoryServices = serviceCategoryServices;
    }

    public Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken)
       => _serviceCategoryServices.Create(serviceCategoryCreateDto, cancellationToken);

    public Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
       => _serviceCategoryServices.Delete(serviceCategoryId, cancellationToken);

    public Task<List<ServiceCategory>> GetAll(CancellationToken cancellationToken)
      => _serviceCategoryServices.GetAll(cancellationToken);

    public Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
      => _serviceCategoryServices.GetById(serviceCategoryId, cancellationToken);

    public Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
      => _serviceCategoryServices.Update(serviceCategoryUpdateDto, cancellationToken);
}
