using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Admin
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(20)]
    public string Password { get; set; }
    [MaxLength(11)]
    public string PhoneNumber { get; set; }
    public GenderEnum Gender { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
