using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceRepository
{
    public bool Create(ServiceCreateDto serviceCreateDto);
    public bool Update(ServiceUpdateDto serviceUpdateDto);
    public bool Delete(int serviceId);
    public Service GetById(int serviceId);
    public List<Service> GetAll();
}
