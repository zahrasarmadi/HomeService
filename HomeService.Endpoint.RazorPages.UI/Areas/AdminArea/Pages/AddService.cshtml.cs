using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

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

    [BindProperty]
    public IFormFile Image { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        SubCategoryNames = await _servicSubCategoryAppServices.GetCategorisName(cancellationToken);
    }
    public async Task<IActionResult> OnPostAdd(ServiceCreateDto serviceCreate, CancellationToken cancellationToken, IFormFile image)
    {
        await _serviceAppServices.Create(serviceCreate, cancellationToken, image);
        return RedirectToPage("SubCategory");
    }
}
