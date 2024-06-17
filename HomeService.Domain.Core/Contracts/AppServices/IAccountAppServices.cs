using HomeService.Domain.Core.DTOs.AccountDto;
using HomeService.Domain.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace HomeService.Domain.Core.Contracts.AppServices;
public interface IAccountAppServices
{
    Task<List<IdentityError>> Register(AccountRegisterDto accountRegisterDto);
    Task<bool> Login(AccountLoginDto accountLoginDto);
    Task<List<IdentityError>> AdminRegister(AccountAdminRegisterDto accountAdminRegisterDto);
}