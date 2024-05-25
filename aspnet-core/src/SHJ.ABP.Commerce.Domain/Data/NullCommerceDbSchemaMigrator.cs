using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SHJ.ABP.Commerce.Data;

/* This is used if database provider does't define
 * ICommerceDbSchemaMigrator implementation.
 */
public class NullCommerceDbSchemaMigrator : ICommerceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
