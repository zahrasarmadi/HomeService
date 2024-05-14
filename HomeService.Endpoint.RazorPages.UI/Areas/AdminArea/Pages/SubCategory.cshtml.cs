using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

public class SubCategoryModel : PageModel
{
    private readonly IServicSubCategoryAppServices _serviceSubCategoryAppServices;

    public SubCategoryModel(IServicSubCategoryAppServices serviceSubCategoryAppServices)
    {
        _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
    }

    [BindProperty]
    public List<GetSubCategoryDto> SubCategories { get; set; }
    public async Task OnGet(CancellationToken cancellationToken)
    {
        SubCategories = await _serviceSubCategoryAppServices.GetSubCategories(cancellationToken);
    }

    public async Task<IActionResult> OnGetDelete(int id, CancellationToken cancellationToken)
    {
        await _serviceSubCategoryAppServices.Delete(id, cancellationToken);
        return RedirectToAction("OnGet");
    }
}
