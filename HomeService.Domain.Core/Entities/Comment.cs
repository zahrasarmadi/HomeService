﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Entities;

public class Comment
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public int Score { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ExpertId { get; set; }
    public Expert Expert { get; set; }
    public bool IsAccept { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}