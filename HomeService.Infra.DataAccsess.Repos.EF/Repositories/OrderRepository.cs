﻿using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new Order()
        {
            Title = orderCreateDto.Title,
            Description = orderCreateDto.Description,
            Status = StatusEnum.AwaitingSuggestionExperts,
            CustomerId = orderCreateDto.CustomerId,
            ServiceId = orderCreateDto.ServiceId,
            Image = orderCreateDto.Image,
            RequesteForTime = orderCreateDto.Date
        };
        await _context.Orders.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int orderId, CancellationToken cancellationToken)
    {
        var targetModel = await FindOrder(orderId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
    {
        var orders = await _context.Orders.AsNoTracking()
             .Select(o => new GetOrderDto
             {
                 Id = o.Id,
                 Title = o.Title,
                 Description = o.Description,
                 Status = o.Status,
                 Customer = o.Customer,
                 Service = o.Service,
                 Suggestions = o.Suggestions
             }).ToListAsync(cancellationToken);

        return orders;
    }


    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken)
        => await FindOrder(orderId, cancellationToken);


    public async Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindOrder(orderUpdateDto.Id, cancellationToken);

        targetModel.Title = orderUpdateDto.Title;
        targetModel.Description = orderUpdateDto.Description;
        targetModel.Status = orderUpdateDto.Status;
        targetModel.Service = orderUpdateDto.Service;
        targetModel.ServiceId = orderUpdateDto.ServiceId;
        targetModel.Image = orderUpdateDto.Image;
        targetModel.DoneAt = orderUpdateDto.DoneAt;
        targetModel.Suggestions = orderUpdateDto.Suggestions;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken)
    {
        var targetModel = await FindOrder(orderId, cancellationToken);
        targetModel.Status = status;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<int> OrderCount(CancellationToken cancellationToken)
      => await _context.Orders.CountAsync(cancellationToken);

    public async Task<List<GetOrderDto>> GetOrders(int customerId, CancellationToken cancellationToken)
    {
        var target = await _context.Orders.Where(o => o.Customer.Id == customerId && o.IsDeleted == false)
            .Select(o => new GetOrderDto
            {
                Customer = o.Customer,
                Description = o.Description,
                Image = o.Image,
                Id = o.Id,
                Service = o.Service,
                Status = o.Status,
                Title = o.Title,
                Suggestions = o.Suggestions.Select(x => new Suggestion()
                {
                    ExpertId = x.ExpertId,
                    Expert = x.Expert,
                    Id = x.Id,
                    Description = x.Description,
                    Price = x.Price,
                    SuggestedDate = x.SuggestedDate,
                    Status = x.Status,
                }).ToList()

            }).ToListAsync(cancellationToken);

        return target;
    }

    public async Task AcceptOrder(int orderId, CancellationToken cancellationToken)
    {
        var target = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
        target.Status =StatusEnum.Confirmed;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DoneOrder(int id, CancellationToken cancellationToken)
    {
        var targetOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        targetOrder.Status = StatusEnum.Done;
        targetOrder.DoneAt = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<OrdersByServiceIdsDto>> GetOrdersByServiceIds(List<int> serviceIds, CancellationToken cancellationToken)
    {
      return await _context.Orders.Where(o => serviceIds.Contains(o.ServiceId))
            .Select(o=>new OrdersByServiceIdsDto
            {
                Id=o.Id,
                Title=o.Title,
                Description=o.Description,
                Image=o.Image,
                CustomerId=o.CustomerId,
                Customer=o.Customer,
                Service= o.Service,
                ServiceId = o.ServiceId,
                Status=o.Status
                
            }).ToListAsync(cancellationToken);
    }

    private async Task<Order> FindOrder(int id, CancellationToken cancellationToken)
      => await _context.Orders.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
