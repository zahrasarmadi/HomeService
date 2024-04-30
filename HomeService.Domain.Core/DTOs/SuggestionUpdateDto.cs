using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class SuggestionUpdateDto
{
    public int Id { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    [DisplayName("قیمت پیشنهادی")]
    public int Price { get; set; }
}