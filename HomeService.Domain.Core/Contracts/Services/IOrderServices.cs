﻿using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IOrderServices
{
    Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int orderId, CancellationToken cancellationToken);
    Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken);
    Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken);
    Task<Order> GetById(int orderId, CancellationToken cancellationToken);
    Task<int> OrderCount(CancellationToken cancellationToken);
    Task<List<GetOrderDto>> GetOrders(int customerId, CancellationToken cancellationToken);
    Task AcceptOrder(int orderId, CancellationToken cancellationToken);
    Task DoneOrder(int orderId, int suggestionId, CancellationToken cancellationToken);
    Task<List<OrdersByServiceIdsDto>> GetOrdersByExpertId(int exoertId, CancellationToken cancellationToken);
    Task<bool> OrderIsDone(int orderId, CancellationToken cancellationToken);
}
