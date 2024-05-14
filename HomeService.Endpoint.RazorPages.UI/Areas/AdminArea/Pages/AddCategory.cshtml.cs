using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

public class AddCategoryModel : PageModel
{
    private readonly IServiceCategoryAppServices _serviceCategoryAppServices;

    public AddCategoryModel(IServiceCategoryAppServices serviceCategoryAppServices)
    {
        _serviceCategoryAppServices = serviceCategoryAppServices;
    }

    [BindProperty]

    public ServiceCategoryCreateDto ServiceCategoryCreate { get; set; }

    [BindProperty]
    public IFormFile Image { get; set; }
    public async Task OnGet(CancellationToken cancellationToken)
    {
     
    }

    public async Task<IActionResult> OnPostAdd(ServiceCategoryCreateDto serviceCategoryCreate, CancellationToken cancellationToken, IFormFile image)
    {
        await _serviceCategoryAppServices.Create(serviceCategoryCreate, image ,cancellationToken);
        return RedirectToPage("Category");
    }
}
