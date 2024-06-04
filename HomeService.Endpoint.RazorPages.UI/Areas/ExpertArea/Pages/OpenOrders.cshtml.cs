using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.ExpertArea.Pages;

[Authorize(Roles = "Expert")]
public class OpenOrdersModel : PageModel
{
    private readonly IOrderAppServices _orderAppServices;

    public OpenOrdersModel(IOrderAppServices orderAppServices)
    {
        _orderAppServices = orderAppServices;
    }

    [BindProperty]
    public List<OrdersByServiceIdsDto> Orders { get; set; }


    public async Task OnGet(CancellationToken cancellationToken)
    {
        var expertId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
        Orders = await _orderAppServices.GetOrdersByServiceIds(expertId, cancellationToken);
    }
}
