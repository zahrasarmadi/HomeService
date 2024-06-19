using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class AddServiceModel : PageModel
{
    private readonly IServiceAppServices _serviceAppServices;
    private readonly IServicSubCategoryAppServices _servicSubCategoryAppServices;

    public AddServiceModel(IServiceAppServices serviceAppServices, IServicSubCategoryAppServices servicSubCategoryAppServices)
    {
        _serviceAppServices = serviceAppServices;
        _servicSubCategoryAppServices = servicSubCategoryAppServices;
    }
    [BindProperty]
    public List<SubCategoryNameDto> SubCategoryNames { get; set; }

    [BindProperty]
    public ServiceCreateDto ServiceCreate { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        SubCategoryNames = await _servicSubCategoryAppServices.GetCategorisName(cancellationToken);
    }
    public async Task<IActionResult> OnPostAddService(ServiceCreateDto serviceCreate, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            await _serviceAppServices.Create(serviceCreate, cancellationToken);
            return RedirectToPage("Service");
        }
        return Page();
    }
}
