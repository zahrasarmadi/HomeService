using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Repositories;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.Entities;
using HomeService.Domain.Core.Entities.Configs;
using HomeService.Domain.Services.AppServices;
using HomeService.Domain.Services.Services;
using HomeService.Endpoint.RazorPages.UI.Infrastructure;
using HomeService.Framework;
using HomeService.Infra.DataAccess.Repos.Dapper.Repositories;
using HomeService.Infra.DataAccsess.Repos.EF.Repositories;
using HomeService.Infra.DataBase.SQLServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//Admin Services
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IAdminAppServices, AdminAppServices>();

//Order Services
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderAppServices, OrderAppServices>();

//Service Services
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceServices, ServiceServices>();
builder.Services.AddScoped<IServiceAppServices, ServiceAppServices>();

//Category Services
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<IServiceCategoryServices, ServiceCategoryServices>();
builder.Services.AddScoped<IServiceCategoryAppServices, ServiceCategoryAppServices>();

//SubCategory Services
builder.Services.AddScoped<IServiceSubCategoryRepository, ServiceSubCategoryRepository>();
builder.Services.AddScoped<IServiceSubCategoryServices, ServiceSubCategoryServices>();
builder.Services.AddScoped<IServicSubCategoryAppServices, ServiceSubCategoryAppServices>();

//Comment Services
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<ICommentAppServices, CommentAppServices>();

//Suggestion Services
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<ISuggestionServices, SuggestionServices>();
builder.Services.AddScoped<ISuggestionAppServices, SuggestionAppServices>(); 

//Address Services
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

//City Services
builder.Services.AddScoped<ICityRepository, CityDapperRepository>();
builder.Services.AddScoped<ICityServices, CityServices>();
builder.Services.AddScoped<ICityAppServices, CityAppServices>();

//Customer Services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<ICustomerAppServices, CustomerAppServices>();

//Expert Services
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertServices, ExpertServices>();
builder.Services.AddScoped<IExpertAppServices, ExpertAppServices>();

//Base Services
builder.Services.AddScoped<IBaseSevices, BaseService>();
builder.Services.AddScoped<IBaseAppServices, BaseAppServices>();


builder.Services.AddMemoryCache();

//User Account Service
builder.Services.AddScoped<IAccountAppServices, AccountAppServices>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>
	(options =>
	{
		options.SignIn.RequireConfirmedAccount = false;
		options.Password.RequireDigit = false;
		options.Password.RequiredLength = 6;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireUppercase = false;
		options.Password.RequireLowercase = false;
	})
	.AddRoles<IdentityRole<int>>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddErrorDescriber<PersianIdentityErrorDescriber>();


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();


builder.Host.ConfigureLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();

}).UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.Seq(siteSettings.Seq.ServerUrl,LogEventLevel.Information,apiKey:siteSettings.Seq.ApiKey);
});



builder.Services.AddSingleton(siteSettings);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(siteSettings.SqlConfiguration.ConnectionsString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.CustomExceptionHandlingMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
