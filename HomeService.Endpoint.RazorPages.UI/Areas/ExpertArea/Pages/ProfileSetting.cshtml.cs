using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeService.Framework;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Endpoint.RazorPages.UI.Areas.ExpertArea.Pages;

[Authorize(Roles = "Expert")]
public class ProfileSettingModel : PageModel
{
    private readonly IExpertAppServices _expertAppServices;
    private readonly IServiceAppServices _serviceAppServices;

    public ProfileSettingModel(IExpertAppServices expertAppServices, IServiceAppServices serviceAppServices)
    {
        _expertAppServices = expertAppServices;
        _serviceAppServices = serviceAppServices;
    }

    [BindProperty]
    public ExpertUpdateDto ExpertUpdate { get; set; }

    [BindProperty]
    public IFormFile? Image { get; set; }

    [BindProperty]
    public List<int> ServiceIds { get; set; }

    [BindProperty]
    public List<ServicesNameDto> ServicesNames { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "تاریخ تولد نمی‌تواند بدون مقدار باشد")]
    [RegularExpression("^(\\d{4})/(\\d{2})/(\\d{2})$", ErrorMessage = "فرمت تاریخ باید به صورت yyyy/mm/dd باشد.")]
    [Length(10, 10, ErrorMessage = "تاریخ نمی‌تواند کمتر یا بیشتر از 10 کاراکتر باشد")]
    public string BirthDate { get; set; }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        var expertId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
        ExpertUpdate = await _expertAppServices.GetExpertUpdateInfo(expertId, cancellationToken);
        ServicesNames = await _serviceAppServices.GetServicesName(cancellationToken);
        var stringBirthDate = ExpertUpdate.BirthDate.ToString();
        var birthDate = DateTime.Parse(stringBirthDate);
        BirthDate = birthDate.ToPersianString("yyyy/MM/dd");
    }

    public async Task<IActionResult> OnPostUpdateProfile(ExpertUpdateDto expertUpdate, string birthDate, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var expertId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
            expertUpdate.Id = expertId;
            await _expertAppServices.Update(expertUpdate, Image, birthDate, cancellationToken);
            return RedirectToAction("OnGet");
        }
        return RedirectToAction("OnGet");
    }
}