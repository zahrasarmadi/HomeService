using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class ServiceSubCategoryServices : IServiceSubCategoryServices
{
    private readonly IServiceSubCategoryRepository _serviceSubCategoryRepository;

    public ServiceSubCategoryServices(IServiceSubCategoryRepository serviceSubCategoryRepository)
    {
        _serviceSubCategoryRepository = serviceSubCategoryRepository;
    }

    public Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken)
      =>_serviceSubCategoryRepository.Create(serviceSubCategoryCreateDto, cancellationToken);

    public Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken)
      =>_serviceSubCategoryRepository.Delete(serviceSubCategoryId, cancellationToken);

    public Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
      =>_serviceSubCategoryRepository.GetAll(cancellationToken);

    public Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
      =>_serviceSubCategoryRepository.GetById(serviceSubCategoryId, cancellationToken);

    public Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken)
      =>_serviceSubCategoryRepository.Update(serviceSubCategoryUpdateDto, cancellationToken);
}
