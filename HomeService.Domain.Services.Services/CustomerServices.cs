using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.Services;

public class CustomerServices : ICustomerServices
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerServices(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Create(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken)
      => await _customerRepository.Create(customerCreateDto, cancellationToken);

    public async Task<Customer> CustomerInformation(int customerId, CancellationToken cancellationToken)
      => await _customerRepository.CustomerInformation(customerId, cancellationToken);

    public async Task<int> CustomerCount(CancellationToken cancellationToken)
      => await _customerRepository.CustomerCount(cancellationToken);

    public async Task<bool> Delete(int customerId, CancellationToken cancellationToken)
      => await _customerRepository.Delete(customerId, cancellationToken);

    public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
      => await _customerRepository.GetAll(cancellationToken);

    public async Task<Customer> GetById(int customerId, CancellationToken cancellationToken)
      => await _customerRepository.GetById(customerId, cancellationToken);

    public async Task<CustomerSummaryDto> GetCustomerSummary(int id, CancellationToken cancellationToken)
      => await _customerRepository.GetCustomerSummary(id, cancellationToken);

    public async Task<CustomerUpdateDto> GetCustomerUpdateInfo(int customerId, CancellationToken cancellationToken)
      => await _customerRepository.GetCustomerUpdateInfo(customerId, cancellationToken);

    public async Task<bool> Update(CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken)
      => await _customerRepository.Update(customerUpdateDto, cancellationToken);


}
