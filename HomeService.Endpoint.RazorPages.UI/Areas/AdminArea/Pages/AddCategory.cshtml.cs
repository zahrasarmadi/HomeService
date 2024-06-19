using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles ="Admin")]
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
    [Required(ErrorMessage = " عکس نمی‌تواند بدون مقدار باشد")]
    public IFormFile Image { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
     
    }

    public async Task<IActionResult> OnPostAddCategory(ServiceCategoryCreateDto serviceCategoryCreate, CancellationToken cancellationToken, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            await _serviceCategoryAppServices.Create(serviceCategoryCreate, image, cancellationToken);
            return RedirectToPage("Category");
        }
        return Page();
    }
}
