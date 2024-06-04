using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IExpertRepository
{
    Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int expertId, CancellationToken cancellationToken);
    Task<Expert> GetById(int expertId, CancellationToken cancellationToken);
    Task<List<Expert>> GetAll(CancellationToken cancellationToken);
    Task<int> ExpertCount(CancellationToken cancellationToken);
    Task<ExpertSummaryDto> GetExpertSummary(int id, CancellationToken cancellationToken);
	Task<int> ExpertCommentCount(int id, CancellationToken cancellationToken);
	Task<int> ExpertAverageScores(int id, CancellationToken cancellationToken);
	Task<int> ExpertOrderCount(int id, CancellationToken cancellationToken);
    Task<List<int>> GetExpertServiceIds(int id, CancellationToken cancellationToken);
    Task<ExpertUpdateDto> GetExpertUpdateInfo(int id, CancellationToken cancellationToken);
    Task<bool> Update(ExpertUpdateDto expertUpdateDto, CancellationToken cancellationToken);
}
