using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;

namespace HomeService.Domain.Services.Services;

public class OrderServices : IOrderServices
{
    private readonly IOrderRepository _orderRepository;

    public OrderServices(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken)
        => _orderRepository.ChangeStatus(status, orderId, cancellationToken);

    public Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
       =>_orderRepository.Create(orderCreateDto, cancellationToken);

    public Task<bool> Delete(int orderId, CancellationToken cancellationToken)
       =>_orderRepository.Delete(orderId, cancellationToken);

    public Task<List<Order>> GetAll(CancellationToken cancellationToken)
      =>_orderRepository.GetAll(cancellationToken);

    public Task<Order> GetById(int orderId, CancellationToken cancellationToken)
      => _orderRepository.GetById(orderId, cancellationToken);

    public Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
      =>_orderRepository.Update(orderUpdateDto, cancellationToken);
}
