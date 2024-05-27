﻿using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs.OrderDTO;

public class OrderCreateDto
{
    [DisplayName("عنوان")]
    public string Title { get; set; }
    [DisplayName("توضیحات")]
    public string Description { get; set; }
    [DisplayName("وضعیت")]
    public int CustomerId { get; set; }
    public int ServiceId { get; set; }
    [DisplayName("عکس ها")]
    public string? Image { get; set; }
    public DateTime Date { get; set; }
}