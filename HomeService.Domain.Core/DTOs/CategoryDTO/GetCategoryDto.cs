using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.DTOs.CategoryDTO;

public class GetCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public bool IsDeleted { get; set; }
}
