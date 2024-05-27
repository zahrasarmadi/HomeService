﻿using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Services;

public interface IExpertServices
{
	Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken);
	Task<bool> Update(ExpertUpdateDto expertUpdateDto, CancellationToken cancellationToken);
	Task<bool> Delete(int expertId, CancellationToken cancellationToken);
	Task<Expert> GetById(int expertId, CancellationToken cancellationToken);
	Task<List<Expert>> GetAll(CancellationToken cancellationToken);
	Task<int> ExpertCount(CancellationToken cancellationToken);
	Task<ExpertSummaryDto> GetExpertSummary(int id, CancellationToken cancellationToken);
	Task<int> ExpertCommentCount(int id, CancellationToken cancellationToken);
	Task<int> ExpertAverageScores(int id, CancellationToken cancellationToken);
	Task<int> ExpertOrderCount(int id, CancellationToken cancellationToken);
}
