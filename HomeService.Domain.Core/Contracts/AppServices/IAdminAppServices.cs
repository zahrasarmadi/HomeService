﻿using HomeService.Domain.Core.DTOs.AdminDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IAdminAppServices
{
    Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int adminId, CancellationToken cancellationToken);
    public Task<Admin> GetById(int adminId, CancellationToken cancellationToken);
    public Task<List<Admin>> GetAll(CancellationToken cancellationToken);
}
