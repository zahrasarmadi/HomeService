using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface ICommentAppServices
{
    Task<bool> Create(CommentCreateDto commentCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(CommentUpdateDto commentUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int CommentId, CancellationToken cancellationToken);
    Task<Comment> GetById(int commentId, CancellationToken cancellationToken);
    Task<List<Comment>> GetAll(CancellationToken cancellationToken);
    Task<bool> SetScore(int expertId, int score, CancellationToken cancellationToken);
}
