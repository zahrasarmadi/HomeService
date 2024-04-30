using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IOrderRepository
{
    public bool Create(OrderCreateDto orderCreateDto);
    public bool Update(OrderUpdateDto orderUpdateDto);
    public bool Delete(int orderId);
    public Order GetById(int orderId);
    public List<Order> GetAll();
}
