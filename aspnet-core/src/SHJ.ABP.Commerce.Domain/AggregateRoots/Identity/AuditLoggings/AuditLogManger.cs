using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SHJ.ABP.Commerce.AggregateRoots.Identity.AuditLoggings;

public class AuditLogManger : DomainService
{

    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogManger(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }


    public async Task<AuditLog> GetAsync(Guid id)
    {
        return await _auditLogRepository.GetAsync(id);
    }

    public async Task<List<AuditLog>> GetListAsync(string? sorting = null, int maxResultCount = 50,
                                                   int skipCount = 0, DateTime? startTime = null,
                                                   DateTime? endTime = null, string? httpMethod = null,
                                                   string? url = null, Guid? userId = null,
                                                   string? userName = null, string? applicationName = null,
                                                   string? clientIpAddress = null, string? correlationId = null,
                                                   int? maxExecutionDuration = null,
                                                   int? minExecutionDuration = null, bool? hasException = null,
                                                   HttpStatusCode? httpStatusCode = null, bool includeDetails = false)
    {
        return await _auditLogRepository.GetListAsync(sorting, maxResultCount,
                                          skipCount, startTime, endTime,
                                          httpMethod, url, userId,
                                          userName, applicationName, clientIpAddress,
                                          correlationId, maxExecutionDuration,
                                          minExecutionDuration, hasException,
                                          httpStatusCode, includeDetails);
    }
    public async Task<int> CountAsync()
    {
        return await _auditLogRepository.CountAsync();
    }

}
