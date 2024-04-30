using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICommentRepository
{
    public bool Create(CommentCreateDto commentCreateDto);
    public bool Update(CommentUpdateDto commentUpdateDto);
    public bool Delete(int CommentId);
    public Comment GetById(int commentId);
    public List<Comment> GetAll();
}
