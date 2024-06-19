using HomeService.Domain.Core.DTOs.AdminDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IAdminServices
{
    Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int adminId, CancellationToken cancellationToken);
    Task<Admin> GetById(int adminId, CancellationToken cancellationToken);
    Task<List<Admin>> GetAll(CancellationToken cancellationToken);
    Task<AdminUpdateDto> AdminUpdateInfo(int id, CancellationToken cancellationToken);
}
