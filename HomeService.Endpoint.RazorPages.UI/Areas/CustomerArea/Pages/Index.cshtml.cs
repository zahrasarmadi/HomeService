using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoint.RazorPages.UI.Areas.CustomerArea
{
    [Authorize(Roles = "Customer")]
    public class IndexModel : PageModel
    {
        private readonly ICustomerAppServices _customerAppServices;
        public IndexModel(ICustomerAppServices customerAppServices)
        {
            _customerAppServices = customerAppServices;
        }

        [BindProperty]
        public CustomerSummaryDto CustomerSummary { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.First().Value);

            CustomerSummary = await _customerAppServices.GetCustomerSummary(userId, cancellationToken);
        }
    }
}