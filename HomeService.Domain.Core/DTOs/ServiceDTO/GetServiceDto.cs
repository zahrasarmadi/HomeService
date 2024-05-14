using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.DTOs.ServiceDTO;

public class GetServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ServiceSubCategory? ServiceSubCategory { get; set; }
    public int ServiceSubCategoryId { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public bool IsDeleted { get; set; }
}
