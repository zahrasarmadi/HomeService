﻿using HomeService.Domain.Core.Enums;
using System.ComponentModel;

namespace HomeService.Domain.Core.DTOs.AdminDTO;

public class AdminCreateDto
{
    [DisplayName("نام")]
    public string FirstName { get; set; }
    [DisplayName("نام خانوادگی")]
    public string LastName { get; set; }
    [DisplayName("ایمیل")]
    public string Email { get; set; }
    [DisplayName("رمز عبور")]
    public string Password { get; set; }
    [DisplayName("شماره تلفن")]
    public string PhoneNumber { get; set; }
    [DisplayName("جنسیت")]
    public GenderEnum Gender { get; set; }
}