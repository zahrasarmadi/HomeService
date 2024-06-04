using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.SuggestionDTO;

public class SuggestionCreateDto
{
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    public int ExpertId { get; set; }
    public int OrderId { get; set; }
    [DisplayName("قیمت پیشنهادی")]
    public int Price { get; set; }
    public DateTime SuggastionDate { get; set; }
}