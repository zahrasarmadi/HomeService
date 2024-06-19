using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.AdminDTO;
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

    public async Task<bool> Create(AdminCreateDto adminCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new Admin()
        {
            FirstName = adminCreateDto.FirstName,
            LastName = adminCreateDto.LastName,
            Gender = adminCreateDto.Gender,
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
        var targetModel = await _context.Admins
            .Include(a => a.ApplicationUser)
            .FirstOrDefaultAsync(a => a.Id == adminUpdateDto.Id, cancellationToken);

        targetModel.FirstName = adminUpdateDto.FirstName;
        targetModel.LastName = adminUpdateDto.LastName;
        targetModel.ApplicationUser.Email = adminUpdateDto.Email;
        targetModel.ApplicationUser.PhoneNumber = adminUpdateDto.PhoneNumber;

       await _context.SaveChangesAsync(cancellationToken);
        return true;
    }


    public async Task<AdminUpdateDto> AdminUpdateInfo(int id, CancellationToken cancellationToken)
    {
        var m =await _context.Admins.Select(a => new AdminUpdateDto
        {
            Id = a.Id,
            Email = a.ApplicationUser.Email,
            FirstName = a.FirstName,
            LastName = a.LastName,
            PhoneNumber = a.ApplicationUser.PhoneNumber

        }).FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        return m;
    }

    private async Task<Admin> FindAdmin(int id, CancellationToken cancellationToken)
      => await _context.Admins.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
}
