﻿using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Framework;

namespace HomeService.Domain.Services.AppServices;

public class SuggestionAppServices : ISuggestionAppServices
{
    private readonly ISuggestionServices _suggestionServices;
    private readonly IOrderServices _orderServices;
    private readonly IBaseSevices _baseSevices;

    public SuggestionAppServices(ISuggestionServices suggestionServices, IOrderServices orderServices, IBaseSevices baseSevices)
    {
        _suggestionServices = suggestionServices;
        _orderServices = orderServices;
        _baseSevices = baseSevices;
    }

    public async Task<bool> AcceptSuggestion(int id, int orderid, CancellationToken cancellationToken)
    {
        var confrimedCount = await _suggestionServices.ConfrimedStatusCount(orderid, cancellationToken);

        if (confrimedCount == 0)
        {
            await _suggestionServices.AcceptSuggestion(id, cancellationToken);
            await _orderServices.AcceptOrder(orderid, cancellationToken);
            return true;
        }
        return false;
    }

    public async Task<bool> Create(SuggestionCreateDto suggestionCreateDto, string suggestionDate, CancellationToken cancellationToken)
    {
        var gregorianDate = _baseSevices.PersianToGregorian(suggestionDate);
        suggestionCreateDto.SuggastionDate = gregorianDate;
        return await _suggestionServices.Create(suggestionCreateDto, cancellationToken);
    }

    public async Task<bool> Delete(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionServices.Delete(suggestionId, cancellationToken);

    public async Task<List<Suggestion>> GetAll(CancellationToken cancellationToken)
      => await _suggestionServices.GetAll(cancellationToken);

    public async Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionServices.GetById(suggestionId, cancellationToken);

    public async Task<List<SuggestionsByExpertIdDto>> GetSuggestionsByExperId(int id, CancellationToken cancellationToken)
    {
       var Suggestions= await _suggestionServices.GetSuggestionsByExperId(id, cancellationToken);
        var suggetionDates = Suggestions.Select(s => s.SuggestedDate).ToList();
        foreach (var item in Suggestions)
        {
            item.SuggestedDateString = (DateTime.Parse(item.SuggestedDate.ToString())).ToPersianString("yyyy/MM/dd");
        }
        return Suggestions;
    }

    public async Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken)
      => await _suggestionServices.Update(suggestionUpdateDto, cancellationToken);
}