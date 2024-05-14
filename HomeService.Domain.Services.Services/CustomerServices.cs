using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class CustomerServices:ICustomerServices
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerServices(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<bool> Create(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken)
      =>_customerRepository.Create(customerCreateDto, cancellationToken);

    public Task<int> CustomerCount(CancellationToken cancellationToken)
      =>_customerRepository.CustomerCount(cancellationToken);

    public Task<bool> Delete(int customerId, CancellationToken cancellationToken)
      =>_customerRepository.Delete(customerId, cancellationToken);

    public Task<List<Customer>> GetAll(CancellationToken cancellationToken)
      =>_customerRepository.GetAll(cancellationToken);

    public Task<Customer> GetById(int customerId, CancellationToken cancellationToken)
      =>_customerRepository.GetById(customerId, cancellationToken);

    public Task<bool> Update(CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken)
      =>_customerRepository.Update(customerUpdateDto, cancellationToken);
}
