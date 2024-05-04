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

    public async Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken)
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
        await _context.Services.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }

    public async Task<bool> Delete(int serviceId, CancellationToken cancellationToken)
    {
        var targetModel = await FindService(serviceId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task< List<Service> >GetAll(CancellationToken cancellationToken)
    {
        return await _context.Services.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task< Service> GetById(int serviceId, CancellationToken cancellationToken)
    {
        return await FindService(serviceId,cancellationToken);
    }

    public async Task< bool> Update(ServiceUpdateDto serviceUpdateDto,CancellationToken cancellationToken)
    {
        var targetModel = await FindService(serviceUpdateDto.Id, cancellationToken);

        targetModel.Name = serviceUpdateDto.Name;
        targetModel.ServiceSubCategory = serviceUpdateDto.ServiceSubCategory;
        targetModel.SubCategoryId = serviceUpdateDto.SubCategoryId;
        targetModel.Experts = serviceUpdateDto.Experts;
        targetModel.Orders = serviceUpdateDto.Orders;
        targetModel.Image = serviceUpdateDto.Image;
        targetModel.Price = serviceUpdateDto.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<Service> FindService(int id, CancellationToken cancellationToken)
   => await _context.Services.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
