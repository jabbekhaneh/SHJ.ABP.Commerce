using System;
using Volo.Abp.Application.Dtos;

namespace SHJ.ABP.Commerce.Contracts.Identity.IdentitySecurityLogs;

public class PagedAndSortedIdentitySecurityLogResultRequestDto : PagedAndSortedResultRequestDto
{
    public string? Search { get; set; }
    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public string? ApplicationName { get; set; }
    public string? Identity { get; set; }
    public string? Action { get; set; } = null;
    public string? CorrelationId { get; set; }
    public string? ClientId { get; set; }
}