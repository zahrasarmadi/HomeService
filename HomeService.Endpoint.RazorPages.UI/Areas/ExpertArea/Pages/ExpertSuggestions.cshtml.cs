using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.ExpertArea.Pages;

[Authorize(Roles = "Expert")]
public class ExpertSuggestionsModel : PageModel
{
    private readonly ISuggestionAppServices _suggestionAppServices;
    private readonly IOrderAppServices _orderAppServices;

    public ExpertSuggestionsModel(ISuggestionAppServices suggestionAppServices, IOrderAppServices orderAppServices)
    {
        _suggestionAppServices = suggestionAppServices;
        _orderAppServices = orderAppServices;
    }

    [BindProperty]
    public List<SuggestionsByExpertIdDto> Suggestions { get; set; } = new List<SuggestionsByExpertIdDto>();


    public async Task OnGet(CancellationToken cancellationToken)
    {
        var expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
        Suggestions = await _suggestionAppServices.GetSuggestionsByExperId(expertId, cancellationToken);
    }

    public async Task OnGetDoneOrder(int suggestionId, int orderId, CancellationToken cancellationToken)
    {
        await _orderAppServices.DoneOrder(orderId, suggestionId, cancellationToken);
    }
}