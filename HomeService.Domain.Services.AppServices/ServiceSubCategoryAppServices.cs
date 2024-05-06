using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class ServiceSubCategoryAppServices: IServicCategoryServices
{
    private readonly IServiceSubCategoryServices _serviceSubCategoryServices;

    public ServiceSubCategoryAppServices(IServiceSubCategoryServices serviceSubCategoryServices)
    {
        _serviceSubCategoryServices = serviceSubCategoryServices;
    }

    public Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken)
      => _serviceSubCategoryServices.Create(serviceSubCategoryCreateDto, cancellationToken);

    public Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken)
      => _serviceSubCategoryServices.Delete(serviceSubCategoryId, cancellationToken);

    public Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
      => _serviceSubCategoryServices.GetAll(cancellationToken);

    public Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
      => _serviceSubCategoryServices.GetById(serviceSubCategoryId, cancellationToken);

    public Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken)
      => _serviceSubCategoryServices.Update(serviceSubCategoryUpdateDto, cancellationToken);
}
