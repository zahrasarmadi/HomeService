using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.AppServices;

public class OrderAppServices : IOrderAppServices
{
    private readonly IOrderServices _orderServices;
    private readonly IBaseSevices _baseSevices;

    public OrderAppServices(IOrderServices orderServices, IBaseSevices baseSevices)
    {
        _orderServices = orderServices;
        _baseSevices = baseSevices;
    }

    public Task AcceptOrder(int orderId, CancellationToken cancellationToken)
      => _orderServices.AcceptOrder(orderId, cancellationToken);

    public async Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken)
     => await _orderServices.ChangeStatus(status, orderId, cancellationToken);

    public async Task<bool> Create(OrderCreateDto orderCreateDto, IFormFile image, string runTime, CancellationToken cancellationToken)
    {
        var gregorianDate = _baseSevices.PersianToGregorian(runTime);
        var imageUrl = await _baseSevices.UploadImage(image);
        orderCreateDto.Image = imageUrl;
        orderCreateDto.Date = gregorianDate;
        return await _orderServices.Create(orderCreateDto, cancellationToken);
    }

    public async Task<bool> Delete(int orderId, CancellationToken cancellationToken)
      => await _orderServices.Delete(orderId, cancellationToken);

    public async Task DoneOrder(int id,int suggestionId, CancellationToken cancellationToken)
      => await _orderServices.DoneOrder(id,suggestionId, cancellationToken);//;

    public async Task<List<GetOrderDto>> GetAll(CancellationToken cancellationToken)
      => await _orderServices.GetAll(cancellationToken);

    public async Task<Order> GetById(int orderId, CancellationToken cancellationToken)
      => await _orderServices.GetById(orderId, cancellationToken);

    public async Task<List<GetOrderDto>> GetOrders(int customerId, CancellationToken cancellationToken)
      => await _orderServices.GetOrders(customerId, cancellationToken);

    public async Task<List<OrdersByServiceIdsDto>> GetOrdersByServiceIds(int exoertId, CancellationToken cancellationToken)
      => await _orderServices.GetOrdersByServiceIds(exoertId, cancellationToken);

    public async Task<int> OrderCount(CancellationToken cancellationToken)
      => await _orderServices.OrderCount(cancellationToken);

    public async Task<bool> Update(OrderUpdateDto orderUpdateDto, CancellationToken cancellationToken)
      => await _orderServices.Update(orderUpdateDto, cancellationToken);
}