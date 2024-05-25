using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SHJ.ABP.Commerce.Contracts.Identity.AuditLogs;

public interface IAuditLoggingAdminAppService : IApplicationService
{
    Task<PagedResultDto<AuditLogDto>> GetListAsync(PagedAndSortedAuditLogDtoResultRequestDto input);
    Task<AuditLogDto> GetAsync(Guid id);

}
