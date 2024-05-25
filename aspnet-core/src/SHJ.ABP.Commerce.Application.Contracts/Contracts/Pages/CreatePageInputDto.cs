using JetBrains.Annotations;
using SHJ.ABP.Commerce.Shared.Pages;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;


namespace SHJ.ABP.Commerce.Contracts.Pages;

[Serializable]
public class CreatePageInputDto : ExtensibleObject
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
