using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface IAddressRepository
{
    public bool Create(AddressCreateDto addressCreateDto);
    public bool Update(AddressUpdateDto addrressUpdateDto);
    public bool Delete(int addressId);
    public Address GetById(int addressId);
    public List<Address> GetAll();
}
