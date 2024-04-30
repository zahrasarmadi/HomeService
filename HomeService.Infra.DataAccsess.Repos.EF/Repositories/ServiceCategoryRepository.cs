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
    public bool Create(ServiceCategoryCreateDto serviceCategoryCreateDto)
    {
        var newModel = new ServiceCategory()
        {
            Name = serviceCategoryCreateDto.Name,
            ServiceSubCategories = serviceCategoryCreateDto.ServiceSubCategories,
            Image = serviceCategoryCreateDto.Image,
        };
        _context.ServiceCategories.Add(newModel);

        _context.SaveChanges();
        return true;

    }

    public bool Delete(int serviceCategoryId)
    {
        _context.ServiceCategories
          .FirstOrDefault(a => a.Id == serviceCategoryId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<ServiceCategory> GetAll()
    {
        return _context.ServiceCategories.AsNoTracking().ToList();
    }

    public ServiceCategory GetById(int serviceCategoryId)
    {
        return _context.ServiceCategories.AsNoTracking().FirstOrDefault(a => a.Id == serviceCategoryId);
    }

    public bool Update(ServiceCategoryUpdateDto serviceCategoryUpdateDto)
    {
        var targetModel = _context.ServiceCategories.FirstOrDefault(a => a.Id == serviceCategoryUpdateDto.Id);

        targetModel.Name = serviceCategoryUpdateDto.Name;
        targetModel.ServiceSubCategories = serviceCategoryUpdateDto.ServiceSubCategories;
        targetModel.Image = serviceCategoryUpdateDto.Image;

        _context.SaveChanges();

        return true;
    }
}
