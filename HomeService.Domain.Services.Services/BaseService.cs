using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace HomeService.Domain.Services.Services;

public class BaseService : IBaseSevices
{
    public async Task<string> UploadImage(IFormFile image)
    {
        //if (image != null && image.Length > 0)
        //{
        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        //    var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await image.CopyToAsync(stream);
        //    }
        //    return "/uploads/" + uniqueFileName;
        //}
        //return null;
        string filePath;
        string fileName;
        if (image != null)
        {
            fileName = Guid.NewGuid().ToString() +
                       ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            filePath = Path.Combine("wwwroot/uploads", fileName);
            try
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    await image.CopyToAsync(stream);
                }
            }
            catch
            {
                throw new Exception("Upload files operation failed");
            }
            return $"/uploads/{fileName}";
        }
        else
            fileName = "";

        return fileName;
    }

    public DateTime PersianToGregorian(string persianDateString)
    {
        PersianCalendar pc = new PersianCalendar();
        if (persianDateString.Length > 10)
        {
            string[] separatedTimeAndDate = persianDateString.Split(' ');
            string[] persianDateParts = separatedTimeAndDate[0].Split('/');
            string[] persianTimePart = separatedTimeAndDate[1].Split(':');
            int year1 = int.Parse(persianDateParts[0]);
            int month1 = int.Parse(persianDateParts[1]);
            int day1 = int.Parse(persianDateParts[2]);
            int hour = int.Parse(persianTimePart[0]);
            int minute = int.Parse(persianTimePart[1]);
            int second = int.Parse(persianTimePart[2]);
            return pc.ToDateTime(year1, month1, day1, hour, minute, second, 0);
        }

        string[] persianDateParts1 = persianDateString.Split('/');
        int year = int.Parse(persianDateParts1[0]);
        int month = int.Parse(persianDateParts1[1]);
        int day = int.Parse(persianDateParts1[2]);
        return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
    }
}
