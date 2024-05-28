using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

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
            ServiceSubCategoryId = serviceCreateDto.ServiceSubCategoryId,
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

    public async Task<List<GetServiceDto>> GetAll(CancellationToken cancellationToken)
    {
      var services=  await _context.Services.AsNoTracking()
            .Select(s => new GetServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                IsDeleted = s.IsDeleted,
                Price = s.Price,
                ServiceSubCategoryId = s. ServiceSubCategoryId,
                ServiceSubCategory = s.ServiceSubCategory,
                Image=s.Image,
               
            })
            .ToListAsync(cancellationToken);

        return services;
    }


    public async Task<List<ServicesNameDto>> GetServicesName(CancellationToken cancellationToken)
    {
        return await _context.Services.Select(s => new ServicesNameDto
        {
            Id = s.Id,
            Name = s.Name,
            Price = s.Price
        }).ToListAsync(cancellationToken);
    }

    public async Task< Service> GetById(int serviceId, CancellationToken cancellationToken)
        => await FindService(serviceId,cancellationToken);

    public async Task< bool> Update(ServiceUpdateDto serviceUpdateDto,CancellationToken cancellationToken)
    {
        var targetModel = await FindService(serviceUpdateDto.Id, cancellationToken);

        targetModel.Name = serviceUpdateDto.Name;
       //targetModel.Image = serviceUpdateDto.Image;
        targetModel.Price = serviceUpdateDto.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<List<GetByCategorySubIdDto>> GetAllBySubCategoryId(int id, CancellationToken cancellationToken)
    {
        return await _context.Services.Where(x => x.ServiceSubCategoryId == id).AsNoTracking()
            .Select(c => new GetByCategorySubIdDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync(cancellationToken);
    }
    private async Task<Service> FindService(int id, CancellationToken cancellationToken)
       => await _context.Services.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
