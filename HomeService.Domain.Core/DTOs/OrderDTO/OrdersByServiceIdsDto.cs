﻿using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs.OrderDTO;

public class OrdersByServiceIdsDto
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }
    [DisplayName("عکس")]
    public string? Image { get; set; }
}
