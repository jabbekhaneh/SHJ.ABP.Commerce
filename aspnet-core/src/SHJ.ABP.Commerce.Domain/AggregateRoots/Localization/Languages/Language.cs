using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SHJ.ABP.Commerce.AggregateRoots.Localization.Languages;

public class Language : FullAuditedAggregateRoot<Guid>
{
    public Language()
    {
        
    }
    public string Culture { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
