using SHJ.ABP.Commerce.AggregateRoots.Identity.IdentitySecurityLogs;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace SHJ.ABP.Commerce.EntityFrameworkCore.Identity;

public class EfCoreSecurityLogRepository : EfCoreRepository<CommerceDbContext, IdentitySecurityLog, Guid>, ISecurityLogRepository
{
    public EfCoreSecurityLogRepository(IDbContextProvider<CommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }
}
