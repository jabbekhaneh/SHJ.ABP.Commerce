using JetBrains.Annotations;
using SHJ.ABP.Commerce.Shared.Pages;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SHJ.ABP.Commerce.AggregateRoots.Pages;

public class Page : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    protected Page()
    {

    }
    public virtual Guid? TenantId { get; internal set; }
    public virtual string Title { get; internal set; } = string.Empty;
    public virtual string Content { get; internal set; } = string.Empty;
    public virtual string? Script { get; internal set; } = string.Empty;
    public virtual string? Style { get; internal set; } = string.Empty;
    public virtual bool IsHomePage { get; internal set; }
    internal Page(Guid id,
                 [NotNull] string title,
                 string content = "",
                 string script = "",
                 string style = "",
                 Guid? tenantId = default) : base(id)
    {
        TenantId = tenantId;
        SetTitle(title);
        SetContent(content);
        SetScript(script);
        SetStyle(style);
    }

    public virtual void SetTitle(string title)
    {
        Title = Check.NotNullOrEmpty(title, nameof(title), PageConsts.MaxTitleLength).ToLower();
    }

    public virtual void SetContent(string? content)
    {
        Content = Check.Length(content, nameof(content), PageConsts.MaxContentLength) ?? "";
    }

    public virtual void SetScript(string? script)
    {
        Script = Check.Length(script, nameof(script), PageConsts.MaxScriptLength);
    }

    public virtual void SetStyle(string? style)
    {
        Style = Check.Length(style, nameof(style), PageConsts.MaxStyleLength);
    }

    internal void SetIsHomePage(bool isHomePage)
    {
        IsHomePage = isHomePage;
    }
}