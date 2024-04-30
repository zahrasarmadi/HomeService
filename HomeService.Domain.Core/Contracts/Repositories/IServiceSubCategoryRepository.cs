using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceSubCategoryRepository
{
    public bool Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto);
    public bool Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto);
    public bool Delete(int serviceSubCategoryId);
    public ServiceSubCategory GetById(int serviceSubCategoryId);
    public List<ServiceSubCategory> GetAll();
}
