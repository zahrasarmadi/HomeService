using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IExpertRepository
{
    public bool Create(ExpertCreateDto expertCreateDto);
    public bool Update(ExpertUpdateDto expertUpdateDto);
    public bool Delete(int expertId);
    public Expert GetById(int expertId);
    public List<Expert> GetAll();
}
