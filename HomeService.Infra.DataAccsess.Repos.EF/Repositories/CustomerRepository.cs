using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
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
            PhoneNumber = customerCreateDto.PhoneNumber,
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
        targetModel.Gender = customerUpdateDto.Gender;
        targetModel.PhoneNumber = customerUpdateDto.PhoneNumber;
        targetModel.BackUpPhoneNumber = customerUpdateDto.BackUpPhoneNumber;
        targetModel.BankCardNumber = customerUpdateDto.BankCardNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task<Customer> FindCustomer(int id, CancellationToken cancellationToken)
       => await _context.Customers.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}