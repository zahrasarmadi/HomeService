using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs.CustomerDTO;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;

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
            Address = customerCreateDto.Address,
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
        var targetModel = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == customerUpdateDto.Id, cancellationToken)
;
        if (targetModel == null)
            return false;

        targetModel.FirstName = customerUpdateDto.FirstName;
        targetModel.LastName = customerUpdateDto.LastName;
        targetModel.PhoneNumber = customerUpdateDto.PhoneNumber;
        targetModel.Address = customerUpdateDto.Address;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<CustomerUpdateDto> GetCustomerUpdateInfo(int customerId, CancellationToken cancellationToken)
    {
        var targetCustomer = await _context.Customers.AsNoTracking().Include(c => c.Address)
             .Select(c => new CustomerUpdateDto()
             {
                 Id = c.Id,
                 FirstName = c.FirstName,
                 LastName = c.LastName,
                 PhoneNumber = c.PhoneNumber,
                 Address = c.Address,
             }).FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);

        if (targetCustomer is null)
            return new CustomerUpdateDto();

        return targetCustomer;
    }

    public async Task<CustomerSummaryDto> GetCustomerSummary(int id, CancellationToken cancellationToken)
    {
        var target = await _context.Customers.Where(a => a.Id == id && a.IsDeleted == false)
            .Select(c => new CustomerSummaryDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                BackUpPhoneNumber = c.PhoneNumber,
                Gender = c.Gender,
                Address = c.Address,
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

    public async Task<Customer> CustomerInformation(int customerId, CancellationToken cancellationToken)
    {
        return await _context.Customers
             .Include(c => c.Orders)
             .ThenInclude(x => x.Suggestions)
             .ThenInclude(s => s.Expert)
             .Include(x => x.Comments).FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);
    }

    public async Task<int> CustomerCount(CancellationToken cancellationToken)
      => await _context.Customers.CountAsync(cancellationToken);

    private async Task<Customer> FindCustomer(int id, CancellationToken cancellationToken)
       => await _context.Customers.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}