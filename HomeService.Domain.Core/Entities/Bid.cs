using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class Bid
{
    public int Id { get; set; }
    [DisplayName("عنوان")]
    public string Title { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    [DisplayName("وضعیت")]
    public StatusEnum Status { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public Expert Expert { get; set; }
    public int EmployeeId { get; set; }
    [DisplayName("عکس ها")]
    public List<Image> Images { get; set; }
    public bool IsDeleted { get; set; }=false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime RequestedAt { get; set; } = DateTime.Now;
    public DateTime DoneAt { get; set; }
}