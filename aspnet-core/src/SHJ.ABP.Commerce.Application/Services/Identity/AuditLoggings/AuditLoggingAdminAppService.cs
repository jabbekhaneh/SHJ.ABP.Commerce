using SHJ.ABP.Commerce.AggregateRoots.Identity.AuditLoggings;
using SHJ.ABP.Commerce.Contracts.Identity.AuditLogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;


namespace SHJ.ABP.Commerce.Services.Identity.AuditLoggings;


public class AuditLoggingAdminAppService : ApplicationService, IAuditLoggingAdminAppService
{

    private readonly AuditLogManger _AuditLogManger;
    public AuditLoggingAdminAppService(AuditLogManger auditLogManger)
    {
        _AuditLogManger = auditLogManger;
    }

    public async Task<AuditLogDto> GetAsync(Guid id)
    {
        var auditLog = await _AuditLogManger.GetAsync(id);
        return ObjectMapper.Map<AuditLog, AuditLogDto>(auditLog);

    }

    public async Task<PagedResultDto<AuditLogDto>> GetListAsync(PagedAndSortedAuditLogDtoResultRequestDto input)
    {
        var skipCount = input.SkipCount * input.MaxResultCount;

        var result = await _AuditLogManger
                           .GetListAsync(input.Sorting, input.MaxResultCount,
                                         skipCount, input.StartDate, input.EndDate,
                                         input.HttpMethod, input.Url, input.UserId,
                                         input.UserName, input.ApplicationName, input.ClientIpAddress,
                                         input.CorrelationId, input.MaxExecutionDuration,
                                         input.MinExecutionDuration, input.HasException,
                                         input.HttpStatusCode, input.IncludeDetails);
        

        return new PagedResultDto<AuditLogDto>(await _AuditLogManger.CountAsync(),
                                               ObjectMapper.Map<List<AuditLog>, 
                                               List<AuditLogDto>>(result));
    }
}
