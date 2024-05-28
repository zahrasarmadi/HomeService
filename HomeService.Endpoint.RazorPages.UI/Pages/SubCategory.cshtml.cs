using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Pages;

public class SubCategoryModel : PageModel
{
    private readonly IServicSubCategoryAppServices _servicSubCategoryAppServices;

    public SubCategoryModel(IServicSubCategoryAppServices servicSubCategoryAppServices)
    {
        _servicSubCategoryAppServices = servicSubCategoryAppServices;
    }

    [BindProperty]
    public List<GetByCategoryIdDto> SubCategories { get; set; }

    public async Task OnGet(int id,CancellationToken cancellationToken)
    {
      SubCategories =await _servicSubCategoryAppServices.GetAllByCategoryId(id, cancellationToken);
    }
}
