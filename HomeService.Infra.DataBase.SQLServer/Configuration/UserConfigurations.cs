using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.DataBase.SQLServer.Configuration;
public class UserConfigurations
{
	public static void SeedUsers(ModelBuilder builder)
	{
		var hasher = new PasswordHasher<ApplicationUser>();

		// SeedUsers
		var users = new List<ApplicationUser>
		{
			new ApplicationUser()
			{
				Id = 1,
				UserName = "Zahrasarmadi17@gmail.com",
				NormalizedUserName = "ZAHRASARMADI17@GMAIL.COM",
				Email = "Zahrasarmadi17@gmail.com",
				NormalizedEmail = "ZAHRASARMADI17@GMAIL.COM",
				LockoutEnabled = false,
				PhoneNumber = "09927848276",
				SecurityStamp = Guid.NewGuid().ToString()

			},
			new ApplicationUser()
			{
				Id = 2,
				UserName = "Ali@gmail.com",
				NormalizedUserName = "ALI@GMAIL.COM",
				Email = "Ali@gmail.com",
				NormalizedEmail = "ALI@GMAIL.COM",
				LockoutEnabled = false,
				PhoneNumber = "09377507920",
				SecurityStamp = Guid.NewGuid().ToString()
			},
			new ApplicationUser()
			{
				Id = 3,
				UserName = "Sahar@gmail.com",
				NormalizedUserName = "SAHAR@GMAIL.COM",
				Email = "Sahar@gmail.com",
				NormalizedEmail = "SAHAR@GMAIL.COM",
				LockoutEnabled = false,
				PhoneNumber = "09377507920",
				SecurityStamp = Guid.NewGuid().ToString()
			},
			new ApplicationUser()
			{
				Id = 4,
				UserName = "Sara@gmail.com",
				NormalizedUserName = "SARA@GMAIL.COM",
				Email = "Sara@gmail.com",
				NormalizedEmail = "SARA@GMAIL.COM",
				LockoutEnabled = false,
				PhoneNumber = "09377507920",
				SecurityStamp = Guid.NewGuid().ToString()
			},
			new ApplicationUser()
			{
				Id = 5,
				UserName = "Mohammad@gmail.com",
				NormalizedUserName = "MOHAMMAD@GMAIL.COM",
				Email = "Mohammad@gmail.com",
				NormalizedEmail = "MOHAMMAD@GMAIL.COM",
				LockoutEnabled = false,
				PhoneNumber = "09377507920",
				SecurityStamp = Guid.NewGuid().ToString()
			}
		};

		foreach (var user in users)
		{
			var passwordHasher = new PasswordHasher<ApplicationUser>();
			user.PasswordHash = passwordHasher.HashPassword(user, "1234");

			builder.Entity<ApplicationUser>().HasData(user);
		}

		// Seed Roles
		builder.Entity<IdentityRole<int>>().HasData(
			new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
			new IdentityRole<int>() { Id = 2, Name = "Expert", NormalizedName = "EXPERT" },
			new IdentityRole<int>() { Id = 3, Name = "Customer", NormalizedName = "CUSTOMER" }
		);

		//Seed Role To Users
		builder.Entity<IdentityUserRole<int>>().HasData(
			new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
			new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
			new IdentityUserRole<int>() { RoleId = 3, UserId = 3 },
			new IdentityUserRole<int>() { RoleId = 2, UserId = 4 },
			new IdentityUserRole<int>() { RoleId = 3, UserId = 5 }
		);
	}
}