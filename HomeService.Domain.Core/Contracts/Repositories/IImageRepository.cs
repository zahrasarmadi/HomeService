using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IImageRepository
{
    public Task<bool> Create(ImageCreateDto imageCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(ImageUpdateDto imageUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int imageId, CancellationToken cancellationToken);
    public Task<Image> GetById(int imageId, CancellationToken cancellationToken);
    //public Task<List<Image>> GetAll( CancellationToken cancellationToken);
}
