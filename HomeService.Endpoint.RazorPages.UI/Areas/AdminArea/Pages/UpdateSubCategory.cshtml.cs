
using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class UpdateSubCategoryModel : PageModel
{
    private readonly IServicSubCategoryAppServices _serviceSubCategoryAppServices;

    public UpdateSubCategoryModel(IServicSubCategoryAppServices serviceSubCategoryAppServices)
    {
        _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
    }

    [BindProperty]
    public ServiceSubCategoryUpdateDto  ServiceSubCategoryUpdate { get; set; }

    [BindProperty]
    public IFormFile Image { get; set; }

    [BindProperty]
    public ServiceSubCategory ServiceSubCategory { get; set; }
    public async Task OnGet(int id, CancellationToken cancellationToken)
    {
        ServiceSubCategory = await _serviceSubCategoryAppServices.GetById(id, cancellationToken);
    }

    public async Task<IActionResult> OnPostUpdate(ServiceSubCategoryUpdateDto serviceSubCategoryUpdate,IFormFile image, CancellationToken cancellationToken)
    {
        await _serviceSubCategoryAppServices.Update(serviceSubCategoryUpdate, image,cancellationToken);
        return RedirectToPage("SubCategory");
    }
}
