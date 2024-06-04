using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs.ExpertDTO;

public class ExpertUpdateInfoDto
{
    public int Id { get; set; }
    //public ApplicationUser ApplicationUser { get; set; }
    // public int ApplicationUserId { get; set; }
    [MaxLength(20)]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    public string? LastName { get; set; }
    public GenderEnum? Gender { get; set; }
    [MaxLength(11)]
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? ProfileImage { get; set; }
   // [MaxLength(16)]
   // public string BankCardNumber { get; set; }
    public List<Service>? Services { get; set; }
    //[DisplayName("آدرس")]
    //public Address Address { get; set; }
}
