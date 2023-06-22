using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YCompanyIdentityServer;
using YCompanyIdentityServer.Data;
using YCompanyIdentityServer.Factories;
using YCompanyIdentityServer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextOptionsBuilder) =>
{
    dbContextOptionsBuilder
        .UseSqlServer(serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")
            , sqlServerdbContextOptionsBuilder =>
            {
                sqlServerdbContextOptionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
            }
        );
});


/*
 * Register asp.net core identity. 
 * 
 */
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();


/*
 * Register Identity Server for production
 * 
 */
builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    //.AddInMemoryApiResources(DevelopmentSeedData.ApiResources)
    //.AddInMemoryApiScopes(DevelopmentSeedData.ApiScopes)
    //.AddInMemoryClients(DevelopmentSeedData.Clients)
    //.AddInMemoryIdentityResources(DevelopmentSeedData.IdentityResources);
    .AddConfigurationStore(configurationStoreoptions =>
    {
        configurationStoreoptions.ResolveDbContextOptions = ResolveDbContextOptions;
    }) // stores config like api scopes, resources
    .AddOperationalStore(operationalStoreOptions =>
    {
        operationalStoreOptions.ResolveDbContextOptions = ResolveDbContextOptions;
    }); // keys, token, dates etc


builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.MapRazorPages();

// 

if (app.Environment.IsDevelopment())
{
    await SeedData.EnsureSeedData(app);
}

app.Run();



void ResolveDbContextOptions(IServiceProvider serviceProvider, DbContextOptionsBuilder dbContextOptionsBuilder)
{
    dbContextOptionsBuilder
        .UseSqlServer(serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("IdentityServer")
                , sqlServerdbContextOptionsBuilder =>
                {
                    sqlServerdbContextOptionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                }
        ); // a sepearate db for identity server db
}
