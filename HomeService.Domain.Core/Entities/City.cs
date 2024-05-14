﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class City
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public List<Address>? Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}