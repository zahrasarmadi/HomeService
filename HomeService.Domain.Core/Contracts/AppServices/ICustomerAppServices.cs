using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.AppServices;

public interface ICustomerAppServices
{
    Task<bool> Create(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken);
    Task<bool> Update(CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken);
    Task<bool> Delete(int customerId, CancellationToken cancellationToken);
    Task<Customer> GetById(int customerId, CancellationToken cancellationToken);
    Task<List<Customer>> GetAll(CancellationToken cancellationToken);
    Task<int> CustomerCount(CancellationToken cancellationToken);
    Task<CustomerSummaryDto> GetCustomerSummary(int id, CancellationToken cancellationToken);
    Task<CustomerUpdateDto> GetCustomerUpdateInfo(int customerId, CancellationToken cancellationToken);
    Task<Customer> CustomerInformation(int customerId, CancellationToken cancellationToken);
}
