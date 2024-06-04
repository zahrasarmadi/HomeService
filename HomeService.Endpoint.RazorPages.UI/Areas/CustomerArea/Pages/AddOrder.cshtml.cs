using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.OrderDTO;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace HomeService.Endpoint.RazorPages.UI.Areas.CustomerArea.Pages;

[Authorize(Roles = "Customer")]
public class AddOrderModel : PageModel
{
    private readonly IOrderAppServices _orderAppServices;
    private readonly IServiceAppServices _serviceAppServices;

    public AddOrderModel(IOrderAppServices orderAppServices, IServiceAppServices serviceAppServices)
    {
        _orderAppServices = orderAppServices;
        _serviceAppServices = serviceAppServices;
    }

    [BindProperty]
    public OrderCreateDto Order { get; set; }

    [BindProperty]
    public List<ServicesNameDto> Services { get; set; } = new List<ServicesNameDto>();

    [BindProperty]
    public IFormFile Image { get; set; }

    [BindProperty]
    public string Date { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        Services =await _serviceAppServices.GetServicesName(cancellationToken);
    }

    public async Task<IActionResult> OnPostAddOrder(OrderCreateDto order, CancellationToken cancellationToken, IFormFile image, string date)
    {
        if (ModelState.IsValid)
        {
            var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
            order.CustomerId = userCustomerId;
            await _orderAppServices.Create(order, image, date, cancellationToken);
            return RedirectToPage("CustomerOrders");
        }
        return Page();
    }
}
