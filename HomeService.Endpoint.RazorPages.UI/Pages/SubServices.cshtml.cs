using HomeService.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Pages;

public class SubServicesModel : PageModel
{
    private readonly IServicSubCategoryAppServices _servicSubCategoryAppServices;

    public SubServicesModel(IServicSubCategoryAppServices servicSubCategoryAppServices)
    {
        _servicSubCategoryAppServices = servicSubCategoryAppServices;
    }

    public void OnGet()
    {

    }
}
