using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class CommentRepository : ICommentRepository
{

    private readonly AppDbContext _context;
    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }
    public bool Create(CommentCreateDto commentCreateDto)
    {
        var newModel = new Comment()
        {
           Title = commentCreateDto.Title,
            Description = commentCreateDto.Description,
            Score = commentCreateDto.Score,
            Customer = commentCreateDto.Customer,
            CustomerId = commentCreateDto.CustomerId,
            ExpertId = commentCreateDto.ExpertId,
            Expert = commentCreateDto.Expert,
        };
        _context.Comments.Add(newModel);

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int commentId)
    {
        _context.Comments
           .FirstOrDefault(a => a.Id == commentId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<Comment> GetAll()
    {
        return _context.Comments.AsNoTracking().ToList();
    }

    public Comment GetById(int commentId)
    {
        return _context.Comments.AsNoTracking().FirstOrDefault(a => a.Id == commentId);
    }


    public bool Update(CommentUpdateDto commentUpdateDto)
    {
        var targetModel = _context.Comments.FirstOrDefault(a => a.Id == commentUpdateDto.Id);

        targetModel.Title = commentUpdateDto.Title;
        targetModel.Description = commentUpdateDto.Description;
        targetModel.Score = commentUpdateDto.Score;

        _context.SaveChanges();

        return true;
    }
}
