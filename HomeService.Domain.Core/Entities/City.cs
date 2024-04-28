using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class City
{
    public int Id { get; set; }
    [DisplayName("نام")]
    public string Name { get; set; }
    public List<CustomerAddress> CustomerAddress { get; set; }
    public List<ExpertAddress> ExpertAddress { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}