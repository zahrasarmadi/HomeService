using HomeService.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.SubCategoryDTO;

public class GetSubCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ServiceCategory? ServiceCategory { get; set; }
    public int ServiceCategoryId { get; set; }
    public string? Image { get; set; }
}
