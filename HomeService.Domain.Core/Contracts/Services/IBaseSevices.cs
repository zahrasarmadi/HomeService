using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IBaseSevices
{
    Task<string> UploadImage(IFormFile image);
}
