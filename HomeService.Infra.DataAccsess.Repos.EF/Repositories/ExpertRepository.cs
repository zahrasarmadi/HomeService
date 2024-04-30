using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class ExpertRepository : IExpertRepository
{
    private readonly AppDbContext _context;
    public ExpertRepository(AppDbContext context)
    {
        _context = context;
    }
    public bool Create(ExpertCreateDto expertCreateDto)
    {
        var newModel = new Expert()
        {
            FirstName = expertCreateDto.FirstName,
            LastName = expertCreateDto.LastName,
            Gender = expertCreateDto.Gender,
            PhoneNumber = expertCreateDto.PhoneNumber,
            BankCardNumber = expertCreateDto.BankCardNumber,
            Address = expertCreateDto.Address,
            BirthDate = expertCreateDto.BirthDate,
            ProfileImage = expertCreateDto.ProfileImage,
            Services = expertCreateDto.Services,
        };
        _context.Experts.Add(newModel);

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int expertId)
    {
        _context.Experts
          .FirstOrDefault(a => a.Id == expertId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<Expert> GetAll()
    {
        return _context.Experts.AsNoTracking().ToList();
    }

    public Expert GetById(int expertId)
    {
        return _context.Experts.AsNoTracking().FirstOrDefault(a => a.Id == expertId);
    }

    public bool Update(ExpertUpdateDto expertUpdateDto)
    {
        var targetModel = _context.Experts.FirstOrDefault(a => a.Id == expertUpdateDto.Id);
        targetModel.FirstName = expertUpdateDto.FirstName;
        targetModel.LastName = expertUpdateDto.LastName;
        targetModel.Gender = expertUpdateDto.Gender;
        targetModel.PhoneNumber = expertUpdateDto.PhoneNumber;
        targetModel.BankCardNumber = expertUpdateDto.BankCardNumber;
        targetModel.Address = expertUpdateDto.Address;
        targetModel.BirthDate = expertUpdateDto.BirthDate;
        targetModel.ProfileImage = expertUpdateDto.ProfileImage;
        targetModel.Services = expertUpdateDto.Services;
        _context.SaveChanges();

        return true;
    }
}
