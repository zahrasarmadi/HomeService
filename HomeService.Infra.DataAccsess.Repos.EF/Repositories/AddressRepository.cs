using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.AddressDTO;
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

    public async Task<bool> Create(AddressCreateDto addressCreateDto, CancellationToken cancellationToken)
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
        await _context.Addresses.AddAsync(newModel);

        _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int addressId, CancellationToken cancellationToken)
    {
        var targetMidel = await FindAddress(addressId, cancellationToken);
        targetMidel.IsDeleted = true;

        _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Address>> GetAll(CancellationToken cancellationToken)
        => await _context.Addresses.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Address> GetById(int addressId, CancellationToken cancellationToken)
      => await FindAddress(addressId, cancellationToken);


    public async Task<bool> Update(AddressUpdateDto addrressUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindAddress(addrressUpdateDto.Id, cancellationToken);

        targetModel.Area = addrressUpdateDto.Area;
        targetModel.Title = addrressUpdateDto.Title;
        targetModel.CityId = addrressUpdateDto.CityId;
        targetModel.City = addrressUpdateDto.City;
        targetModel.Street = addrressUpdateDto.Street;
        targetModel.PostalCode = addrressUpdateDto.PostalCode;
        targetModel.IsDefault = addrressUpdateDto.IsDefault;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<Address> FindAddress(int id, CancellationToken cancellationToken)
        => await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
