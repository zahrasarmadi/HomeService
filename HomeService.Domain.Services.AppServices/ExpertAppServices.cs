using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class ExpertAppServices : IExpertAppServices
{
    private readonly IExpertServices _expertServices;
    public ExpertAppServices(IExpertServices expertServices)
    {
        _expertServices = expertServices;
    }

    public async Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken)
      => await _expertServices.Create(expertCreateDto, cancellationToken);

    public async Task<bool> Delete(int expertId, CancellationToken cancellationToken)
      => await _expertServices.Delete(expertId, cancellationToken);

    public async Task<int> ExpertCount(CancellationToken cancellationToken)
    {
       var c= await _expertServices.ExpertCount(cancellationToken);
        return c;
    }
    public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
       => await _expertServices.GetAll(cancellationToken);

    public async Task<Expert> GetById(int expertId, CancellationToken cancellationToken)
       => await _expertServices.GetById(expertId, cancellationToken);

    public async Task<bool> Update(ExpertUpdateDto expertUpdateDto, CancellationToken cancellationToken)
      => await _expertServices.Update(expertUpdateDto, cancellationToken);
}
