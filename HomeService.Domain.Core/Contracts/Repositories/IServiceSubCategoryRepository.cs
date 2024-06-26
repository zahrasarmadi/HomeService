﻿using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IServiceSubCategoryRepository
{
    Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken);
    Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken);
    Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken);
    Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken);
    Task<List<GetSubCategoryDto>> GetSubCategories(CancellationToken cancellationToken);
    Task<List<GetByCategoryIdDto>> GetAllByCategoryId(int id, CancellationToken cancellationToken);
    Task<ServiceSubCategoryUpdateDto> ServiceSubCategoryUpdateInfo(int id, CancellationToken cancellationToken);
}
