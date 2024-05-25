using SHJ.ABP.Commerce.Shared.Pages;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace SHJ.ABP.Commerce.Contracts.Pages;


public class UpdatePageInputDto : EntityDto
{
    [Required]
    [DynamicMaxLength(typeof(PageConsts), nameof(PageConsts.MaxTitleLength))]
    public string Title { get; set; } = string.Empty;

    [DynamicMaxLength(typeof(PageConsts), nameof(PageConsts.MaxContentLength))]
    public string? Content { get; set; }

    [DynamicMaxLength(typeof(PageConsts), nameof(PageConsts.MaxScriptLength))]
    public string? Script { get; set; }

    [DynamicMaxLength(typeof(PageConsts), nameof(PageConsts.MaxStyleLength))]
    public string? Style { get; set; }

}