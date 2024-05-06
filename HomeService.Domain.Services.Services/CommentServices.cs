using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class CommentServices : ICommentServices
{
    private readonly ICommentRepository _commentRepository;

    public CommentServices(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public Task<bool> Create(CommentCreateDto commentCreateDto, CancellationToken cancellationToken)
      => _commentRepository.Create(commentCreateDto, cancellationToken);

    public Task<bool> Delete(int CommentId, CancellationToken cancellationToken)
      => _commentRepository.Delete(CommentId, cancellationToken);

    public Task<List<Comment>> GetAll(CancellationToken cancellationToken)
      => _commentRepository.GetAll(cancellationToken);

    public Task<Comment> GetById(int commentId, CancellationToken cancellationToken)
      => _commentRepository.GetById(commentId, cancellationToken);

    public Task<bool> SetScore(int expertId, int score, CancellationToken cancellationToken)
      => _commentRepository.SetScore(expertId, score, cancellationToken);

    public Task<bool> Update(CommentUpdateDto commentUpdateDto, CancellationToken cancellationToken)
      => _commentRepository.Update(commentUpdateDto, cancellationToken);
}
