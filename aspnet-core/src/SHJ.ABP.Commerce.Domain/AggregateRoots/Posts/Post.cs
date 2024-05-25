using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using SHJ.ABP.Commerce.Shared.Posts;

namespace SHJ.ABP.Commerce.AggregateRoots.Posts;

public class Post : FullAuditedAggregateRoot<Guid>
{
    protected Post()
    {

    }
    internal Post(string title, string code, string description, string? link, string? metaDescription, string? metaTags, string? titleSeo, string? canonicalTag, string? altImage, Guid? documentId)
    {
        SetTitle(title);
        Description = description;
        Link = link;
        MetaDescription = metaDescription;
        MetaTags = metaTags;
        TitleSeo = titleSeo;
        CanonicalTag = canonicalTag;
        AltImage = altImage;
        DocumentId = documentId;
    }
    public virtual string Title { get; set; } = string.Empty;
    public virtual string Code { get; set; } = string.Empty;
    public virtual string Description { get; set; } = string.Empty;
    public virtual string? Link { get; set; } = string.Empty;
    public virtual string? MetaDescription { get; set; } = string.Empty;
    public virtual string? MetaTags { get; set; } = string.Empty;
    public virtual string? TitleSeo { get; set; } = string.Empty;
    public virtual string? CanonicalTag { get; set; } = string.Empty;
    public virtual string? AltImage { get; set; } = string.Empty;
    public virtual Guid? DocumentId { get; set; }
    public virtual void SetTitle(string title)
    {
        Title = Check.NotNullOrEmpty(title, nameof(title), PostConsts.MaxTitleLength);
    }
}
