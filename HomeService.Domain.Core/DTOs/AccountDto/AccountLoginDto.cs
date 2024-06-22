﻿using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.DTOs.AccountDto;

public class AccountLoginDto
{
    [Required(ErrorMessage = "وارد کردن رمزعبور اجباری است")]
    [MinLength(4, ErrorMessage = "رمزعبور نمی‌تواند کمتر 4 کاراکتر باشد")]
    public string Password { get; set; }
    [Required(ErrorMessage = "وارد کردن ایمیل اجباری است")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است")]
    [Length(10, 50, ErrorMessage = "ایمیل نمی‌تواند کمتر 10 و بیشتر از 50 کاراکتر باشد")]
    public string Email { get; set; }
}
