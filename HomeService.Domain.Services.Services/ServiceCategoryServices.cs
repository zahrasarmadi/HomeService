using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class ServiceCategoryServices : IServiceCategoryServices
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public ServiceCategoryServices(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }

    public async Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken)
       => await _serviceCategoryRepository.Create(serviceCategoryCreateDto, cancellationToken);

    public async Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
       => await _serviceCategoryRepository.Delete(serviceCategoryId, cancellationToken);

    public async Task<List<ServiceCategory>> GetAll(CancellationToken cancellationToken)
      => await _serviceCategoryRepository.GetAll(cancellationToken);

    public async Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
      => await _serviceCategoryRepository.GetById(serviceCategoryId, cancellationToken);

    public async Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
      => await _serviceCategoryRepository.Update(serviceCategoryUpdateDto, cancellationToken);
}
