using Microsoft.AspNetCore.Identity;

namespace HomeService.Domain.Core.Contracts.AppServices;
public interface IAccountAppServices
{
    Task<List<IdentityError>> Register(string fisrtName, string lastName, string email, string password, bool isExpert, bool isCustomer);
    Task<bool> Login(string email, string password);
}