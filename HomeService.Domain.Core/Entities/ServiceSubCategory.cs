using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class ServiceSubCategory
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string Name { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    public int ServiceCategoryId { get; set; }
    public List<Service> Services { get; set; }
    public Image Image { get; set; }
  //  public int ImageId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
