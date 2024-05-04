using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Cities.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<City> GetById(int cityId,CancellationToken cancellationToken)
    {
        return await _context.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == cityId,cancellationToken);
    }
}
