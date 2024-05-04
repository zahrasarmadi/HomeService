using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICustomerRepository
{
    public Task<bool> Create(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken);
    public Task<bool> Update(CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken);
    public Task<bool> Delete(int customerId, CancellationToken cancellationToken);
    public Task<Customer> GetById(int customerId, CancellationToken cancellationToken);
    public Task<List<Customer>> GetAll(CancellationToken cancellationToken);
}
