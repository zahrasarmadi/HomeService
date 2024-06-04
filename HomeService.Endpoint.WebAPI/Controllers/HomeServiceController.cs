using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using HomeService.Domain.Services.Services;
using HomeService.Infra.DataBase.SQLServer.Migrations;
using Microsoft.AspNetCore.Http;
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
    [Route(nameof(GetServiceSubCategory))]
    public async Task<List<ServiceSubCategory>> GetServiceSubCategory(CancellationToken cancellationToken)
    {
        var subCategories = await _servicSubCategoryAppServices.GetAll(cancellationToken);
        return subCategories;
    }

    [HttpGet]
    [Route(nameof(GetRequests))]
    public async Task<List<GetOrderDto>> GetRequests(CancellationToken cancellationToken)
    {
        var requests = await _orderAppServices.GetAll(cancellationToken);
        return requests;
    }

    [HttpPost]
    [Route(nameof(RegisterUser))]
    public async Task<string> RegisterUser(string fisrtName, string lastName, string email, string password,
            bool isExpert, GenderEnum gender)
    {
        var result = await _accountAppServices.Register(fisrtName,lastName,email,password,isExpert,gender);
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
