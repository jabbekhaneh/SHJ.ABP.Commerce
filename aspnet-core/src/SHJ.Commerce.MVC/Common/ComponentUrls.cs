namespace SHJ.Commerce.MVC.Common;

public static class ComponentUrls
{
    private const string BaseComponent = "~/Components/";
    public static class Shared
    {
        private const string MetaTags = BaseComponent + "Shared/MetaTags/";
        public const string MetaTagsDefault = MetaTags + "Default.cshtml";
    }
}
