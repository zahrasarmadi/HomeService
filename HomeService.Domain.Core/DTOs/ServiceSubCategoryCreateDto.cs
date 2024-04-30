using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class ServiceSubCategoryCreateDto
{
    public string Name { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    public int ServiceCategoryId { get; set; }
    public List<Service> Services { get; set; }
    public Image Image { get; set; }
}