using Volo.Abp.Reflection;

namespace SHJ.ABP.Commerce.Permissions;

public static class CommercePermissions
{
    public const string GroupName = "Commerce";
   
    //------------------------------------------------
    public static class UserManagment
    {
        public const string Default = GroupName + ".UserManagment";
    }
    //------------------------------------------------
    public static class Support
    {
        public const string Default = GroupName + ".Support";
        public const string SecurityLogs = GroupName + ".IdentitySecurityLogs";
        public const string AuditLoggings = GroupName + ".AuditLoggings";
    }
    //------------------------------------------------
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CommercePermissions));
    }
    //------------------------------------------------
    public static class Pages
    {
        public const string Default = GroupName + ".Pages";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string SetAsHomePage = Default + ".SetAsHomePage";
    }
    //------------------------------------------------
    public static class Posts
    {
        public const string Default = GroupName + ".Posts";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        
    }
    //------------------------------------------------
    
}
