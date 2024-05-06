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
    public async Task<bool> Create(CommentCreateDto commentCreateDto, CancellationToken cancellationToken)
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
        await _context.Comments.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int commentId, CancellationToken cancellationToken)
    {
        var targetModel = await FindComment(commentId, cancellationToken);
        targetModel.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Comment>> GetAll(CancellationToken cancellationToken)
        => await _context.Comments.AsNoTracking().ToListAsync(cancellationToken);


    public async Task<Comment> GetById(int commentId, CancellationToken cancellationToken)
       => await FindComment(commentId, cancellationToken);



    public async Task<bool> Update(CommentUpdateDto commentUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindComment(commentUpdateDto.Id, cancellationToken);

        targetModel.Title = commentUpdateDto.Title;
        targetModel.Description = commentUpdateDto.Description;
        targetModel.Score = commentUpdateDto.Score;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> SetScore(int expertId,int  score, CancellationToken cancellationToken)
    {
        var targetModel = await _context.Comments.FirstOrDefaultAsync(c => c.ExpertId == expertId,cancellationToken);

        targetModel.Score=score;
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<Comment> FindComment(int id, CancellationToken cancellationToken)
       => await _context.Comments.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
