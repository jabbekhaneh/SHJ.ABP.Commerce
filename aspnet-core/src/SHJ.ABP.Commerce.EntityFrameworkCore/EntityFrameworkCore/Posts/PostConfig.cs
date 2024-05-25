using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SHJ.ABP.Commerce.AggregateRoots.Posts;
using SHJ.ABP.Commerce.Shared.Posts;

namespace SHJ.ABP.Commerce.EntityFrameworkCore.Blogs;

internal class PostConfig : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(_ => _.Title)
               .IsRequired()
               .HasMaxLength(PostConsts.MaxTitleLength);

        builder.Property(_ => _.Description)
               .IsRequired()
               .HasMaxLength(PostConsts.MaxDescriptionLength);

        builder.Property(_ => _.Code)
               .IsRequired();

        builder.Property(_ => _.AltImage)
               .HasMaxLength(PostConsts.MaxAltImageLength);

        builder.Property(_ => _.CanonicalTag)
               .HasMaxLength(PostConsts.MaxCanonicalTagLength);

        builder.Property(_ => _.Link)
               .HasMaxLength(PostConsts.MaxLinkLength);

        builder.Property(_ => _.MetaTags)
               .HasMaxLength(PostConsts.MaxMetaTagsLength);

        builder.Property(_ => _.TitleSeo)
               .HasMaxLength(PostConsts.MaxTitleSeoLength);

    }
}