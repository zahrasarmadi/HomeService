using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class Image
{
    public int Id { get; set; }
    [DisplayName("توضیحات عکس")]
    public string? Alt { get; set; }
    [DisplayName("آدرس تصویر")]
    public string ImageAddress { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}