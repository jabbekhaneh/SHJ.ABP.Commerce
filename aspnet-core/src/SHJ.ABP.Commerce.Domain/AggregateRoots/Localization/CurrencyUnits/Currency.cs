using SHJ.ABP.Commerce.Localization.CurrencyUnits;
using Volo.Abp.Domain.Entities.Auditing;

namespace SHJ.ABP.Commerce.AggregateRoots.Localization.CurrencyUnits;

/// <summary>
/// Represents a currency
/// </summary>
public class Currency : FullAuditedAggregateRoot<int>
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the currency code
    /// </summary>
    public string CurrencyCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rate
    /// </summary>
    public decimal Rate { get; set; } = 0;

    /// <summary>
    /// Gets or sets the display locale
    /// </summary>
    public string DisplayLocale { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the custom formatting
    /// </summary>
    public string CustomFormatting { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; } = 0;

    /// <summary>
    /// Gets or sets the rounding type identifier
    /// </summary>
    public int RoundingTypeId { get; set; } = 0;

    /// <summary>
    /// Gets or sets the rounding type
    /// </summary>
    public RoundingType RoundingType
    {
        get => (RoundingType)RoundingTypeId;
        set => RoundingTypeId = (int)value;
    }
}
