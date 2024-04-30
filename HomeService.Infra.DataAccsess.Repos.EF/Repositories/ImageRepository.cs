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
    public bool Create(ImageCreateDto imageCreateDto)
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
        _context.Images.Add(newModel);

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int imageId)
    {
        _context.Customers
          .FirstOrDefault(a => a.Id == imageId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public Image GetById(int imageId)
    {
        return _context.Images.AsNoTracking().FirstOrDefault(a => a.Id == imageId);
    }

    public bool Update(ImageUpdateDto imageUpdateDto)
    {
        var targetModel = _context.Images.FirstOrDefault(a => a.Id == imageUpdateDto.Id);

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
        _context.SaveChanges();

        return true;
    }
}
