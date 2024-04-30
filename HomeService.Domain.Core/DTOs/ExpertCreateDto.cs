using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class ExpertCreateDto
{
    [DisplayName("نام")]
    public string FirstName { get; set; }
    [DisplayName("نام خانوداگی")]
    public string LastName { get; set; }
    [DisplayName("جنسیت")]
    public GenderEnum Gender { get; set; }
    [DisplayName("شماره تلفن")]
    public string PhoneNumber { get; set; }
    [DisplayName("تاریخ تولد")]
    public string BirthDate { get; set; }
    [DisplayName("عکس پروفایل")]
    public Image ProfileImage { get; set; }
    [DisplayName("شماره کارت بانکی")]
    public string BankCardNumber { get; set; }
    public List<Service> Services { get; set; }
    [DisplayName("آدرس")]
    public Address Address { get; set; }
}