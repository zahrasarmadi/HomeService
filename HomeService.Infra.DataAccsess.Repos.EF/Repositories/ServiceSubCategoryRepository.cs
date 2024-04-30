using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
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
    public bool Create(ServiceSubCategoryCreateDto serviceSubCategoryCreateDto)
    {

        var newModel = new ServiceSubCategory()
        {
            Name = serviceSubCategoryCreateDto.Name,
            Description = serviceSubCategoryCreateDto.Description,
            ServiceCategory = serviceSubCategoryCreateDto.ServiceCategory,
            ServiceCategoryId = serviceSubCategoryCreateDto.ServiceCategoryId,
            Services = serviceSubCategoryCreateDto.Services,
            Image = serviceSubCategoryCreateDto.Image,
        };
        _context.ServiceSubCategories.Add(newModel);

        _context.SaveChanges();
        return true;

    }

    public bool Delete(int serviceSubCategoryId)
    {
        _context.ServiceSubCategories
          .FirstOrDefault(a => a.Id == serviceSubCategoryId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<ServiceSubCategory> GetAll()
    {
        return _context.ServiceSubCategories.AsNoTracking().ToList();
    }

    public ServiceSubCategory GetById(int serviceSubCategoryId)
    {
        return _context.ServiceSubCategories.AsNoTracking().FirstOrDefault(a => a.Id == serviceSubCategoryId);
    }

    public bool Update(ServiceSubCategoryUpdateDto serviceSubCategoryUpdateDto)
    {
        var targetModel = _context.ServiceSubCategories.FirstOrDefault(a => a.Id == serviceSubCategoryUpdateDto.Id);

        targetModel.Name = serviceSubCategoryUpdateDto.Name;
        targetModel.Description = serviceSubCategoryUpdateDto.Description;
        targetModel.ServiceCategory= serviceSubCategoryUpdateDto.ServiceCategory;
        targetModel.Image = serviceSubCategoryUpdateDto.Image;
        targetModel.Services = serviceSubCategoryUpdateDto.Services;

        _context.SaveChanges();

        return true;
    }
}
