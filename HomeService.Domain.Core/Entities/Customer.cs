using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.Reflection;

namespace HomeService.Domain.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    [DisplayName("نام")]
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
    public string BankCardNumber { get; set; }
    public List<CustomerAddress> Addresses { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Order>? Orders { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.Now;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }= false;
}

