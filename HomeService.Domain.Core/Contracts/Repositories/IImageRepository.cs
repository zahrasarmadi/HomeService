using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IImageRepository
{
    public bool Create(ImageCreateDto imageCreateDto);
    public bool Update(ImageUpdateDto imageUpdateDto);
    public bool Delete(int imageId);
    public Image GetById(int imageId);
    //public List<Image> GetAll();
}
