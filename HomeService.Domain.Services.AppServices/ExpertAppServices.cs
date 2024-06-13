using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.AppServices;

public class ExpertAppServices : IExpertAppServices
{
    private readonly IExpertServices _expertServices;
    private readonly IBaseSevices _baseSevices;

    public ExpertAppServices(IExpertServices expertServices, IBaseSevices baseSevices)
    {
        _expertServices = expertServices;
        _baseSevices = baseSevices;
    }

    public async Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken)
      => await _expertServices.Create(expertCreateDto, cancellationToken);

    public async Task<bool> Delete(int expertId, CancellationToken cancellationToken)
      => await _expertServices.Delete(expertId, cancellationToken);

    public async Task<int> ExpertAverageScores(int id, CancellationToken cancellationToken)
      => await _expertServices.ExpertAverageScores(id, cancellationToken);

    public async Task<int> ExpertCommentCount(int id, CancellationToken cancellationToken)
      => await _expertServices.ExpertCommentCount(id, cancellationToken);

    public async Task<int> ExpertCount(CancellationToken cancellationToken)
      => await _expertServices.ExpertCount(cancellationToken);

    public async Task<int> ExpertOrderCount(int id, CancellationToken cancellationToken)
      => await _expertServices.ExpertOrderCount(id, cancellationToken);

    public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
      => await _expertServices.GetAll(cancellationToken);

    public async Task<Expert> GetById(int expertId, CancellationToken cancellationToken)
      => await _expertServices.GetById(expertId, cancellationToken);

    public async Task<List<int>> GetExpertServiceIds(int id, CancellationToken cancellationToken)
      => await _expertServices.GetExpertServiceIds(id, cancellationToken);

    public async Task<ExpertSummaryDto> GetExpertSummary(int id, CancellationToken cancellationToken)
      => await _expertServices.GetExpertSummary(id, cancellationToken);

    public async Task<ExpertUpdateDto> GetExpertUpdateInfo(int id, CancellationToken cancellationToken)
      => await _expertServices.GetExpertUpdateInfo(id, cancellationToken);


    public async Task<bool> Update(ExpertUpdateDto expertUpdateDto, IFormFile image, string birthDate, CancellationToken cancellationToken)
    {
        if (image != null)
        {
            var imageUrl = await _baseSevices.UploadImage(image);
            expertUpdateDto.ProfileImage = imageUrl;
        }
        var GregorianbirthDate = _baseSevices.PersianToGregorian(birthDate);
        
        expertUpdateDto.BirthDate= GregorianbirthDate;

        return await _expertServices.Update(expertUpdateDto,cancellationToken);
    }
}
