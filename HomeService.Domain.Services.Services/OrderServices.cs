using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.OrderDTO;
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

    public async Task AcceptStatus(int orderId, CancellationToken cancellationToken)
      => await _orderRepository.AcceptStatus(orderId, cancellationToken);

    public async Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken)
        => await _orderRepository.ChangeStatus(status, orderId, cancellationToken);

    public async Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
       => await _orderRepository.Create(orderCreateDto, cancellationToken);

    public async Task<bool> Delete(int orderId, CancellationToken cancellationToken)
       => await _orderRepository.Delete(orderId, cancellationToken);

    public async Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
      => await _orderRepository.GetAll(cancellationToken);

    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken)
      => await _orderRepository.GetById(orderId, cancellationToken);

    public async Task<List<GetOrderDto>> GetOrders(int customerId, CancellationToken cancellationToken)
      => await _orderRepository.GetOrders(customerId, cancellationToken);

    public async Task<int> OrderCount(CancellationToken cancellationToken)
      => await _orderRepository.OrderCount(cancellationToken);

    public async Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
      => await _orderRepository.Update(orderUpdateDto, cancellationToken);
}
