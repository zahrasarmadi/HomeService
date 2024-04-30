using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class SuggestionCreateDto
{
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public Expert Expert { get; set; }
    public int ExpertId { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    [DisplayName("قیمت پیشنهادی")]
    public int Price { get; set; }
}