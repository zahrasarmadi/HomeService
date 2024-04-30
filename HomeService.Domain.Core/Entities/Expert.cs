using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class Expert
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string FirstName { get; set; }
    [DisplayName("نام خانوداگی")]
    public string LastName { get; set; }
    [DisplayName("جنسیت")]
    public GenderEnum Gender { get; set; }
    [DisplayName("شماره تلفن")]
    public string PhoneNumber { get; set; }
    [DisplayName("تاریخ تولد")]
    public DateTime BirthDate { get; set; }
    [DisplayName("عکس پروفایل")]
    public Image ProfileImage { get; set; }
    [DisplayName("شماره کارت بانکی")]
    public string BankCardNumber { get; set; }
    public List<Order>? Orders { get; set; }
    public List<Service>? Services { get; set; }
    public List<Suggestion>? Suggestions { get; set; }
    public List<Comment>? Comments { get; set; }
    [DisplayName("آدرس")]
    public Address Address { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.Now;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public bool IsConfrim { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
}