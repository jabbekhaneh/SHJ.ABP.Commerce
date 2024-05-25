using System.Threading.Tasks;

namespace SHJ.ABP.Commerce.Data;

public interface ICommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
