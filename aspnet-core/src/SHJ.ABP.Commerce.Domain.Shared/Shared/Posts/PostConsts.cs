namespace SHJ.ABP.Commerce.Shared.Posts;


public static class PostConsts
{
    public static int MaxTitleLength { get; set; } = 256;
    public static int MaxDescriptionLength { get; set; } = int.MaxValue;
    public static int MaxLinkLength { get; set; } = 1000;
    public static int MaxMetaDescriptionLength { get; set; } = 300;
    public static int MaxMetaTagsLength { get; set; } = 300;
    public static int MaxTitleSeoLength { get; set; } = 300;
    public static int MaxCanonicalTagLength { get; set; } = 1000;
    public static int MaxAltImageLength { get; set; } = 300;

}
