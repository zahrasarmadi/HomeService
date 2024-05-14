using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface ISuggestionAppServices
{
    Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int suggestionId, CancellationToken cancellationToken);
    Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken);
    Task<List<Suggestion>> GetAll(CancellationToken cancellationToken);
}
