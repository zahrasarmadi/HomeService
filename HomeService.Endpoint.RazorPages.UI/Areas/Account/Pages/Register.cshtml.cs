﻿using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.AccountDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.Account.Pages;

public class RegisterModel : PageModel
{
    private readonly IAccountAppServices _accountAppServices;

    public RegisterModel(IAccountAppServices accountAppServices)
    {
        _accountAppServices = accountAppServices;
    }

    [BindProperty]
    public AccountRegisterDto AccountRegister { get; set; }


    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(AccountRegisterDto accountRegister, string returnUrl = null)
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _accountAppServices.Register(accountRegister);

        if (result.Count == 0)
        {
            if (returnUrl != null)
                return LocalRedirect(returnUrl);

            returnUrl = Url.Content("~/Account/Login");
            return LocalRedirect(returnUrl);
        }

        foreach (var error in result)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return Page();
    }
}
