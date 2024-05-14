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
            Customer = orderCreateDto.Customer,
            CustomerId = orderCreateDto.CustomerId,
            Service = orderCreateDto.Service,
            ServiceId = orderCreateDto.ServiceId,
            Image = orderCreateDto.Image,
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

    public async Task<List<Order>> GetAll(CancellationToken cancellationToken)
      => await _context.Orders.AsNoTracking().ToListAsync(cancellationToken);


    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken)
        => await FindOrder(orderId, cancellationToken);


    public async Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindOrder(orderUpdateDto.Id, cancellationToken);

        targetModel.Title = orderUpdateDto.Title;
        targetModel.Description = orderUpdateDto.Description;
        targetModel.Status = orderUpdateDto.Status;
        targetModel.Expert = orderUpdateDto.Expert;
        targetModel.ExpertId = orderUpdateDto.ExpertId;
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
    

    private async Task<Order> FindOrder(int id, CancellationToken cancellationToken)
      => await _context.Orders.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
