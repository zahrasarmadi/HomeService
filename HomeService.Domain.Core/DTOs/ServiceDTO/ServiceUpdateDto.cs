using HomeService.Domain.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.ServiceDTO;

public class ServiceUpdateDto
{
    public int Id { get; set; }
    [DisplayName("نام سرویس")]
    //[MaxLength(100, ErrorMessage = "نام سرویس نمیتواند بیشتر از 100 کاراکتر باشد")]
    //[MinLength(10, ErrorMessage = "نام سرویس نمیتواند کمتر از 10 کاراکتر باشد")]
    //[Required(ErrorMessage = "وارد کردن نام سرویس اجباری است.")]
    public string Name { get; set; }
    [DisplayName("قیمت")]
    //[MaxLength(8, ErrorMessage = "قیمت نمیتواند بیشتر از 8 کاراکتر باشد")]
    //[MinLength(5, ErrorMessage = "قیمت نمیتواند کمتر از 5 کاراکتر باشد")]
    //[Required(ErrorMessage = "وارد کردن قیمت اجباری است.")]
    public int Price { get; set; }
}