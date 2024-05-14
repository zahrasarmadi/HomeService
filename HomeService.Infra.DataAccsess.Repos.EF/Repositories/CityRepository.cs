using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _memoryCache;

    public CityRepository(AppDbContext context, IMemoryCache memoryCache)
    {
        _context = context;
        _memoryCache = memoryCache;
    }
    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    {
        var cities = _memoryCache.Get<List<City>>("Cities");
        if (cities is null)
        {
            return await _context.Cities.AsNoTracking().ToListAsync(cancellationToken);
        }
        _memoryCache.Set("Cities", cities, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromSeconds(200)
        });
        return cities;
    }

    public async Task<City> GetById(int cityId, CancellationToken cancellationToken)
    {
        return await _context.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == cityId, cancellationToken);
    }
}
