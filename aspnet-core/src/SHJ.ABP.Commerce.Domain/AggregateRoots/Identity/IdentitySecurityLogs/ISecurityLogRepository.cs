using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace SHJ.ABP.Commerce.AggregateRoots.Identity.IdentitySecurityLogs;

public interface ISecurityLogRepository : IRepository<IdentitySecurityLog>
{

}
