using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IBaseAppServices
{
    Task<string> UploadImage(IFormFile image);
}
