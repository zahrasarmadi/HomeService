using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class Comment
{
    public int Id { get; set; }
    [DisplayName("عنوان")]
    public string Title { get; set; }
    [DisplayName("متن کامنت")]
    public string Description { get; set; }
    [DisplayName("نمره")]
    public float Score { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ExpertId { get; set; }
    public Expert Expert { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}