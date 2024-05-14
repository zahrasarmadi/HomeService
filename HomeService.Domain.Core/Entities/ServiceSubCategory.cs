using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class ServiceSubCategory
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public ServiceCategory? ServiceCategory { get; set; }
    public int ServiceCategoryId { get; set; }
    public List<Service>? Services { get; set; }
   public string? Image { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
