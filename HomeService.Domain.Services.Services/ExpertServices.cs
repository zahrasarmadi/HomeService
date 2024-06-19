using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.Services;

public class ExpertServices : IExpertServices
{
    private readonly IExpertRepository _expertRepository;

    public ExpertServices(IExpertRepository expertRepository)
    {
        _expertRepository = expertRepository;
    }

    public async Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken)
      => await _expertRepository.Create(expertCreateDto, cancellationToken);

    public async Task<bool> Delete(int expertId, CancellationToken cancellationToken)
      => await _expertRepository.Delete(expertId, cancellationToken);

    public async Task<int> ExpertAverageScores(int id, CancellationToken cancellationToken)
      => await _expertRepository.ExpertAverageScores(id, cancellationToken);

    public async Task<int> ExpertCommentCount(int id, CancellationToken cancellationToken)
      => await _expertRepository.ExpertCommentCount(id, cancellationToken);

    public async Task<int> ExpertCount(CancellationToken cancellationToken)
      => await _expertRepository.ExpertCount(cancellationToken);

    public async Task<int> ExpertOrderCount(int id, CancellationToken cancellationToken)
      => await _expertRepository.ExpertOrderCount(id, cancellationToken);

    public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
      => await _expertRepository.GetAll(cancellationToken);

    public async Task<Expert> GetById(int expertId, CancellationToken cancellationToken)
      => await _expertRepository.GetById(expertId, cancellationToken);

    public async Task<ExpertNameDto> GetExpertName(int id, CancellationToken cancellationToken)
      => await _expertRepository.GetExpertName(id, cancellationToken);

    public async Task<List<int>> GetExpertServiceIds(int id, CancellationToken cancellationToken)
      => await _expertRepository.GetExpertServiceIds(id, cancellationToken);

    public async Task<ExpertSummaryDto> GetExpertSummary(int id, CancellationToken cancellationToken)
      => await _expertRepository.GetExpertSummary(id, cancellationToken);

    public async Task<ExpertUpdateDto> GetExpertUpdateInfo(int id, CancellationToken cancellationToken)
      => await _expertRepository.GetExpertUpdateInfo(id, cancellationToken);

    public async Task<bool> Update(ExpertUpdateDto expertUpdateDto, CancellationToken cancellationToken)
      => await _expertRepository.Update(expertUpdateDto, cancellationToken);
}
