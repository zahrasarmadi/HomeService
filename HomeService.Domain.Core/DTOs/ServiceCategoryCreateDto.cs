using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class ServiceCategoryCreateDto
{
    [DisplayName("نام")]
    public string Name { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public List<ServiceSubCategory> ServiceSubCategories { get; set; }
    public Image Image { get; set; }
}