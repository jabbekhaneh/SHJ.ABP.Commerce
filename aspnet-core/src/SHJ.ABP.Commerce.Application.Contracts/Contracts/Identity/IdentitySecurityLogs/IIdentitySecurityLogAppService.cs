using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SHJ.ABP.Commerce.Contracts.Identity.IdentitySecurityLogs;

public interface IIdentitySecurityLogAppService : IApplicationService
{
    Task<IdentitySecurityLogDto> Get(Guid id);
    Task<PagedResultDto<IdentitySecurityLogDto>> Get(PagedAndSortedIdentitySecurityLogResultRequestDto? input);
}
