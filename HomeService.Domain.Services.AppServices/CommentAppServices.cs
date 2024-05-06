using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class CommentAppServices : ICommentAppServices
{
    private readonly ICommentServices _commentServices;

    public CommentAppServices(ICommentServices commentServices)
    {
        _commentServices = commentServices;
    }

    public Task<bool> Create(CommentCreateDto commentCreateDto, CancellationToken cancellationToken)
      => _commentServices.Create(commentCreateDto, cancellationToken);

    public Task<bool> Delete(int CommentId, CancellationToken cancellationToken)
      => _commentServices.Delete(CommentId, cancellationToken);

    public Task<List<Comment>> GetAll(CancellationToken cancellationToken)
      => _commentServices.GetAll(cancellationToken);

    public Task<Comment> GetById(int commentId, CancellationToken cancellationToken)
      => _commentServices.GetById(commentId, cancellationToken);

    public Task<bool> SetScore(int expertId, int score, CancellationToken cancellationToken)
      => _commentServices.SetScore(expertId, score, cancellationToken);

    public Task<bool> Update(CommentUpdateDto commentUpdateDto, CancellationToken cancellationToken)
      => _commentServices.Update(commentUpdateDto, cancellationToken);
}
