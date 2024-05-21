using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.OrderDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.Zahra;

[Authorize(Roles = "Customer")]
public class CustomerProfile_RequestsModel : PageModel
{
    private readonly IOrderAppServices _orderAppServices;
    private readonly ISuggestionAppServices _suggestionAppServices;

    public CustomerProfile_RequestsModel(IOrderAppServices orderAppServices, ISuggestionAppServices suggestionAppServices)
    {
        _orderAppServices = orderAppServices;
        _suggestionAppServices = suggestionAppServices;
    }

    [BindProperty]
    public List<GetOrderDto> Orders { get; set; } = new List<GetOrderDto>();

    public async Task OnGet(CancellationToken cancellationToken)
    {
        var userId = int.Parse(User.Claims.First().Value);
        Orders = await _orderAppServices.GetOrders(userId, cancellationToken);
    }

    public async Task OnGetAcceptSuggestion (int id,int orderId,CancellationToken cancellationToken)
    {
      var result= await _suggestionAppServices.AcceptSuggestion(id, orderId, cancellationToken);
      
        if(result==false)
        {
            ModelState.AddModelError(string.Empty, "شما برای یک سفارش فقط میتوانید یک متخصص انتخاب کنید");
        }
    }
}
