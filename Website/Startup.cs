using Authentication;
using Core.Interfaces;
using Core.Interfaces.Queries;
using Core.Interfaces.Repositories;
using DatabaseAccess.Data;
using DatabaseAccess.Queries;
using DatabaseAccess.Repositories;
using DomainModel.Infrastructure;
using Mapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Website.Infrastructure;

namespace Website;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        
        var connectionString = Configuration.GetConnectionString("DbContextConnection") ?? throw new InvalidOperationException("Connection string 'DbContextConnection' not found.");

        // Add services to the container.
        services.AddDbContext<WriteContext>(options => options.UseSqlServer(connectionString));
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Forbidden/";
            });
        
        AddUtilities(services);
        AddQueries(services);
        AddRepositories(services);

        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddRazorPages();
        services.AddHttpContextAccessor();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var cookiePolicyOptions = new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
        };

        app.UseCookiePolicy(cookiePolicyOptions);
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        app.Run();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddQueries(IServiceCollection services)
    {
        services.AddScoped<IUserQueryFactory, UserQueryFactory>();
    }

    private static void AddUtilities(IServiceCollection services)
    {
        services.AddScoped<IPasswordUtilities, PasswordUtilities>();
        services.AddScoped<IUserFetcher, UserFetcher>();
        services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();
        services.AddScoped<IMapper, CustomMapper>();
    }
}