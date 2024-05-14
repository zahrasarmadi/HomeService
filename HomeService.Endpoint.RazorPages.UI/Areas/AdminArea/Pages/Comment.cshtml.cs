using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CommentDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

public class CommentModel : PageModel
{
    private readonly ICommentAppServices _commentAppServices;

    public CommentModel(ICommentAppServices commentAppServices)
    {
        _commentAppServices = commentAppServices;
    }

    [BindProperty]
    public List<GetCommentsDto> Comments { get; set; } = new List<GetCommentsDto>();

    public async Task OnGet(CancellationToken cancellationToken)
    {
        Comments = await _commentAppServices.GetAll(cancellationToken);
    }

    public async Task<IActionResult> OnGetReject(int id, CancellationToken cancellationToken)
    {
        await _commentAppServices.RejectComment(id, cancellationToken);
        return RedirectToAction("OnGet");
    }

    public async Task<IActionResult> OnGetAccept(int id, CancellationToken cancellationToken)
    {
        await _commentAppServices.AcceptComment(id, cancellationToken);
        return RedirectToAction("OnGet");
    }

    public async Task<IActionResult> OnGetDelete(int id,CancellationToken cancellationToken)
    {
        await _commentAppServices.Delete(id, cancellationToken);
        return RedirectToAction("OnGet");
    }
}
