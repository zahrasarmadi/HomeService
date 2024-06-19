using HomeService.Domain.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.CategoryDTO;

public class ServiceCategoryCreateDto
{

    [DisplayName("نام دسته بندی اصلی")]
    [MaxLength(100, ErrorMessage = "نام دسته بندی نمیتواند بیشتر از 100 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "نام دسته بندی نمیتواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "نام دسته بندی نمی‌تواند بدون مقدار باشد")]
    public string Name { get; set; }
    public string? Image { get; set; }
}