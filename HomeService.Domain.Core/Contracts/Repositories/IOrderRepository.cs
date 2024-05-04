using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IOrderRepository
{
    public Task<bool> Create(OrderCreateDto orderCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int orderId, CancellationToken cancellationToken);
    public Task<Order> GetById(int orderId, CancellationToken cancellationToken);
    public Task<List<Order>> GetAll( CancellationToken cancellationToken);
}
