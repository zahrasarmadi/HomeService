using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.DTOs.SubCategoryDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Services.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class AddSubCategoryModel : PageModel
{
    private readonly IServicSubCategoryAppServices _servicSubCategoryAppServices;
    private readonly IServiceCategoryAppServices _serviceCategoryAppServices;

    public AddSubCategoryModel(IServicSubCategoryAppServices servicSubCategoryAppServices, IServiceCategoryAppServices serviceCategoryAppServices)
    {
        _servicSubCategoryAppServices = servicSubCategoryAppServices;
        _serviceCategoryAppServices = serviceCategoryAppServices;
    }

    [BindProperty]
    public List<CategoryNameDto> CategoryNames { get; set; }

    [BindProperty]
    public ServiceSubCategoryCreateDto ServiceSubCategoryCreate { get; set; }

    [BindProperty]
    [Required(ErrorMessage = " عکس نمی‌تواند بدون مقدار باشد")]
    public IFormFile Image { get; set; }
    public async Task OnGet(CancellationToken cancellationToken)
    {
        CategoryNames = await _serviceCategoryAppServices.GetCategorisName(cancellationToken);
    }

    public async Task<IActionResult> OnPostAdd(ServiceSubCategoryCreateDto serviceSubCategoryCreate, CancellationToken cancellationToken, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            await _servicSubCategoryAppServices.Create(serviceSubCategoryCreate, cancellationToken, image);
            return RedirectToPage("SubCategory");
        }
        return Page();
    }
}
