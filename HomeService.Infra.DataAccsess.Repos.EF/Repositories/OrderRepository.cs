using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public bool Create(OrderCreateDto orderCreateDto)
    {
        var newModel = new Order()
        {
            Title = orderCreateDto.Title,
            Description = orderCreateDto.Description,
            Status = StatusEnum.AwaitingSuggestionExperts,
            Customer = orderCreateDto.Customer,
            CustomerId = orderCreateDto.CustomerId,
            Service = orderCreateDto.Service,
            ServiceId = orderCreateDto.ServiceId,
            Images = orderCreateDto.Images,
        };
        _context.Orders.Add(newModel);

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int orderId)
    {
        _context.Orders
          .FirstOrDefault(a => a.Id == orderId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<Order> GetAll()
    {
        return _context.Orders.AsNoTracking().ToList();
    }

    public Order GetById(int orderId)
    {
        return _context.Orders.AsNoTracking().FirstOrDefault(a => a.Id == orderId);
    }

    public bool Update(OrderUpdateDto orderUpdateDto)
    {
        var targetModel = _context.Orders.FirstOrDefault(a => a.Id == orderUpdateDto.Id);

        targetModel.Title = orderUpdateDto.Title;
        targetModel.Description = orderUpdateDto.Description;
        targetModel.Status = orderUpdateDto.Status;
        targetModel.Expert = orderUpdateDto.Expert;
        targetModel.ExpertId = orderUpdateDto.ExpertId;
        targetModel.Service = orderUpdateDto.Service;
        targetModel.ServiceId = orderUpdateDto.ServiceId;
        targetModel.Images = orderUpdateDto.Images;
        targetModel.DoneAt = orderUpdateDto.DoneAt;
        targetModel.Suggestions= orderUpdateDto.Suggestions;

        _context.SaveChanges();

        return true;
    }
}
