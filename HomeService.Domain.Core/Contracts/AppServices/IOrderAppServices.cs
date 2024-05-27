﻿using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IOrderAppServices
{
    Task<bool> Create(OrderCreateDto orderCreateDto, IFormFile image, string runTime, CancellationToken cancellationToken);
    Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int orderId, CancellationToken cancellationToken);
    Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken);
    Task<Order> GetById(int orderId, CancellationToken cancellationToken);
    Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken);
    Task<int> OrderCount(CancellationToken cancellationToken);
    Task<List<GetOrderDto>> GetOrders(int customerId, CancellationToken cancellationToken);
    Task AcceptStatus(int orderId, CancellationToken cancellationToken);
}
