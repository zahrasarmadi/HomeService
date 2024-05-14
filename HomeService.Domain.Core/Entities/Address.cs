using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Address
{
    public Address()
    {
        //SetFullAddress();
        FullAddress = City.Name + Street + Area;
    }
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int? ExpertId { get; set; }
    public Expert? Expert { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    public int CityId { get; set; }
    [MaxLength(50)]
    public City? City { get; set; }
    [MaxLength(50)]
    public string Street { get; set; }
    [MaxLength(500)]
    public string Area { get; set; }
    [MaxLength(1000)]
    public string? FullAddress { get; private set; }
    [MaxLength(10)]
    public string PostalCode { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    //public void SetFullAddress()
    //{
    //    FullAddress = City.Name + Street + Area;
    //}
}