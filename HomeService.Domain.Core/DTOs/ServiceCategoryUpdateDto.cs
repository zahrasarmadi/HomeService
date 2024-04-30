using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class ServiceCategoryUpdateDto
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string Name { get; set; }
    public List<ServiceSubCategory> ServiceSubCategories { get; set; }
    public Image Image { get; set; }
}