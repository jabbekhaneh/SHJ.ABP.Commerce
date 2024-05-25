using Microsoft.AspNetCore.Authorization;
using SHJ.ABP.Commerce.AggregateRoots.Identity.IdentitySecurityLogs;
using SHJ.ABP.Commerce.Contracts.Identity.IdentitySecurityLogs;
using SHJ.ABP.Commerce.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SHJ.ABP.Commerce.Services.Identity.IdentitySecurityLogs;



public class IdentitySecurityLogAdminAppService : ApplicationService, IIdentitySecurityLogAppService
{
    private readonly SecurityLogManager _Manager;

    public IdentitySecurityLogAdminAppService(SecurityLogManager manager)
    {
        _Manager = manager;
    }

    
    public async Task<PagedResultDto<IdentitySecurityLogDto>> Get(PagedAndSortedIdentitySecurityLogResultRequestDto? input)
    {
        var query = await _Manager.GetQueryableAsync(input.Search);

        var skipCount = input.SkipCount * input.MaxResultCount;
        var securityLogs = query.PageBy(skipCount, input.MaxResultCount).ToList();

        var count = await _Manager.CountAsync();

        return new PagedResultDto<IdentitySecurityLogDto>(count,
            ObjectMapper.Map<List<IdentitySecurityLog>, List<IdentitySecurityLogDto>>(securityLogs));
    }

    [Authorize(CommercePermissions.Support.SecurityLogs)]
    public async Task<IdentitySecurityLogDto> Get(Guid id)
    {
        var query = await _Manager.GetAsync(id);
        return ObjectMapper.Map<IdentitySecurityLog, IdentitySecurityLogDto>(query);
    }
}
