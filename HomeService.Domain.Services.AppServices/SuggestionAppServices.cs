using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class SuggestionAppServices : ISuggestionAppServices
{
    private readonly ISuggestionServices _suggestionServices;
    private readonly IOrderServices _orderServices;

    public SuggestionAppServices(ISuggestionServices suggestionServices, IOrderServices orderServices)
    {
        _suggestionServices = suggestionServices;
        _orderServices = orderServices;
    }

    public async Task<bool> AcceptSuggestion(int id, int orderid, CancellationToken cancellationToken)
    {
        var confrimedCount = await _suggestionServices.ConfrimedStatusCount(orderid, cancellationToken);

        if (confrimedCount == 0)
        {
            await _suggestionServices.AcceptSuggestion(id, cancellationToken);
            await _orderServices.AcceptStatus(orderid, cancellationToken);
            return true;
        }
        return false;
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
