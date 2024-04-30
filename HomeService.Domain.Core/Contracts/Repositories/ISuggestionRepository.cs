using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ISuggestionRepository
{
    public bool Create(SuggestionCreateDto suggestionCreateDto);
    public bool Update(SuggestionUpdateDto suggestionUpdateDto);
    public bool Delete(int suggestionId);
    public Suggestion GetById(int suggestionId);
    public List<Suggestion> GetAll();
}
