using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly AppDbContext _context;
    public ServiceCategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(ServiceCategoryCreateDto serviceCategoryCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new ServiceCategory()
        {
            Name = serviceCategoryCreateDto.Name,
            ServiceSubCategories = serviceCategoryCreateDto.ServiceSubCategories,
            Image = serviceCategoryCreateDto.Image,
        };
        await _context.ServiceCategories.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }

    public async Task<bool> Delete(int serviceCategoryId, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceCategory(serviceCategoryId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<ServiceCategory>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.ServiceCategories.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
    {
        return await FindServiceCategory(serviceCategoryId, cancellationToken);
    }

    public async Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceCategory(serviceCategoryUpdateDto.Id, cancellationToken);

        targetModel.Name = serviceCategoryUpdateDto.Name;
        targetModel.ServiceSubCategories = serviceCategoryUpdateDto.ServiceSubCategories;
        targetModel.Image = serviceCategoryUpdateDto.Image;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<ServiceCategory> FindServiceCategory(int id, CancellationToken cancellationToken)
   => await _context.ServiceCategories.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
