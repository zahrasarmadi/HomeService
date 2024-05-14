using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Service
{
    public int Id { get; set; }
    //[MaxLength(100)]
    public string Name { get; set; }
    public ServiceSubCategory? ServiceSubCategory { get; set; }
    public int ServiceSubCategoryId { get; set; }
    public List<Expert>? Experts { get; set; }
    public List<Order>? Orders { get; set; }
    public string? Image { get; set; }
    public int Price { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}