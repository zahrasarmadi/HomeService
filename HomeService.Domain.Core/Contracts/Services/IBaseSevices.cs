using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IBaseSevices
{
    DateTime PersianToGregorian(string persianDateString);
    Task<string> UploadImage(IFormFile image);
}
