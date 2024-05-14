using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.DTOs.CommentDTO;

public class RecentCommentDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Expert Expert { get; set; }
    public int Score { get; set; }
    public DateTime CreateAt { get; set; }
}
