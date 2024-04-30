using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class ServiceCreateDto
{
    [DisplayName("نام سرویس")]
    public string Name { get; set; }
    public ServiceSubCategory ServiceSubCategory { get; set; }
    public int SubCategoryId { get; set; }
    public List<Expert>? Experts { get; set; }
    public List<Order>? Orders { get; set; }
    public Image Image { get; set; }
    [DisplayName("قیمت")]
    public int Price { get; set; }
}