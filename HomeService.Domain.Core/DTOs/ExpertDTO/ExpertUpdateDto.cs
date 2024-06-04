using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HomeService.Domain.Core.DTOs.ExpertDTO;

public class ExpertUpdateDto
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string FirstName { get; set; }
    [DisplayName("نام خانوداگی")]
    public string LastName { get; set; }
    //[DisplayName("جنسیت")]
    //public GenderEnum? Gender { get; set; }
    [DisplayName("شماره تلفن")]
    public string PhoneNumber { get; set; }
    [DisplayName("تاریخ تولد")]
    public DateTime? BirthDate { get; set; }
    [DisplayName("عکس پروفایل")]
    public string? ProfileImage { get; set; }
    public List<int> ServiceIds { get; set; }
    // [DisplayName("شماره کارت بانکی")]
    //  public string BankCardNumber { get; set; }
    // [DisplayName("آدرس")]
    // public Address Address { get; set; }

}