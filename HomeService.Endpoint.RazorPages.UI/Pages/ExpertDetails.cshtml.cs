using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CommentDTO;
using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Services.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Pages;

public class ExpertDetailsModel : PageModel
{
    private readonly ICommentAppServices _commentAppServices;
    private readonly IExpertAppServices _expertAppServices;

    public ExpertDetailsModel(IExpertAppServices expertAppServices, ICommentAppServices commentAppServices)
    {
        _expertAppServices = expertAppServices;
        _commentAppServices = commentAppServices;
    }

    [BindProperty]
    public ExpertSummaryDto ExpertSummary { get; set; }=new ExpertSummaryDto();

    [BindProperty]
    public CommentCreateDto Comment { get; set; }

    public async Task OnGet(int expertId, CancellationToken cancellationToken)
    {
        ExpertSummary=await _expertAppServices.GetExpertSummary(expertId, cancellationToken);
        TempData["ExpertId"] = expertId;
    }

    public async Task<IActionResult> OnPostAddComment(CommentCreateDto comment, CancellationToken cancellationToken)
    {
        if (User.IsInRole("Customer"))
        {
            comment.CustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
            comment.ExpertId = (int)TempData["ExpertId"];
            
                await _commentAppServices.Create(comment, cancellationToken);
            
        }
        return RedirectToAction("OnGet", new { expertId = (int)TempData["ExpertId"] });
    }

}