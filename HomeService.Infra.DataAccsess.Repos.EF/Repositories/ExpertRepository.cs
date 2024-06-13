
using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.ExpertDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Enums;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ExpertRepository : IExpertRepository
{
    private readonly AppDbContext _context;
    public ExpertRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(ExpertCreateDto expertCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new Expert()
        {
            FirstName = expertCreateDto.FirstName,
            LastName = expertCreateDto.LastName,
            Gender = expertCreateDto.Gender,
            PhoneNumber = expertCreateDto.PhoneNumber,
            Address = expertCreateDto.Address,
            BirthDate = expertCreateDto.BirthDate,
            ProfileImage = expertCreateDto.ProfileImage,
            Services = expertCreateDto.Services,
        };
        await _context.Experts.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int expertId, CancellationToken cancellationToken)
    {
        var targetModel = await FindExpert(expertId, cancellationToken);
        targetModel.IsDeleted = true;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Experts.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Expert> GetById(int expertId, CancellationToken cancellationToken)
    {
        return await FindExpert(expertId, cancellationToken);
    }

    public async Task<bool> Update(ExpertUpdateDto expertUpdateDto,CancellationToken cancellationToken)
    {
        var targetModel = await _context.Experts
            .Include(e => e.Services)
            .FirstOrDefaultAsync(e => e.Id == expertUpdateDto.Id,cancellationToken);
       
        if (targetModel != null)
        {
            targetModel.Services ??= new List<Service>();
          
            targetModel.Services.Clear();

            if(expertUpdateDto.ServiceIds is not null)
            {
                foreach(var item in expertUpdateDto.ServiceIds)
                {
                    var service=await _context.Services
                        .FirstOrDefaultAsync(c=>c.Id == item,cancellationToken);

                    targetModel.Services.Add(service);
                }
            }
            targetModel.FirstName = expertUpdateDto.FirstName;
            targetModel.LastName = expertUpdateDto.LastName;
            targetModel.PhoneNumber = expertUpdateDto.PhoneNumber;
            //targetModel.Address = expertUpdateDto.Address;
            targetModel.BirthDate = expertUpdateDto.BirthDate;

            if (expertUpdateDto.ProfileImage != null)
            {
                targetModel.ProfileImage = expertUpdateDto.ProfileImage;
            }

        }
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<int> ExpertCount(CancellationToken cancellationToken)
    {
        var count = await _context.Experts.CountAsync(cancellationToken);
        return count;
    }

    public async Task<ExpertSummaryDto> GetExpertSummary(int id, CancellationToken cancellationToken)
    {
        var target = await _context.Experts.Where(e => e.Id == id && e.IsDeleted == false)
            .Select(e => new ExpertSummaryDto()
            {
                Id = e.Id,
                Comments = e.Comments.Select(x => new Comment()
                {
                    Customer = x.Customer,
                    Score = x.Score,
                    Title = x.Title,
                    Description = x.Description,

                }).ToList(),
                FirstName = e.FirstName,
                Gender = e.Gender,
                LastName = e.LastName,
                ProfileImage = e.ProfileImage,
                Services = e.Services,


            }).FirstOrDefaultAsync(cancellationToken);
        return target;
    }

    public async Task<int> ExpertCommentCount(int id, CancellationToken cancellationToken)
    {
        var targetExpert = await _context.Experts.Where(e => e.Id == id).Select(e => e.Comments).CountAsync();
        return targetExpert;
    }

    public async Task<int> ExpertAverageScores(int id, CancellationToken cancellationToken)
    {
        var targetExpert = await _context.Experts.Include(o => o.Comments).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (targetExpert == null || targetExpert.Comments == null || !targetExpert.Comments.Any())
        {
            return 0; 
        }
        var score = ((int)(targetExpert.Comments.Select(c => c.Score).Average()));
        return score;
    }

    public async Task<int> ExpertOrderCount(int id, CancellationToken cancellationToken)
    {
        var targetExpertSuggestion = await _context.Experts.Where(e => e.Id == id).SelectMany(e => e.Suggestions).ToListAsync(cancellationToken);
        var suggestions = targetExpertSuggestion.Count(o => o.Status == StatusEnum.Done);
        return suggestions;
    }

    public async Task<List<int>> GetExpertServiceIds(int id, CancellationToken cancellationToken)
    {
        var expertServices = await _context.Experts.Where(e => e.Id == id).SelectMany(e => e.Services).ToListAsync(cancellationToken);
        var servicesId = expertServices.Select(s => s.Id).ToList();
        return servicesId;
    }

    public async Task<ExpertUpdateDto> GetExpertUpdateInfo(int id, CancellationToken cancellationToken)
    {
        return await _context.Experts.Select(e => new ExpertUpdateDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            BirthDate = e.BirthDate,
            //Gender = e.Gender,
            ProfileImage = e.ProfileImage,
            ServiceIds = e.Services
            .Select(s =>s.Id)
            .ToList()
        }).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);


    }

    private async Task<Expert> FindExpert(int id, CancellationToken cancellationToken)
   => await _context.Experts.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
