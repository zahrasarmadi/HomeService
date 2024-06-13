using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.OrderDTO;

public class OrderCreateDto
{
    [DisplayName("عنوان")]
    [MaxLength(50, ErrorMessage = "عنوان نمی‌تواند بیشتر از 50 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "عنوان نمی‌تواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "عنوان نمی‌تواند بدون مقدار باشد")]
    public string? Title { get; set; }
    [DisplayName("توضیحات")]
    [MaxLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیشتر از 1000 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "توضیحات نمی‌تواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "توضیحات نمی‌تواند بدون مقدار باشد")]
    public string? Description { get; set; }
    public int CustomerId { get; set; }
    public int ServiceId { get; set; }
    [DisplayName("عکس ها")]
    public string? Image { get; set; }
    public DateTime Date { get; set; }
}