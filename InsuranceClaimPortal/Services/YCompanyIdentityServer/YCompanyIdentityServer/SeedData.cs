using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YCompanyIdentityServer.Data;
using YCompanyIdentityServer.Models;

namespace YCompanyIdentityServer;

public class SeedData
{
    public static async Task<IServiceScope> EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await InitialDBMigrations(scope);

        await CreateFirstUser(scope);
        var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

        await AddAPIResources(configurationDbContext);

        await AddAPIScopes(configurationDbContext);

        await AddClients(configurationDbContext);

        await AddIdentityResources(configurationDbContext);

        return scope;
    }

    private static async Task AddIdentityResources(ConfigurationDbContext configurationDbContext)
    {
        /*
        * Identity Resources.
        * 
        */
        if (!await configurationDbContext.IdentityResources.AnyAsync())
        {
            await configurationDbContext.IdentityResources.AddRangeAsync(DevelopmentSeedData.IdentityResourceEntities);

            await configurationDbContext.SaveChangesAsync();
        }
    }

    private static async Task AddClients(ConfigurationDbContext configurationDbContext)
    {
        /*
         * Clients
         *
         */

        if (!await configurationDbContext.Clients.AnyAsync())
        {
            await configurationDbContext.Clients.AddRangeAsync(DevelopmentSeedData.ClientEntities);

            await configurationDbContext.SaveChangesAsync();
        }
    }

    private static async Task AddAPIScopes(ConfigurationDbContext configurationDbContext)
    {
        /*
         * Api Scopes
         *
         */
        if (!await configurationDbContext.ApiScopes.AnyAsync())
        {
            await configurationDbContext.ApiScopes.AddRangeAsync(DevelopmentSeedData.ApiScopes.Select(c => c.ToEntity()).ToList());

            await configurationDbContext.SaveChangesAsync();
        }
    }

    private static async Task AddAPIResources(ConfigurationDbContext configurationDbContext)
    {
        /*
         * Api resources
         *
         */
        if (!await configurationDbContext.ApiResources.AnyAsync())
        {
            await configurationDbContext.ApiResources.AddRangeAsync(DevelopmentSeedData.ApiResources.Select(x => x.ToEntity()).ToList());
            await configurationDbContext.SaveChangesAsync();
        }
    }

    private static async Task CreateFirstUser(IServiceScope scope)
    {
        var userManger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        if (await userManger.FindByNameAsync("amitchawla") == null)
        {
            await userManger.CreateAsync(DevelopmentSeedData.DefaultUser, DevelopmentSeedData.DefaultPassword);
        }
    }

    private static async Task InitialDBMigrations(IServiceScope scope)
    {
        // migrate tables initially. Initial migrations are created using ef command for initial migration
        await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();
    }
}
