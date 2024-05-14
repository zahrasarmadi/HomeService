﻿using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.AdminDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;
    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken)
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

        await _context.Admins.AddAsync(newModel,cancellationToken);
        _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
    {
        var targetAdmin = await FindAdmin(adminId, cancellationToken);
        targetAdmin.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }

    public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
        => await _context.Admins.AsNoTracking().ToListAsync(cancellationToken);


    public async Task<Admin> GetById(int adminId, CancellationToken cancellationToken)
      => await FindAdmin(adminId, cancellationToken);


    public async Task<bool> Update(AdminUpdateDto adminUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel =await FindAdmin(adminUpdateDto.Id, cancellationToken);

        targetModel.FirstName = adminUpdateDto.FirstName;
        targetModel.LastName = adminUpdateDto.LastName;
        targetModel.Email = adminUpdateDto.Email;
        targetModel.Gender = adminUpdateDto.Gender;
        targetModel.Password = adminUpdateDto.Password;
        targetModel.PhoneNumber = adminUpdateDto.PhoneNumber;

        _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    private async Task<Admin> FindAdmin(int id, CancellationToken cancellationToken)
      => await _context.Admins.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
}
