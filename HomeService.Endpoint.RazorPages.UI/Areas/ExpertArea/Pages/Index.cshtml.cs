using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.ExpertArea.Pages;

[Authorize(Roles = "Expert")]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
