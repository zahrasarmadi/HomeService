using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.AccountDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Endpoint.RazorPages.UI.Areas.Account.Pages;

public class LoginModel : PageModel
{

    private readonly IAccountAppServices _accountAppServices;

    public LoginModel(IAccountAppServices accountAppServices)
    {
        _accountAppServices = accountAppServices;
    }

    [BindProperty]
    public AccountLoginDto AccountLogin { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(AccountLoginDto accountLogin, string returnUrl = null)
    {
        //returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid)
            return Page();

        var succeededLogin = await _accountAppServices.Login(accountLogin);

        if (succeededLogin)
        {
            if (returnUrl != null)
                return LocalRedirect(returnUrl);

            if (User.IsInRole("Admin"))
                return LocalRedirect("/AdminArea/Index");

            if (User.IsInRole("Expert"))
                return LocalRedirect("/ExpertArea/Index");

            if (User.IsInRole("Customer"))
                return LocalRedirect("/CustomerArea/Index");
        }

        ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور اشتباه است");
        return Page();
    }
}
