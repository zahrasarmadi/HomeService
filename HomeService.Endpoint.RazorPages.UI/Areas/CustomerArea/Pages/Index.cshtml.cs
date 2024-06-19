using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.CustomerArea;

[Authorize(Roles = "Customer")]
public class IndexModel : PageModel
{
    private readonly ICustomerAppServices _customerAppServices;
    public IndexModel(ICustomerAppServices customerAppServices)
    {
        _customerAppServices = customerAppServices;
    }

    [BindProperty]
    public CustomerSummaryDto CustomerSummary { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        var userId  = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
        CustomerSummary = await _customerAppServices.GetCustomerSummary(userId, cancellationToken);
    }
}