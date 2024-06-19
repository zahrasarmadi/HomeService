using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class UpdateServiceModel : PageModel
{
    private readonly IServiceAppServices _serviceAppServices;
    private readonly IServicSubCategoryAppServices _serviceSubCategoryAppServices;

    public UpdateServiceModel(IServiceAppServices serviceAppServices, IServicSubCategoryAppServices serviceSubCategoryAppServices)
    {
        _serviceAppServices = serviceAppServices;
        _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
    }

    [BindProperty]
    public ServiceUpdateDto ServiceUpdate { get; set; }

    [BindProperty]
    public List<SubCategoryNameDto> SubCategoryNames { get; set; }

    public async Task OnGet(int id, CancellationToken cancellationToken)
    {
        ServiceUpdate = await _serviceAppServices.ServiceUpdateInfo(id, cancellationToken);
        SubCategoryNames = await _serviceSubCategoryAppServices.GetCategorisName(cancellationToken);
    }

    public async Task<IActionResult> OnPostUpdate(ServiceUpdateDto serviceUpdate, CancellationToken cancellationToken)
    {
        ModelState.Remove("Name");

        if (ModelState.IsValid)
        {
            await _serviceAppServices.Update(serviceUpdate, cancellationToken);
            return RedirectToPage("Service");
        }
        return Page();
    }
}
