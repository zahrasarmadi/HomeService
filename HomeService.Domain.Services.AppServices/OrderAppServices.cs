using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;

namespace HomeService.Domain.Services.AppServices;

public class OrderAppServices : IOrderAppServices
{
    private readonly IOrderServices _orderServices;

    public OrderAppServices(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    public Task AcceptStatus(int orderId, CancellationToken cancellationToken)
      =>_orderServices.AcceptStatus(orderId, cancellationToken);

    public async Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken)
     => await _orderServices.ChangeStatus(status, orderId, cancellationToken);

    public async Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
      => await _orderServices.Create(orderCreateDto, cancellationToken);

    public async Task<bool> Delete(int orderId, CancellationToken cancellationToken)
      => await _orderServices.Delete(orderId, cancellationToken);

    public async Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
      => await _orderServices.GetAll(cancellationToken);

    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken)
      => await _orderServices.GetById(orderId, cancellationToken);

    public async Task<List<GetOrderDto>> GetOrders(int customerId, CancellationToken cancellationToken)
      =>await _orderServices.GetOrders(customerId, cancellationToken);  

    public async Task<int> OrderCount(CancellationToken cancellationToken)
      => await _orderServices.OrderCount(cancellationToken);

    public async Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
      => await _orderServices.Update(orderUpdateDto, cancellationToken);
}
