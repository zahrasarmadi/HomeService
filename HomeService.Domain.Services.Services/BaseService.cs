using HomeService.Domain.Core.Contracts.Services;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace HomeService.Domain.Services.Services;

public class BaseService : IBaseSevices
{
    public async Task<string> UploadImage(IFormFile image)
    {
        string filePath;

        if (image != null && image.Length > 0)
        {
            filePath =@"E:\Project\HomeService\HomeService.Endpoint.RazorPages.UI\wwwroot\uploads\"+ image.FileName;
             using (var stream = new FileStream(filePath, FileMode.Create))
            {
               await image.CopyToAsync(stream);
            }
            return filePath;
        }
        return null;
    }
}
