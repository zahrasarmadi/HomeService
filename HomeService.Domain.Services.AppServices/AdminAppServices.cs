﻿using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.AdminDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class AdminAppServices : IAdminAppServices
{
    private readonly IAdminServices _adminServices;

    public AdminAppServices(IAdminServices adminServices)
    {
        _adminServices = adminServices;
    }

    public async Task<AdminUpdateDto> AdminUpdateInfo(int id, CancellationToken cancellationToken)
      => await _adminServices.AdminUpdateInfo(id, cancellationToken);

    public async Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken)
      => await _adminServices.Create(adminCreateDto, cancellationToken);

    public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
      => await _adminServices.Delete(adminId, cancellationToken);

    public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
      => await _adminServices.GetAll(cancellationToken);

    public async Task<Admin> GetById(int adminId, CancellationToken cancellationToken)
       => await _adminServices.GetById(adminId, cancellationToken);

    public async Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken)
      => await _adminServices.Update(adminUpdateDto, cancellationToken);

}
