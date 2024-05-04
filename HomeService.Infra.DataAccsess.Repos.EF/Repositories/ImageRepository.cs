using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;
    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(ImageCreateDto imageCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new Image()
        {
            Alt = imageCreateDto.Alt,
            ImageAddress = imageCreateDto.ImageAddress,
            Expert = imageCreateDto.Expert,
            ExpertId = imageCreateDto.ExpertId,
            Order = imageCreateDto.Order,
            OrderId = imageCreateDto.OrdertId,
            Service = imageCreateDto.Service,
            ServiceId = imageCreateDto.ServiceId,
            ServiceCategory = imageCreateDto.ServiceCategory,
            ServiceSubCategory = imageCreateDto.ServiceSubCategory,
        };
        await _context.Images.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int imageId, CancellationToken cancellationToken)
    {
        var targetModel =await FindImage(imageId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Image> GetById(int imageId,CancellationToken cancellationToken)
    {
        return await FindImage(imageId,cancellationToken);
    }

    public async Task< bool> Update(ImageUpdateDto imageUpdateDto,CancellationToken cancellationToken)
    {
        var targetModel = await FindImage(imageUpdateDto.Id,cancellationToken);

        targetModel.Alt = imageUpdateDto.Alt;
        targetModel.ImageAddress = imageUpdateDto.ImageAddress;
        targetModel.Expert = imageUpdateDto.Expert;
        targetModel.ExpertId = imageUpdateDto.ExpertId;
        targetModel.Order = imageUpdateDto.Order;
        targetModel.OrderId = imageUpdateDto.OrderId;
        targetModel.Service = imageUpdateDto.Service;
        targetModel.ServiceId = imageUpdateDto.ServiceId;
        targetModel.ServiceCategory = imageUpdateDto.ServiceCategory;
        targetModel.ServiceSubCategory = imageUpdateDto.ServiceSubCategory;
       await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<Image> FindImage(int id, CancellationToken cancellationToken)
   => await _context.Images.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
