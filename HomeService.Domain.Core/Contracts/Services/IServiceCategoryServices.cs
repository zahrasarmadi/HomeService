﻿using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IServiceCategoryServices
{
    Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken);
    Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken);
    Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken);
    Task<List<CategoryNameDto>> GetCategorisName(CancellationToken cancellationToken);
    Task<ServiceCategoryUpdateDto> ServiceCategoryUpdateInfo(int id, CancellationToken cancellationToken);
}
