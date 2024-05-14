﻿using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<ServiceCategoryRepository> _logger;

    public ServiceCategoryRepository(AppDbContext context, IMemoryCache memoryCache, ILogger<ServiceCategoryRepository> logger)
    {
        _context = context;
        _memoryCache = memoryCache;
        _logger = logger;
    }

    public async Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new ServiceCategory()
        {
            Name = serviceCategoryCreateDto.Name,
            Image = serviceCategoryCreateDto.Image,
        };
        await _context.ServiceCategories.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        _memoryCache.Remove("Categories");
        return true;
    }

    public async Task<List<CategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
    {
        var categories = await _context.ServiceCategories.AsNoTracking()
               .Select(s => new CategoryNameDto
               {
                   Id = s.Id,
                   Name = s.Name,
               }).ToListAsync(cancellationToken);
        return categories;
    }

    public async Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceCategory(serviceCategoryId, cancellationToken);
        targetModel.IsDeleted = true;
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
           _logger.LogInformation("category is deleted");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        _memoryCache.Remove("Categories");
        return true;
    }

    public async Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken)
    {
        var categories = _memoryCache.Get<List<GetCategoryDto>>("Categories");
        if (categories is null)
        {
            categories = await _context.ServiceCategories.AsNoTracking()
               .Select(c => new GetCategoryDto
               {
                   Id = c.Id,
                   Name = c.Name,
                   Image = c.Image,
               }).ToListAsync(cancellationToken);

            return categories;
        }
        _memoryCache.Set("Categories", categories, new MemoryCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromSeconds(200)
        });
        return categories;
    }

    public async Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
     => await FindServiceCategory(serviceCategoryId, cancellationToken);


    public async Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceCategory(serviceCategoryUpdateDto.Id, cancellationToken);

        targetModel.Name = serviceCategoryUpdateDto.Name;
        //  targetModel.ServiceSubCategories = serviceCategoryUpdateDto.ServiceSubCategories;
        targetModel.Image = serviceCategoryUpdateDto.Image;

        await _context.SaveChangesAsync(cancellationToken);
        _memoryCache.Remove("Categories");

        return true;
    }

    private async Task<ServiceCategory> FindServiceCategory(int id, CancellationToken cancellationToken)
   => await _context.ServiceCategories.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
