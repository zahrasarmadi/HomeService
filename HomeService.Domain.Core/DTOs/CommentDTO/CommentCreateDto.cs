using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs.CommentDTO;

public class CommentCreateDto
{
    public string Title { get; set; }
    [DisplayName("متن کامنت")]
    public string Description { get; set; }
    [DisplayName("رضایت")]
    public int Score { get; set; }
    public int CustomerId { get; set; }
    public int ExpertId { get; set; }
}