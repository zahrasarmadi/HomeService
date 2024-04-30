using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class CustomerUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    [DisplayName("نام خانوادگی")]
    public string LastName { get; set; }
    [DisplayName("جنسیت")]
    public GenderEnum? Gender { get; set; }
    [DisplayName("شماره تلفن")]
    public string PhoneNumber { get; set; }
    [DisplayName("شماره تلفن ذخیره")]
    public string BackUpPhoneNumber { get; set; }
    [DisplayName("شماره کارت بانکی")]
    public string? BankCardNumber { get; set; }
}