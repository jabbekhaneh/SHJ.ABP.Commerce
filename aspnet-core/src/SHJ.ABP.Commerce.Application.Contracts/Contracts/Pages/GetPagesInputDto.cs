using System;
using Volo.Abp.Application.Dtos;

namespace SHJ.ABP.Commerce.Contracts.Pages;

[Serializable]
public class GetPagesInputDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; } = string.Empty;
    public string? CreatorUsername { get; set; } = string.Empty;
    public string? LastModifierUsername { get; set; } = string.Empty;
    public DateTime? CreationStartDate { get; set; } 
    public DateTime? CreationEndDate { get; set; } 


    
}