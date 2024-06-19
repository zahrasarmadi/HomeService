﻿using HomeService.Domain.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HomeService.Domain.Core.DTOs.AdminDTO;

public class AdminUpdateDto
{
    public int Id { get; set; }
    [DisplayName("نام")]
    [MaxLength(20, ErrorMessage = "نام نمی‌تواند بیشتر از 50 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "نام نمی‌تواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "نام نمی‌تواند بدون مقدار باشد")]
    public string? FirstName { get; set; }
    [DisplayName("نام خانوادگی")]
    [MaxLength(50, ErrorMessage = "نام خانوادگی نمی‌تواند بیشتر از 50 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "نام خانوادگی نمی‌تواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "نام خانوادگی نمی‌تواند بدون مقدار باشد")]
    public string? LastName { get; set; }
    [DisplayName("ایمیل")]
    [MaxLength(50, ErrorMessage = "ایمیل نمی‌تواند بیشتر از 50 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "ایمیل نمی‌تواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "ایمیل نمی‌تواند بدون مقدار باشد")]
    public string? Email { get; set; }
    [DisplayName("شماره تلفن")]
    [Length(11, 11, ErrorMessage = " شماره تلفن نمی‌تواند کمتر یا بیشتر از 11 کاراکتر باشد")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره تلفن اشتباه است و باید با 09 شروع شود")]
    [Required(ErrorMessage = "شماره تلفن نمی‌تواند بدون مقدار باشد")]
    public string? PhoneNumber { get; set; }
}