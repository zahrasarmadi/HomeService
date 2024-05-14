using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
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
           Image = serviceCategoryCreateDto.Image,
        };
        await _context.ServiceCategories.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
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
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _context.ServiceCategories.AsNoTracking()
            .Select(c => new GetCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
            }).ToListAsync(cancellationToken);
        return categories;
    }

    public async Task<ServiceCategory> GetById(int serviceCategoryId, CancellationToken cancellationToken)
         =>await FindServiceCategory(serviceCategoryId, cancellationToken);
    

    public async Task<bool> Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceCategory(serviceCategoryUpdateDto.Id, cancellationToken);

        targetModel.Name = serviceCategoryUpdateDto.Name;
      //  targetModel.ServiceSubCategories = serviceCategoryUpdateDto.ServiceSubCategories;
       targetModel.Image = serviceCategoryUpdateDto.Image;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<ServiceCategory> FindServiceCategory(int id, CancellationToken cancellationToken)
   => await _context.ServiceCategories.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
