namespace SHJ.ABP.Commerce;

public static class CommerceDomainErrorCodes
{
    public static class CommerceGlobal
    {
        public const string Name = "SHJ.Commerce";
        public const string Page = ".Page";
    }
   

    public static class Pages
    {
        public const string MultipleHomePage = $"{CommerceGlobal.Name}{CommerceGlobal.Page}:0001";
        public const string DublicateTitle = $"{CommerceGlobal.Name}{CommerceGlobal.Page}:0002";
        public const string PageNotFound = $"{CommerceGlobal.Name}{CommerceGlobal.Page}:0003";
        //There can be only one home page.
        public const string CanBeOnlyHomePage = $"{CommerceGlobal.Name}{CommerceGlobal.Page}:0004";
        
    }
}
