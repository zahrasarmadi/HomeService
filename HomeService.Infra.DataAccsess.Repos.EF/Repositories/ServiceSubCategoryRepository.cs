using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;


namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ServiceSubCategoryRepository : IServiceSubCategoryRepository
{
    private readonly AppDbContext _context;
    public ServiceSubCategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto, CancellationToken cancellationToken)
    {

        var newModel = new ServiceSubCategory()
        {
            Name = serviceSubCategoryCreateDto.Name,
            ServiceCategoryId = serviceSubCategoryCreateDto.ServiceCategoryId,
            Image = serviceSubCategoryCreateDto.Image,
        };
        await _context.ServiceSubCategories.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int serviceSubCategoryId, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceSubCategory(serviceSubCategoryId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
        => await _context.ServiceSubCategories.AsNoTracking().ToListAsync(cancellationToken);


    public async Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
       => await FindServiceSubCategory(serviceSubCategoryId, cancellationToken);

    public async Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
    {
        var subcategories = await _context.ServiceSubCategories.AsNoTracking()
             .Select(s => new SubCategoryNameDto
             {
                 Id = s.Id,
                 Name = s.Name,
             }).ToListAsync(cancellationToken);
        return subcategories;
    }

    public async Task<bool> Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindServiceSubCategory(serviceSubCategoryUpdateDto.Id, cancellationToken);

        targetModel.Name = serviceSubCategoryUpdateDto.Name;
        targetModel.Image = serviceSubCategoryUpdateDto.Image;
        targetModel.Services = serviceSubCategoryUpdateDto.Services;
        targetModel.ServiceCategory = serviceSubCategoryUpdateDto.ServiceCategory;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<ServiceSubCategory> FindServiceSubCategory(int id, CancellationToken cancellationToken)
    => await _context.ServiceSubCategories.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
