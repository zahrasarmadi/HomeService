﻿using HomeService.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.SubCategoryDTO;

public class GetByCategoryIdDto
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public string? Image { get; set; }
}
