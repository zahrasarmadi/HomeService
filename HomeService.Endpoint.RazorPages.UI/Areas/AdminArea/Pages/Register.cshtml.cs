using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.AccountDto;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class RegisterModel : PageModel
{
    private readonly IAccountAppServices _accountAppServices;

    public RegisterModel(IAccountAppServices accountAppServices)
    {
        _accountAppServices = accountAppServices;
    }

    [BindProperty]
    public AccountAdminRegisterDto AccountRegister { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(AccountAdminRegisterDto accountRegister, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/AdminArea/Register");

        if (!ModelState.IsValid)
            return Page();

        var result = await _accountAppServices.AdminRegister(accountRegister);

        if (result.Count == 0)
        {
            TempData["Success"] = "ادمین جدید در سیستم ثبت شد";
            return LocalRedirect(returnUrl);
        }
        foreach (var error in result)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return Page();
    }


}
