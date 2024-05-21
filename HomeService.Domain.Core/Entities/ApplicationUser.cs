using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class ApplicationUser : IdentityUser<int>
{
	public Admin? Admin { get; set; }
	public int? AdminId { get; set; }
	public Customer? Customer { get; set; }
	public int? CustomerId { get; set; }
	public Expert? Expert { get; set; }
	public int? ExpertId { get; set; }
}
