using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ISuggestionRepository
{
    public Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int suggestionId, CancellationToken cancellationToken);
    public Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken);
    public Task<List<Suggestion>> GetAll(CancellationToken cancellationToken);
   // private Task<Suggestion> FindSuggestion(int id, CancellationToken cancellationToken);
}
