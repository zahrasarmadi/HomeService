using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.ExpertArea.Pages;

[Authorize(Roles = "Expert")]
public class AddSuggestionModel : PageModel
{
    private readonly ISuggestionAppServices _suggestionAppServices;

    public AddSuggestionModel(ISuggestionAppServices suggestionAppServices)
    {
        _suggestionAppServices = suggestionAppServices;
    }

    [BindProperty]
    public SuggestionCreateDto SuggestionCreate { get; set; }

    [BindProperty]
    public string SuggestionDate { get; set; }

    [BindProperty]
    public int OrderId { get; set; }

    public async Task OnGet(int Id,CancellationToken cancellationToken)
    {
        OrderId = Id;
    }

    public async Task<IActionResult> OnPostCreateSuggestion(SuggestionCreateDto suggestionCreate, string suggestionDate, CancellationToken cancellationToken)
    {
        var expertId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
        suggestionCreate.ExpertId = expertId;
        await _suggestionAppServices.Create(suggestionCreate,suggestionDate,cancellationToken);

        return RedirectToPage("ExpertSuggestions");
    }
}
