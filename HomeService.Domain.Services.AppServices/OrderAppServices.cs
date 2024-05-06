using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using HomeService.Domain.Services.Services;

namespace HomeService.Domain.Services.AppServices;

public class OrderAppServices : IOrderAppServices
{
    private readonly OrderServices _orderService;

    public OrderAppServices(OrderServices orderService)
    {
        _orderService = orderService;
    }

    public Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken)
        => _orderService.ChangeStatus(status, orderId, cancellationToken);

    public Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
       => _orderService.Create(orderCreateDto, cancellationToken);

    public Task<bool> Delete(int orderId, CancellationToken cancellationToken)
       => _orderService.Delete(orderId, cancellationToken);

    public Task<List<Order>> GetAll(CancellationToken cancellationToken)
      => _orderService.GetAll(cancellationToken);

    public Task<Order> GetById(int orderId, CancellationToken cancellationToken)
      => _orderService.GetById(orderId, cancellationToken);

    public Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
      => _orderService.Update(orderUpdateDto, cancellationToken);
}
