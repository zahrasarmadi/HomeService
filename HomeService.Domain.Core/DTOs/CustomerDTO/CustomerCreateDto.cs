using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs.CustomerDTO;

public class CustomerCreateDto
{
    public string FirstName { get; set; }
    [DisplayName("نام خانوادگی")]
    public string LastName { get; set; }
    [DisplayName("جنسیت")]
    public GenderEnum? Gender { get; set; }
    [DisplayName("شماره تلفن")]
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
}