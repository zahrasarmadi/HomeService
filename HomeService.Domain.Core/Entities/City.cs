using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class City
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}