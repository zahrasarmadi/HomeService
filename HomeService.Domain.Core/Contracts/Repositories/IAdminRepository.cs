using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IAdminRepository
{
    public bool Create(AdminCreateDto adminCreateDto);
    public bool Update(AdminUpdateDto adminUpdateDto);
    public bool Delete(int adminId);
    public Admin GetById(int adminId);
    public List<Admin> GetAll();
}
