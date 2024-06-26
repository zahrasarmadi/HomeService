﻿using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CategoryDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class UpdateCategoryModel : PageModel
{
    private readonly IServiceCategoryAppServices _serviceCategoryAppServices;

    public UpdateCategoryModel(IServiceCategoryAppServices serviceCategoryAppServices)
    {
        _serviceCategoryAppServices = serviceCategoryAppServices;
    }

    [BindProperty]
    public ServiceCategoryUpdateDto ServiceCategoryUpdate { get; set; }

    [BindProperty]
    public IFormFile? Image { get; set; }

    public async Task OnGet(int id, CancellationToken cancellationToken)
    {
        ServiceCategoryUpdate = await _serviceCategoryAppServices.ServiceCategoryUpdateInfo(id, cancellationToken);
    }

    public async Task<IActionResult> OnPostUpdate(ServiceCategoryUpdateDto serviceCategoryUpdate, IFormFile? image, CancellationToken cancellationToken)
    {
        var model = new ServiceCategoryUpdateDto();
        if (ModelState.IsValid)
        {
            await _serviceCategoryAppServices.Update(serviceCategoryUpdate, image, cancellationToken);
            return RedirectToPage("Category");
        }
        return RedirectToPage();
    }
}
