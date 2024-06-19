using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class ServiceSubCategoryServices : IServiceSubCategoryServices
{
    private readonly IServiceSubCategoryRepository _serviceSubCategoryRepository;

    public ServiceSubCategoryServices(IServiceSubCategoryRepository serviceSubCategoryRepository)
    {
        _serviceSubCategoryRepository = serviceSubCategoryRepository;
    }

    public async Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.Create(serviceSubCategoryCreateDto, cancellationToken);

    public async Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.Delete(serviceSubCategoryId, cancellationToken);

    public async Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.GetAll(cancellationToken);

    public Task<List<GetByCategoryIdDto>> GetAllByCategoryId(int id, CancellationToken cancellationToken)
      => _serviceSubCategoryRepository.GetAllByCategoryId(id, cancellationToken);

    public async Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.GetById(serviceSubCategoryId, cancellationToken);

    public async Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.GetCategorisName(cancellationToken);

    public async Task<List<GetSubCategoryDto>> GetSubCategories(CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.GetSubCategories(cancellationToken);

    public async Task<ServiceSubCategoryUpdateDto> ServiceSubCategoryUpdateInfo(int id, CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.ServiceSubCategoryUpdateInfo(id, cancellationToken);

    public async Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken)
      => await _serviceSubCategoryRepository.Update(serviceSubCategoryUpdateDto, cancellationToken);
}
