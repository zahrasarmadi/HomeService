using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class AdminAppServices:IAdminAppServices
{
    private readonly IAdminServices _adminServices;

    public AdminAppServices(IAdminServices adminServices)
    {
        _adminServices = adminServices;
    }

    public Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken)
      => _adminServices.Create(adminCreateDto, cancellationToken);

    public Task<bool> Delete(int adminId, CancellationToken cancellationToken)
      => _adminServices.Delete(adminId, cancellationToken);

    public Task<List<Admin>> GetAll(CancellationToken cancellationToken)
      => _adminServices.GetAll(cancellationToken);

    public Task<Admin> GetById(int adminId, CancellationToken cancellationToken)
       => _adminServices.GetById(adminId, cancellationToken);

    public Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken)
      => _adminServices.Update(adminUpdateDto, cancellationToken);
}
