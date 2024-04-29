using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class Suggestion
{
    public int Id { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public Expert Expert { get; set; }
    public int ExpertId { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    [DisplayName("قیمت پیشنهادی")]
    public int Price { get; set; }
    public bool IsAccept { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
