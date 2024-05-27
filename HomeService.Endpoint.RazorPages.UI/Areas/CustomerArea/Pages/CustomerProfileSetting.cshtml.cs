using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.CustomerArea.Pages;

[Authorize(Roles = "Customer")]
public class CustomerProfileSettingModel : PageModel
{
    private readonly ICustomerAppServices _customerAppServices;

    public CustomerProfileSettingModel(ICustomerAppServices customerAppServices)
    {
        _customerAppServices = customerAppServices;
    }

    [BindProperty]
    public CustomerUpdateDto CustomerUpdate { get; set; } = new CustomerUpdateDto();

    public async Task OnGet(CancellationToken cancellationToken)
    {

    }

    public async Task OnPostUpdate(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken)
    {

        var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
        customerUpdate.Id = userCustomerId;
        await _customerAppServices.Update(customerUpdate, cancellationToken);
    }
}