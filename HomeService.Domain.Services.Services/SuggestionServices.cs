﻿using HomeService.Domain.Core.Contracts.Repositories;
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

    public async Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken)
      => await _suggestionRepository.Create(suggestionCreateDto, cancellationToken);

    public async Task<bool> Delete(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionRepository.Delete(suggestionId, cancellationToken);

    public async Task<List<Suggestion>> GetAll(CancellationToken cancellationToken)
      => await _suggestionRepository.GetAll(cancellationToken);

    public async Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken)
      => await _suggestionRepository.GetById(suggestionId, cancellationToken);

    public async Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken)
      => await _suggestionRepository.Update(suggestionUpdateDto, cancellationToken);
}