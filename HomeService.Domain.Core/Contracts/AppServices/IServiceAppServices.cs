﻿using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IServiceAppServices
{
    Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken, IFormFile image);
    Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceId, CancellationToken cancellationToken);
    Task<Service> GetById(int serviceId, CancellationToken cancellationToken);
    Task<List<GetServiceDto>> GetAll(CancellationToken cancellationToken);
}