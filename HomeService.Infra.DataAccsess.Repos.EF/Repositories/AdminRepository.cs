using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;
    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool Create(AdminCreateDto adminCreateDto)
    {
        var newModel = new Admin()
        {
            FirstName = adminCreateDto.FirstName,
            LastName = adminCreateDto.LastName,
            Email = adminCreateDto.Email,
            Gender = adminCreateDto.Gender,
            Password = adminCreateDto.Password,
            PhoneNumber = adminCreateDto.PhoneNumber,
        };

        _context.Admins.Add(newModel);
        _context.SaveChanges();
        return true;

    }

    public bool Delete(int adminId)
    {
        var targetAdmin = _context.Admins.FirstOrDefault(a => a.Id == adminId);
        targetAdmin.IsDeleted = true;
        _context.SaveChanges();
        return true;

    }

    public List<Admin> GetAll()
    {
        return _context.Admins.AsNoTracking().ToList();
    }

    public Admin GetById(int adminId)
    {
        return _context.Admins.AsNoTracking().FirstOrDefault(a => a.Id == adminId);
    }

    public bool Update(AdminUpdateDto adminUpdateDto)
    {
        var targetModel = _context.Admins.FirstOrDefault(a => a.Id == adminUpdateDto.Id);

        targetModel.FirstName = adminUpdateDto.FirstName;
        targetModel.LastName = adminUpdateDto.LastName;
        targetModel.Email = adminUpdateDto.Email;
        targetModel.Gender = adminUpdateDto.Gender;
        targetModel.Password = adminUpdateDto.Password;
        targetModel.PhoneNumber = adminUpdateDto.PhoneNumber;

        _context.SaveChanges();
        return true;
    }
}
