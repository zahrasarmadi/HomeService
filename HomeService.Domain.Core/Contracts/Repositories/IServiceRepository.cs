﻿using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceRepository
{
    Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceId, CancellationToken cancellationToken);
    Task<Service> GetById(int serviceId, CancellationToken cancellationToken);
    Task<List<GetServiceDto>> GetAll(CancellationToken cancellationToken);
    Task<List<ServicesNameDto>> GetServicesName(CancellationToken cancellationToken);
    Task<List<GetByCategorySubIdDto>> GetAllBySubCategoryId(int id, CancellationToken cancellationToken);
    Task<ServiceUpdateDto> ServiceUpdateInfo(int id, CancellationToken cancellationToken);
    Task<ServiceNameAndPriceDto> GetServiceNameAndPrice(int id, CancellationToken cancellationToken);
}
