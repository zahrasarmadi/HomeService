using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CommentDTO;
using HomeService.Endpoint.RazorPages.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.AdminArea.Pages;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly ICommentAppServices _commentAppServices;
    private readonly ICustomerAppServices _customerAppServices;
    private readonly IOrderAppServices _orderAppServices;
    private readonly IExpertAppServices _expertAppServices;

    public IndexModel(ICommentAppServices commentAppServices, ICustomerAppServices customerAppServices, IOrderAppServices orderAppServices, IExpertAppServices expertAppServices)
    {
        _commentAppServices = commentAppServices;
        _customerAppServices = customerAppServices;
        _orderAppServices = orderAppServices;
        _expertAppServices = expertAppServices;
    }

    [BindProperty]
    public List<RecentCommentDto> ResentComment { get; set; }

    [BindProperty]
    public CountViewModel CountViewModel { get; set; } = new CountViewModel();

    public async Task OnGet(CancellationToken cancellationToken)
    {
        ResentComment = await _commentAppServices.GetRecentComments(cancellationToken);
        CountViewModel.ExpertCount = await _expertAppServices.ExpertCount(cancellationToken);
        CountViewModel.CommentCount = await _commentAppServices.CommentCount(cancellationToken);
        CountViewModel.CommentCount =  await _orderAppServices.OrderCount(cancellationToken);
        CountViewModel.CustomerCount = await _orderAppServices.OrderCount(cancellationToken);
    }
}
