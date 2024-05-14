using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface IExpertAppServices
{
    Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(ExpertUpdateDto expertUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int expertId, CancellationToken cancellationToken);
    Task<Expert> GetById(int expertId, CancellationToken cancellationToken);
    Task<List<Expert>> GetAll(CancellationToken cancellationToken);
    Task<int> ExpertCount(CancellationToken cancellationToken);
}
