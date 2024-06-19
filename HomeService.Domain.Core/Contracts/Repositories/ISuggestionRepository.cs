using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ISuggestionRepository
{
    Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int suggestionId, CancellationToken cancellationToken);
    Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken);
    Task<List<Suggestion>> GetAll(CancellationToken cancellationToken);
    Task AcceptSuggestion(int id, CancellationToken cancellationToken);
    Task<int> ConfrimedStatusCount(int orderId, CancellationToken cancellationToken);
    Task<List<SuggestionsByExpertIdDto>> GetSuggestionsByExperId(int id, CancellationToken cancellationToken);
    Task DoneSuggestion(int id, CancellationToken cancellationToken);
    Task<bool> ChangeStatus(StatusEnum status, int suggetionId, CancellationToken cancellationToken);
}
