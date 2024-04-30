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
    public List<City> GetAll()
    {
      return _context.Cities.AsNoTracking().ToList();
    }

    public City GetById(int cityId)
    {
        return _context.Cities.AsNoTracking().FirstOrDefault(c => c.Id == cityId);
    }
}
