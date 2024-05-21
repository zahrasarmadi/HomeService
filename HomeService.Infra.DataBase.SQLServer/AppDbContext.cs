using HomeService.Domain.Core.Entities;
using HomeService.Infra.DataBase.SQLServer.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace HomeService.Infra.DataBase.SQLServer;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AdminConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new CityConfiguration());
        builder.ApplyConfiguration(new CommentConfiguration());
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new AddressConfiguration());
        builder.ApplyConfiguration(new ExpertConfiguration());
        builder.ApplyConfiguration(new ServiceConfiguration());
        builder.ApplyConfiguration(new ServiceCategoryConfiguration());
        builder.ApplyConfiguration(new ServiceSubCategoryConfiguration());
        builder.ApplyConfiguration(new SuggestionConfiguration());

        UserConfigurations.SeedUsers(builder);

        base.OnModelCreating(builder);
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Expert> Experts { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
}
