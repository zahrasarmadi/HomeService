using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class SuggestionAppServices : ISuggestionAppServices
{
    private readonly ISuggestionServices _suggestionServices;

    public SuggestionAppServices(ISuggestionServices suggestionServices)
    {
        _suggestionServices = suggestionServices;
    }

    public async Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken)
      => await _suggestionServices.Create(suggestionCreateDto, cancellationToken);

    public async Task<bool> Delete(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionServices.Delete(suggestionId, cancellationToken);

    public async Task<List<Suggestion>> GetAll(CancellationToken cancellationToken)
      => await _suggestionServices.GetAll(cancellationToken);

    public async Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionServices.GetById(suggestionId, cancellationToken);

    public async Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken)
      => await _suggestionServices.Update(suggestionUpdateDto, cancellationToken);
}
