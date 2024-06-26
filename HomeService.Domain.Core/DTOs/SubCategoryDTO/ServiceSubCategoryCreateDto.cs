﻿using HomeService.Domain.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.SubCategoryDTO;

public class ServiceSubCategoryCreateDto
{
    [DisplayName("نام دسته بندی")]
    [MaxLength(100, ErrorMessage = "نام دسته بندی نمیتواند بیشتر از 100 کاراکتر باشد")]
    [MinLength(3, ErrorMessage = "نام دسته بندی نمیتواند کمتر از 3 کاراکتر باشد")]
    [Required(ErrorMessage = "وارد کردن نام دسته بندی اجباری است.")]
    public string Name { get; set; }
    public int ServiceCategoryId { get; set; }
    public string? Image { get; set; }
}