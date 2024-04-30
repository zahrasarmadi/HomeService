using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class CommentCreateDto
{
    public string Title { get; set; }
    [DisplayName("متن کامنت")]
    public string Description { get; set; }
    [DisplayName("رضایت")]
    public float Score { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ExpertId { get; set; }
    public Expert Expert { get; set; }
}