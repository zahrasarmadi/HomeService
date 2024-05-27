using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Suggestion
{
    public int Id { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public Expert Expert { get; set; }
    public int ExpertId { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public int Price { get; set; }
    public DateTime SuggestedDate { get; set; }
    public int Status { get; set; } 
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
