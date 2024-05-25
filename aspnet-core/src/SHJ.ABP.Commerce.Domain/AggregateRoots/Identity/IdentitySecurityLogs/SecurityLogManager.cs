using JetBrains.Annotations;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace SHJ.ABP.Commerce.AggregateRoots.Identity.IdentitySecurityLogs;

public class SecurityLogManager : DomainService
{
    private readonly ISecurityLogRepository _repository;
    public SecurityLogManager(ISecurityLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<IdentitySecurityLog> GetAsync([NotNull] Guid id)
    {
        var query = await _repository.GetQueryableAsync();
        return query.SingleOrDefault(_ => _.Id == id);
    }

    public async Task<IQueryable<IdentitySecurityLog>> GetQueryableAsync([CanBeNull] string search)
    {
        var query = await _repository.GetQueryableAsync();
        if (!string.IsNullOrEmpty(search))
            query = query.Where(_ => _.Identity.Contains(search) ||
                                 _.ApplicationName.Contains(search) ||
                                 _.Action.Contains(search) ||
                                 _.BrowserInfo.Contains(search) ||
                                 _.ClientIpAddress.Contains(search) ||
                                 _.ConcurrencyStamp.Contains(search) ||
                                 _.TenantName.Contains(search) ||
                                 _.UserName.Contains(search));

        return query.OrderByDescending(_ => _.CreationTime);
    }

    public async Task<int> CountAsync()
    {
        return await _repository.CountAsync();
    }
}
