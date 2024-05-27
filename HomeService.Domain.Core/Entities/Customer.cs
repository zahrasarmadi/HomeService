using HomeService.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int ApplicationUserId { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    public GenderEnum? Gender { get; set; }
    [MaxLength(11)]
    public string? BackUpPhoneNumber { get; set; }
    [MaxLength(16)]
    public string? BankCardNumber { get; set; }
    public List<Address>? Addresses { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Order>? Orders { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}
