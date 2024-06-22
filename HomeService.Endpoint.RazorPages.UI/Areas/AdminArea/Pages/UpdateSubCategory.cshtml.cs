using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
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
    private readonly IServiceCategoryAppServices _serviceCategoryAppServices;

    public UpdateSubCategoryModel(IServicSubCategoryAppServices serviceSubCategoryAppServices, IServiceCategoryAppServices serviceCategoryAppServices)
    {
        _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
        _serviceCategoryAppServices = serviceCategoryAppServices;
    }

    [BindProperty]
    public ServiceSubCategoryUpdateDto  ServiceSubCategoryUpdate { get; set; }

    [BindProperty]
    public IFormFile? Image { get; set; }

    [BindProperty]
    public List<CategoryNameDto> CategoryNames { get; set; } = new List<CategoryNameDto>();

    public async Task OnGet(int id, CancellationToken cancellationToken)
    {
        ServiceSubCategoryUpdate = await _serviceSubCategoryAppServices.ServiceSubCategoryUpdateInfo(id, cancellationToken);
        CategoryNames = await _serviceCategoryAppServices.GetCategorisName(cancellationToken);
    }

    public async Task<IActionResult> OnPostUpdate(ServiceSubCategoryUpdateDto? serviceSubCategoryUpdate,IFormFile? image, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            await _serviceSubCategoryAppServices.Update(serviceSubCategoryUpdate, image, cancellationToken);
            return RedirectToPage("SubCategory");
        }
        return Page();
    }
}
