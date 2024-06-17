using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class ChangeStatusModel : PageModel
{
    private readonly IOrderAppServices _orderAppServices;

    public ChangeStatusModel(IOrderAppServices orderAppServices)
    {
        _orderAppServices = orderAppServices;
    }
    [BindProperty]
    public StatusEnum Status { get; set; }

    [BindProperty]
    public int OrderId { get; set; }

    [BindProperty]
    public Order Order { get; set; }

    public async Task OnGet(int id,CancellationToken cancellationToken)
    {
        Order =await _orderAppServices.GetById(id, cancellationToken);
    }
    public async Task<IActionResult> OnPostChangeStatus(int orderId,StatusEnum status, CancellationToken cancellationToken)
    {
        await _orderAppServices.ChangeStatus(status, orderId, cancellationToken);
        return RedirectToPage("Order");
    }
}
