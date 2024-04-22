using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class ServiceCategory
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string Name { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public List<ServiceSubCategory> ServiceSubCategories { get; set; }
    public bool IsDeleted { get; set; }=false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}