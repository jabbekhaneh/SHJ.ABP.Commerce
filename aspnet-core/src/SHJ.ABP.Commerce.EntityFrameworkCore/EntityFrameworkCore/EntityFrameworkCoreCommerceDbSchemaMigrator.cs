using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHJ.ABP.Commerce.Data;
using Volo.Abp.DependencyInjection;

namespace SHJ.ABP.Commerce.EntityFrameworkCore;

public class EntityFrameworkCoreCommerceDbSchemaMigrator
    : ICommerceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCommerceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the CommerceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CommerceDbContext>()
            .Database
            .MigrateAsync();
    }
}
