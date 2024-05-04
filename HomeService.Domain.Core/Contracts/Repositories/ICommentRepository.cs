using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICommentRepository
{
    public Task<bool> Create(CommentCreateDto commentCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(CommentUpdateDto commentUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int CommentId, CancellationToken cancellationToken);
    public Task<Comment> GetById(int commentId ,CancellationToken cancellationToken);
    public Task<List<Comment>> GetAll( CancellationToken cancellationToken);
}
