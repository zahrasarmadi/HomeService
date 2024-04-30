using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceCategoryRepository
{
    public bool Create(ServiceCategoryCreateDto serviceCategoryCreateDto);
    public bool Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto);
    public bool Delete(int serviceCategoryId);
    public ServiceCategory GetById(int serviceCategoryId);
    public List<ServiceCategory> GetAll();
}
