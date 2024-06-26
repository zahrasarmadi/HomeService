﻿using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Order
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public List<Suggestion>? Suggestions  { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }
    [DisplayName("عکس")]
    public string? Image { get; set; }
    public bool IsDeleted { get; set; }=false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime RequesteForTime { get; set; } = DateTime.Now;
    public DateTime? DoneAt { get; set; }
}