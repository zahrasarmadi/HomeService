using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICustomerRepository
{
    public bool Create(CustomerCreateDto customerCreateDto);
    public bool Update(CustomerUpdateDto customerUpdateDto);
    public bool Delete(int customerId);
    public Customer GetById(int customerId);
    public List<Customer> GetAll();
}
