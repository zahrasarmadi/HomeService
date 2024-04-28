using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class Image
{
    public int Id { get; set; }
    [DisplayName("توضیحات عکس")]
    public string? Alt { get; set; }
    [DisplayName("آدرس تصویر")]
    public string ImageAddress { get; set; }
    public Expert Expert { get; set; }
    public int ExpertId { get; set; }
    public Order Order { get; set; }
    public int RequestId { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    public int ServiceCategoryId { get; set; }
    public ServiceSubCategory ServiceSubCategory { get; set; }
    public int ServiceSubCategoryId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}