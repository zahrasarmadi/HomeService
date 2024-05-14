using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class SuggestionRepository : ISuggestionRepository
{
    private readonly AppDbContext _context;
    public SuggestionRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(SuggestionCreateDto suggestionCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new Suggestion()
        {
            Description = suggestionCreateDto.Description,
            Expert = suggestionCreateDto.Expert,
            ExpertId = suggestionCreateDto.ExpertId,
            Order = suggestionCreateDto.Order,
            OrderId = suggestionCreateDto.OrderId,
            Price = suggestionCreateDto.Price,
        };
        await _context.Suggestions.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int suggestionId, CancellationToken cancellationToken)
    {
        var targetModel = await FindSuggestion(suggestionId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Suggestion>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Suggestions.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Suggestion> GetById(int suggestionId, CancellationToken cancellationToken)
    {
        return await FindSuggestion(suggestionId, cancellationToken);
    }

    public async Task<bool> Update(SuggestionUpdateDto suggestionUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindSuggestion(suggestionUpdateDto.Id, cancellationToken);

        targetModel.Description = suggestionUpdateDto.Description;
        targetModel.Price = suggestionUpdateDto.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<Suggestion> FindSuggestion(int id, CancellationToken cancellationToken)
   => await _context.Suggestions.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
