using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class ServiceCategoryServices : IServiceCategoryServices
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public ServiceCategoryServices(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }

    public Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken)
       => _serviceCategoryRepository.Create(serviceCategoryCreateDto, cancellationToken);

    public Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
       =>_serviceCategoryRepository.Delete(serviceCategoryId, cancellationToken);

    public Task<List<ServiceCategory>> GetAll(CancellationToken cancellationToken)
      =>_serviceCategoryRepository.GetAll(cancellationToken);

    public Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
      =>_serviceCategoryRepository.GetById(serviceCategoryId, cancellationToken);

    public Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
      =>_serviceCategoryRepository.Update(serviceCategoryUpdateDto, cancellationToken); 
}
