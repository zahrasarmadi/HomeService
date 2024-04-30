using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.DTOs;
using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace HomeService.Infra.DataAccsess.Repos.EF.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Create(CustomerCreateDto customerCreateDto)
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
            _context.Customers.Add(newModel);

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int customerId)
        {
            _context.Customers
                .FirstOrDefault(a => a.Id == customerId).IsDeleted = true;
            _context.SaveChanges();
            return true;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.AsNoTracking().ToList();
        }

        public Customer GetById(int customerId)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(a => a.Id == customerId);
        }

        public bool Update(CustomerUpdateDto customerUpdateDto)
        {
            var targetModel = _context.Customers.FirstOrDefault(a => a.Id == customerUpdateDto.Id);

            targetModel.FirstName = customerUpdateDto.FirstName;
            targetModel.LastName = customerUpdateDto.LastName;
            targetModel.Gender = customerUpdateDto.Gender;
            targetModel.PhoneNumber = customerUpdateDto.PhoneNumber;
            targetModel.BackUpPhoneNumber = customerUpdateDto.BackUpPhoneNumber;
            targetModel.BankCardNumber = customerUpdateDto.BankCardNumber;

            _context.SaveChanges();

            return true;
        }
    }
}
