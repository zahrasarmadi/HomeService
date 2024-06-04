using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.SuggestionDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
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
            ExpertId = suggestionCreateDto.ExpertId,
            OrderId = suggestionCreateDto.OrderId,
            Price = suggestionCreateDto.Price,
            SuggestedDate = suggestionCreateDto.SuggastionDate,
            CreateAt = DateTime.Now,
            IsDeleted = false,
            Status = StatusEnum.AwaitingCustomerConfirmation,
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

    public async Task AcceptSuggestion(int id, CancellationToken cancellationToken)
    {
        var targetSuggestion = await _context.Suggestions.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        var orderId = targetSuggestion.OrderId;

        var otherSuggestions = await _context.Suggestions.Where(s => s.OrderId == orderId).ToListAsync(cancellationToken);

        foreach (var suggestion in otherSuggestions)
        {
            if (suggestion.Id == id)
            {
                suggestion.Status = StatusEnum.Confirmed;
            }
            else
            {
                suggestion.Status = StatusEnum.NotConfirmed;
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> ConfrimedStatusCount(int orderId, CancellationToken cancellationToken)
    {
        return await _context.Suggestions.Where(s => s.OrderId == orderId && s.Status == StatusEnum.Confirmed).CountAsync(cancellationToken);
    }

    public async Task<List<SuggestionsByExpertIdDto>> GetSuggestionsByExperId(int id, CancellationToken cancellationToken)
    {
        return await _context.Suggestions.Where(s => s.ExpertId == id)
            .Select(s => new SuggestionsByExpertIdDto
            {
                Id = s.Id,
                Description = s.Description,
                ExpertId = s.ExpertId,
                Price = s.Price,
                Status = s.Status,
                SuggestedDate = s.SuggestedDate,
                OrderId = s.OrderId,
                Order = new Order()
                {
                    Service = s.Order.Service,
                    Title = s.Order.Title,
                    Description = s.Order.Description,
                    Image = s.Order.Image
                }
            })
           .ToListAsync(cancellationToken);
    }

    public async Task DoneSuggestion(int id, CancellationToken cancellationToken)
    {
        var targetSuggestion = await _context.Suggestions.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        targetSuggestion.Status = StatusEnum.Done;

        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task<Suggestion> FindSuggestion(int id, CancellationToken cancellationToken)
   => await _context.Suggestions.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
