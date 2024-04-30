using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class OrderCreateDto
{
    [DisplayName("عنوان")]
    public string Title { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    [DisplayName("وضعیت")]
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }

    public Service Service { get; set; }
    public int ServiceId { get; set; }
    [DisplayName("عکس ها")]
    public List<Image>? Images { get; set; }
}