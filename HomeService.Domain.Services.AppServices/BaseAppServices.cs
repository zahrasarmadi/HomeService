using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.AppServices;

public class BaseAppServices : IBaseAppServices
{
    private readonly IBaseSevices _baseSevices;

    public BaseAppServices(IBaseSevices baseSevices)
    {
        _baseSevices = baseSevices;
    }

    public async Task<string> UploadImage(IFormFile image)
      =>await _baseSevices.UploadImage(image);
}
