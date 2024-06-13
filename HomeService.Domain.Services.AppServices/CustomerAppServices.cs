using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Services.AppServices;

public class CustomerAppServices : ICustomerAppServices
{
    private readonly ICustomerServices _customerServices;

    public CustomerAppServices(ICustomerServices customerServices)
    {
        _customerServices = customerServices;
    }

    public async Task<bool> Create(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken)
      => await _customerServices.Create(customerCreateDto, cancellationToken);

    public async Task<int> CustomerCount(CancellationToken cancellationToken)
      => await _customerServices.CustomerCount(cancellationToken);

    public async Task<bool> Delete(int customerId, CancellationToken cancellationToken)
      => await _customerServices.Delete(customerId, cancellationToken);

    public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
      => await _customerServices.GetAll(cancellationToken);

    public async Task<Customer> GetById(int customerId, CancellationToken cancellationToken)
      => await _customerServices.GetById(customerId, cancellationToken);

    public async Task<CustomerSummaryDto> GetCustomerSummary(int id, CancellationToken cancellationToken)
      => await _customerServices.GetCustomerSummary(id, cancellationToken);

    public async Task<CustomerUpdateDto> GetCustomerUpdateInfo(int customerId, CancellationToken cancellationToken)
      => await _customerServices.GetCustomerUpdateInfo(customerId, cancellationToken);

    public async Task<bool> Update(CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken)
      => await _customerServices.Update(customerUpdateDto, cancellationToken);
}
