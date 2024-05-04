using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IAdminRepository
{
    public Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int adminId, CancellationToken cancellationToken);
    public Task<Admin> GetById(int adminId, CancellationToken cancellationToken);
    public Task<List<Admin>> GetAll(CancellationToken cancellationToken);
}
