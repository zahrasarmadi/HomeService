using Dapper;
using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Entities.Configs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System.Data;

namespace HomeService.Infra.DataAccess.Repos.Dapper.Repositories;

public class CityDapperRepository : ICityRepository
{
    private readonly SiteSettings _siteSettings;
    private readonly IMemoryCache _memoryCache;

    public CityDapperRepository(SiteSettings siteSettings, IMemoryCache memoryCache)
    {
        _siteSettings = siteSettings;
        _memoryCache = memoryCache;
    }

    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    {
        var cities = _memoryCache.Get<List<City>>("Cities");
        if (cities is null)
        {
            using (IDbConnection db = new SqlConnection(_siteSettings.SqlConfiguration.ConnectionsString))
            {
                return (List<City>)await db.QueryAsync<City>("SELECT * FROM Cities");
            }
        }
        _memoryCache.Set("Cities", cities, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromDays(90)
        });

        return cities;
    }

    public async Task<City> GetById(int cityId, CancellationToken cancellationToken)
    {
        using (IDbConnection db = new SqlConnection(_siteSettings.SqlConfiguration.ConnectionsString))
        {
            return await db.QueryFirstOrDefaultAsync<City>("SELECT * FROM Students WHERE Id = @Id", new { Id = cityId });
        }
    }
}
