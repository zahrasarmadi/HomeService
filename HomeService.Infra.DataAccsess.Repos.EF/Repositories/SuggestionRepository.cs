using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
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
    public bool Create(SuggestionCreateDto suggestionCreateDto)
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
        _context.Suggestions.Add(newModel);

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int suggestionId)
    {
        _context.Suggestions
           .FirstOrDefault(a => a.Id == suggestionId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<Suggestion> GetAll()
    {
        return _context.Suggestions.AsNoTracking().ToList();
    }

    public Suggestion GetById(int suggestionId)
    {
        return _context.Suggestions.AsNoTracking().FirstOrDefault(a => a.Id == suggestionId);
    }

    public bool Update(SuggestionUpdateDto suggestionUpdateDto)
    {
        var targetModel = _context.Suggestions.FirstOrDefault(a => a.Id == suggestionUpdateDto.Id);

        targetModel.Description = suggestionUpdateDto.Description;
        targetModel.Price = suggestionUpdateDto.Price;

        _context.SaveChanges();

        return true;
    }
}
