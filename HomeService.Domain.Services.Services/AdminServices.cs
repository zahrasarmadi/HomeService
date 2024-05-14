using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.AdminDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class AdminServices : IAdminServices
{
    private readonly IAdminRepository _adminRepository;

    public AdminServices(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken)
      =>await _adminRepository.Create(adminCreateDto, cancellationToken);

    public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
      =>await _adminRepository.Delete(adminId, cancellationToken);

    public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
      =>await _adminRepository.GetAll(cancellationToken);

    public async Task<Admin> GetById(int adminId, CancellationToken cancellationToken)
       =>await _adminRepository.GetById(adminId, cancellationToken);

    public async Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken)
      =>await _adminRepository.Update(adminUpdateDto, cancellationToken);
}
