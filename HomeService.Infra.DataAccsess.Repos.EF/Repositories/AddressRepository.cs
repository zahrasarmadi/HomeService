using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class AddressRepository : IAddressRepository
{

    private readonly AppDbContext _context;
    public AddressRepository(AppDbContext context)
    {
        _context = context;
    }
    public bool Create(AddressCreateDto addressCreateDto)
    {
        var newModel = new Address()
        {
            Area = addressCreateDto.Area,
            City = addressCreateDto.City,
            PostalCode = addressCreateDto.PostalCode,
            Street = addressCreateDto.Street,
            CityId = addressCreateDto.CityId,
            Title = addressCreateDto.Title,
            IsDefault = addressCreateDto.IsDefault,
        };
        _context.Addresses.Add(newModel);

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int addressId)
    {
       _context.Addresses
            .FirstOrDefault(a => a.Id == addressId).IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public List<Address> GetAll()
    {
        return _context.Addresses.AsNoTracking().ToList();
    }

    public Address GetById(int addressId)
    {
       return _context.Addresses.AsNoTracking().FirstOrDefault(a => a.Id == addressId);
    }

    public bool Update(AddressUpdateDto addrressUpdateDto)
    {
        var targetModel = _context.Addresses.FirstOrDefault(a => a.Id == addrressUpdateDto.Id);

        targetModel.Area = addrressUpdateDto.Area;
        targetModel.Title = addrressUpdateDto.Title;
        targetModel.CityId = addrressUpdateDto.CityId;
        targetModel.City = addrressUpdateDto.City;
        targetModel.Street = addrressUpdateDto.Street;
        targetModel.PostalCode = addrressUpdateDto.PostalCode;
        targetModel.IsDefault=addrressUpdateDto.IsDefault;

        _context.SaveChanges();

        return true;
    }
}
