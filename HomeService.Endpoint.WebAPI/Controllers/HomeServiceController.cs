using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.AccountDto;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.Endpoint.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeServiceController : ControllerBase
{
    private readonly IServicSubCategoryAppServices _servicSubCategoryAppServices;
    private readonly IOrderAppServices _orderAppServices;
    private readonly IAccountAppServices _accountAppServices;

    public HomeServiceController(IServicSubCategoryAppServices servicSubCategoryAppServices, IOrderAppServices orderAppServices, IAccountAppServices accountAppServices)
    {
        _servicSubCategoryAppServices = servicSubCategoryAppServices;
        _orderAppServices = orderAppServices;
        _accountAppServices = accountAppServices;
    }

    [HttpGet]
    [Route(nameof(GetServiceSubCategoryWithServices))]
    public async Task<List<ServiceSubCategory>> GetServiceSubCategoryWithServices(CancellationToken cancellationToken)
    {
        var subCategories = await _servicSubCategoryAppServices.GetAll(cancellationToken);
        return subCategories;
    }

    [HttpGet]
    [Route(nameof(GetOrders))]
    public async Task<List<GetOrderDto>> GetOrders(CancellationToken cancellationToken)
    {
        var requests = await _orderAppServices.GetAll(cancellationToken);
        return requests;
    }

    [HttpPost]
    [Route(nameof(RegisterUser))]
    public async Task<string> RegisterUser(AccountRegisterDto accountRegister)
    {
        var result = await _accountAppServices.Register(accountRegister);
        if (result.Count == 0)
        {
            return "ثبت نام انجام شد";
        }
        else
        {
            return "خطا در ثبت نام";
        }
    }
}
