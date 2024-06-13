using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.CustomerDTO;

public class CustomerSummaryDto
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    public GenderEnum? Gender { get; set; }
    [MaxLength(11)]
    public string BackUpPhoneNumber { get; set; }
    [MaxLength(16)]
    public string? BankCardNumber { get; set; }
    public Address? Address { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Order>? Orders { get; set; }
}
