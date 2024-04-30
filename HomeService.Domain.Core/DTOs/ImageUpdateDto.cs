using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class ImageUpdateDto
{
    public int Id { get; set; }
    [DisplayName("توضیحات عکس")]
    public string? Alt { get; set; }
    [DisplayName("آدرس تصویر")]
    public string ImageAddress { get; set; }
    public Expert? Expert { get; set; }
    public int? ExpertId { get; set; }
    public Order? Order { get; set; }
    public int OrderId { get; set; }
    public Service? Service { get; set; }
    public int? ServiceId { get; set; }
    public ServiceCategory? ServiceCategory { get; set; }
    public int? ServiceCategoryId { get; set; }
    public ServiceSubCategory? ServiceSubCategory { get; set; }
    public int? ServiceSubCategoryId { get; set; }
}