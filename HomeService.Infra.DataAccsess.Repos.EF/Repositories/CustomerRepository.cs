using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken)
    {
        var newModel = new Customer()
        {
            FirstName = customerCreateDto.FirstName,
            LastName = customerCreateDto.LastName,
            Gender = customerCreateDto.Gender,
            BackUpPhoneNumber = customerCreateDto.BackUpPhoneNumber,
            BankCardNumber = customerCreateDto.BankCardNumber,
            Addresses = customerCreateDto.Addresses,
        };
        await _context.Customers.AddAsync(newModel, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Delete(int customerId, CancellationToken cancellationToken)
    {
        var targetModel = await FindCustomer(customerId, cancellationToken);
        targetModel.IsDeleted = true;

        _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Customers.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Customer> GetById(int customerId, CancellationToken cancellationToken)
    {
        return await FindCustomer(customerId, cancellationToken);
    }

    public async Task<bool> Update(CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await FindCustomer(customerUpdateDto.Id, cancellationToken);

        targetModel.FirstName = customerUpdateDto.FirstName;
        targetModel.LastName = customerUpdateDto.LastName;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<CustomerSummaryDto> GetCustomerSummary(int id, CancellationToken cancellationToken)
    {
        var target = await _context.Customers.Where(a => a.Id == id && a.IsDeleted == false)
            .Select(c => new CustomerSummaryDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                BankCardNumber = c.BankCardNumber,
                BackUpPhoneNumber = c.BackUpPhoneNumber,
                Gender = c.Gender,
                Addresses = c.Addresses,
                Comments = c.Comments,
                Orders = c.Orders
            }).FirstOrDefaultAsync(cancellationToken);

        if (target is not null)
        {
            return target;
        }
        return new CustomerSummaryDto();
    }

    public async Task<int> FindCustomerIdWithApplicationUser(int applicationUserId, CancellationToken cancellationToken)
    {
        var targetCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.ApplicationUserId == applicationUserId, cancellationToken);
        var customerId = targetCustomer.Id;
        return customerId;
    }


    public async Task<int> CustomerCount(CancellationToken cancellationToken)
      => await _context.Customers.CountAsync(cancellationToken);

    private async Task<Customer> FindCustomer(int id, CancellationToken cancellationToken)
       => await _context.Customers.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}