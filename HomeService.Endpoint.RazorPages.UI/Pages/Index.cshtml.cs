using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Pages;

public class IndexModel : PageModel
{
    private readonly IServiceCategoryAppServices _serviceCategoryAppServices;

    public IndexModel(IServiceCategoryAppServices serviceCategoryAppServices)
    {
        _serviceCategoryAppServices = serviceCategoryAppServices;
    }

    [BindProperty]
    public List<CategoryNameDto> CategoryNames { get; set; } = new List<CategoryNameDto>();

    public async Task OnGet(CancellationToken cancellationToken)
    {
        CategoryNames = await _serviceCategoryAppServices.GetCategorisName(cancellationToken);
    }
}