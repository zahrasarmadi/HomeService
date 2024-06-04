using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class SuggestionServices : ISuggestionServices
{
    private readonly ISuggestionRepository _suggestionRepository;

    public SuggestionServices(ISuggestionRepository suggestionRepository)
    {
        _suggestionRepository = suggestionRepository;
    }

    public async Task AcceptSuggestion(int id, CancellationToken cancellationToken)
      => await _suggestionRepository.AcceptSuggestion(id, cancellationToken);

    public async Task<int> ConfrimedStatusCount(int orderId, CancellationToken cancellationToken)
      => await _suggestionRepository.ConfrimedStatusCount(orderId, cancellationToken);

    public async Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken)
      => await _suggestionRepository.Create(suggestionCreateDto, cancellationToken);

    public async Task<bool> Delete(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionRepository.Delete(suggestionId, cancellationToken);

    public async Task DoneSuggestion(int id, CancellationToken cancellationToken)
      => await _suggestionRepository.DoneSuggestion(id, cancellationToken);

    public async Task<List<Suggestion>> GetAll(CancellationToken cancellationToken)
      => await _suggestionRepository.GetAll(cancellationToken);

    public async Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionRepository.GetById(suggestionId, cancellationToken);

    public async Task<List<SuggestionsByExpertIdDto>> GetSuggestionsByExperId(int id, CancellationToken cancellationToken)
      => await _suggestionRepository.GetSuggestionsByExperId(id, cancellationToken);

    public async Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken)
      => await _suggestionRepository.Update(suggestionUpdateDto, cancellationToken);


}
