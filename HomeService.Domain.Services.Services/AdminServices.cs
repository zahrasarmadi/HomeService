using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class AdminServices : IAdminServices
{
    private readonly IAdminRepository _adminRepository;

    public AdminServices(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken)
      =>_adminRepository.Create(adminCreateDto, cancellationToken);

    public Task<bool> Delete(int adminId, CancellationToken cancellationToken)
      =>_adminRepository.Delete(adminId, cancellationToken);

    public Task<List<Admin>> GetAll(CancellationToken cancellationToken)
      =>_adminRepository.GetAll(cancellationToken);

    public Task<Admin> GetById(int adminId, CancellationToken cancellationToken)
       =>_adminRepository.GetById(adminId, cancellationToken);

    public Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken)
      =>_adminRepository.Update(adminUpdateDto, cancellationToken);
}
