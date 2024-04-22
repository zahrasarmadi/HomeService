using System.ComponentModel;

namespace HomeService.Domain.Core.Entities;

public class ExpertAddress
{
    public int Id { get; set; }
    public int ExpertId { get; set; }
    public Expert Expert { get; set; }
    [DisplayName("عنوان")]
    public string Title { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    [DisplayName("خیابان")]
    public string Street { get; private set; }
    [DisplayName("منطقه و کوچه و آپارتمان و ...")]
    public string Area { get; set; }
    public string FullAddress { get; set; }
    [DisplayName("کدپستی")]
    public string PostalCode { get; set; }
    [DisplayName("پیش فرض")]
    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public void SetFullAddress()
    {
        FullAddress = City.Name + Street + Area;
    }
}
