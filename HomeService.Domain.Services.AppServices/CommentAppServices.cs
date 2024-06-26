﻿using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CommentDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Entities.Configs;
using HomeService.Domain.Core.Enums;
using System.Threading;

namespace HomeService.Domain.Services.AppServices;

public class CommentAppServices : ICommentAppServices
{
    private readonly ICommentServices _commentServices;
    private readonly SiteSettings _siteSettings;
    private readonly ICustomerServices _customerServices;

    public CommentAppServices(ICommentServices commentServices, SiteSettings siteSettings, ICustomerServices customerServices)
    {
        _commentServices = commentServices;
        _siteSettings = siteSettings;
        _customerServices = customerServices;
    }

    public async Task AcceptComment(int commentId, CancellationToken cancellationToken)
      => await _commentServices.AcceptComment(commentId, cancellationToken);

    public async Task<bool> Create(CommentCreateDto commentCreateDto, CancellationToken cancellationToken)
    {
        var customerInformation = await _customerServices.CustomerInformation(commentCreateDto.CustomerId, cancellationToken);
        var targetOrder = customerInformation.Orders.SelectMany(x => x.Suggestions)
                                                   .FirstOrDefault(s => s.ExpertId == commentCreateDto.ExpertId)?.Order;

        if (targetOrder?.Status == StatusEnum.Done)
        {
            return await _commentServices.Create(commentCreateDto, cancellationToken);
        }

        return false;
    }
    public async Task<bool> Delete(int CommentId, CancellationToken cancellationToken)
      => await _commentServices.Delete(CommentId, cancellationToken);

    public async Task<List<GetCommentsDto>> GetAll(CancellationToken cancellationToken)
      => await _commentServices.GetAll(cancellationToken);

    public async Task<Comment> GetById(int commentId, CancellationToken cancellationToken)
      => await _commentServices.GetById(commentId, cancellationToken);

    public async Task<bool> SetScore(int expertId, int score, CancellationToken cancellationToken)
      => await _commentServices.SetScore(expertId, score, cancellationToken);

    public async Task<bool> Update(CommentUpdateDto commentUpdateDto, CancellationToken cancellationToken)
      => await _commentServices.Update(commentUpdateDto, cancellationToken);

    public async Task<int> CommentCount(CancellationToken cancellationToken)
      => await _commentServices.CommentCount(cancellationToken);
    public async Task<List<RecentCommentDto>> GetRecentComments(CancellationToken cancellationToken)
    {
        var resentCount = _siteSettings.CommentConfiguration.RecentCount;
        return await _commentServices.GetRecentComments(resentCount, cancellationToken);
    }
    public async Task RejectComment(int commentId, CancellationToken cancellationToken)
     => await _commentServices.RejectComment(commentId, cancellationToken);
}
