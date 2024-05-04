using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IExpertRepository
{
    public Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(ExpertUpdateDto expertUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int expertId, CancellationToken cancellationToken);
    public Task<Expert> GetById(int expertId, CancellationToken cancellationToken);
    public Task<List<Expert>> GetAll( CancellationToken cancellationToken);
}
