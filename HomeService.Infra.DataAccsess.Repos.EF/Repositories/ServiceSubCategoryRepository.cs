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

    public async Task<List<GetSubCategoryDto>> GetSubCategories(CancellationToken cancellationToken)
    {
        var subcategories = await _context.ServiceSubCategories.AsNoTracking().Where(c => c.IsDeleted == false)
            .Select(s => new GetSubCategoryDto
            {
                Name = s.Name,
                Id = s.Id,
                Image = s.Image,
                ServiceCategory = s.ServiceCategory,
                ServiceCategoryId = s.ServiceCategoryId,
                IsDeleted = s.IsDeleted

            }).ToListAsync(cancellationToken);
        return subcategories;
    }

    public async Task<List<ServiceSubCategory>> GetAll(CancellationToken cancellationToken)
    {
       return await _context.ServiceSubCategories.AsNoTracking().Where(c => c.IsDeleted == false)
            .Select(s=>new ServiceSubCategory()
            {
                Id=s.Id,
                Name=s.Name,
                Image=s.Image,
                CreatedAt = s.CreatedAt,
                IsDeleted = s.IsDeleted,
                ServiceCategory=s.ServiceCategory,
                ServiceCategoryId=s.ServiceCategoryId,
                Services=s.Services.Select(x=>new Service()
                {
                    Id = x.Id,
                    Image=x.Image,
                    Experts=x.Experts,
                    Price=x.Price,
                    Name=x.Name,
                    CreatedAt=x.CreatedAt,
                    IsDeleted=x.IsDeleted,
                    Orders=x.Orders,
                    ServiceSubCategory=x.ServiceSubCategory,
                    ServiceSubCategoryId=x.ServiceSubCategoryId
                }).ToList()
            })
            .ToListAsync(cancellationToken);
    }


    public async Task<ServiceSubCategory> GetById(int serviceSubCategoryId, CancellationToken cancellationToken)
       => await FindServiceSubCategory(serviceSubCategoryId, cancellationToken);

    public async Task<List<SubCategoryNameDto>> GetCategorisName(CancellationToken cancellationToken)
    {
        var subcategories = await _context.ServiceSubCategories.AsNoTracking().Where(c => c.IsDeleted == false)
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

        targetModel.Name = serviceSubCategoryUpdateDto.CategoryName;
        if(serviceSubCategoryUpdateDto.Image != null) targetModel.Image = serviceSubCategoryUpdateDto.Image;
        targetModel.ServiceCategoryId = serviceSubCategoryUpdateDto.ServiceCategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ServiceSubCategoryUpdateDto> ServiceSubCategoryUpdateInfo(int id,CancellationToken cancellationToken)
    {
       return await _context.ServiceSubCategories.AsNoTracking().Where(c => c.IsDeleted == false)
            .Select(s => new ServiceSubCategoryUpdateDto
            {
                Id = s.Id,
                CategoryName = s.Name,
                Image = s.Image,
                ServiceCategoryId = s.ServiceCategoryId,

            }).FirstOrDefaultAsync(s=>s.Id==id,cancellationToken);
    }

    public async Task<List<GetByCategoryIdDto>> GetAllByCategoryId(int id, CancellationToken cancellationToken)
    {
        return await _context.ServiceSubCategories.Where(x => x.ServiceCategoryId == id && x.IsDeleted==false).AsNoTracking()
            .Select(c=>new GetByCategoryIdDto
            {
                Id= c.Id,
                Image = c.Image,
                Name= c.Name
            })
            .ToListAsync(cancellationToken);
    }


    private async Task<ServiceSubCategory> FindServiceSubCategory(int id, CancellationToken cancellationToken)
    => await _context.ServiceSubCategories.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

}
