using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;
    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool Create(ServiceCreateDto serviceCreateDto)
    {

        var newModel = new Service()
        {
            Name = serviceCreateDto.Name,
            ServiceSubCategory = serviceCreateDto.ServiceSubCategory,
            SubCategoryId = serviceCreateDto.SubCategoryId,
            Experts = serviceCreateDto.Experts,
            Orders = serviceCreateDto.Orders,
            Image = serviceCreateDto.Image,
            Price = serviceCreateDto.Price,
        };
        _context.Services.Add(newModel);

        _context.SaveChanges();
        return true;

    }

    public bool Delete(int serviceId)
    {
        _context.Services
           .FirstOrDefault(a => a.Id == serviceId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<Service> GetAll()
    {
        return _context.Services.AsNoTracking().ToList();
    }

    public Service GetById(int serviceId)
    {
        return _context.Services.AsNoTracking().FirstOrDefault(a => a.Id == serviceId);
    }

    public bool Update(ServiceUpdateDto serviceUpdateDto)
    {
        var targetModel = _context.Services.FirstOrDefault(a => a.Id == serviceUpdateDto.Id);

        targetModel.Name = serviceUpdateDto.Name;
            targetModel.ServiceSubCategory = serviceUpdateDto.ServiceSubCategory;
            targetModel.SubCategoryId = serviceUpdateDto.SubCategoryId;
            targetModel.Experts = serviceUpdateDto.Experts;
           targetModel.Orders = serviceUpdateDto.Orders;
           targetModel.Image = serviceUpdateDto.Image;
           targetModel.Price = serviceUpdateDto.Price;

        _context.SaveChanges();

        return true;
    }
}
