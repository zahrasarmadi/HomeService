using HomeService.Domain.Core.Entities;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs;

public class CommentUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    [DisplayName("متن کامنت")]
    public string Description { get; set; }
    [DisplayName("رضایت")]
    public float Score { get; set; }
}