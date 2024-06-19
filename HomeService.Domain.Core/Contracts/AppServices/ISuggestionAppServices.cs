using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface ISuggestionAppServices
{
    Task<bool> Create(SuggestionCreateDto suggestionCreateDto, string suggestionDate, CancellationToken cancellationToken);
    Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int suggestionId, CancellationToken cancellationToken);
    Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken);
    Task<List<Suggestion>> GetAll(CancellationToken cancellationToken);
    Task<bool> AcceptSuggestion(int id, int orderid, CancellationToken cancellationToken);
    Task<List<SuggestionsByExpertIdDto>> GetSuggestionsByExperId(int id, CancellationToken cancellationToken);
    Task<bool> ChangeStatus(StatusEnum status, int orderId, CancellationToken cancellationToken);
}
