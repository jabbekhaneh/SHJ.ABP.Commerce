using System;
using System.Net;
using Volo.Abp.Application.Dtos;

namespace SHJ.ABP.Commerce.Contracts.Identity.AuditLogs;

public class PagedAndSortedAuditLogDtoResultRequestDto : PagedAndSortedResultRequestDto
{
    public string? Search { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? HttpMethod { get; set; }
    public string? Url { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public string? ApplicationName { get; set; }
    public string? ClientIpAddress { get; set; }
    public string? CorrelationId { get; set; }
    public int? MaxExecutionDuration { get; set; }
    public int? MinExecutionDuration { get; set; }
    public bool? HasException { get; set; }
    public HttpStatusCode? HttpStatusCode { get; set; }
    public bool IncludeDetails { get; set; } = false;


}
