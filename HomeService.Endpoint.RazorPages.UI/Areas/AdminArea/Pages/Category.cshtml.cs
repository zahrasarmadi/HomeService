using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Services.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

public class CategoryModel : PageModel
{
    private readonly IServiceCategoryAppServices _servicesCategoryAppServices;

    public CategoryModel(IServiceCategoryAppServices servicesCategoryAppServices)
    {
        _servicesCategoryAppServices = servicesCategoryAppServices;
    }

    [BindProperty]
    public List<GetCategoryDto> GetCategories { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        GetCategories = await _servicesCategoryAppServices.GetAll(cancellationToken);
    }

    public async Task<IActionResult> OnGetDelete(int id, CancellationToken cancellationToken)
    {
        await _servicesCategoryAppServices.Delete(id, cancellationToken);
        return RedirectToAction("OnGet");
    }
}
