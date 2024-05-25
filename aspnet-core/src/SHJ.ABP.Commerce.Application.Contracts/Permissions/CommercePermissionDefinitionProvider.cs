using SHJ.ABP.Commerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SHJ.ABP.Commerce.Permissions;

public class CommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var rootGroup = context.AddGroup(CommercePermissions.GroupName, L($"Permissions:{CommercePermissions.GroupName}"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CommercePermissions.MyPermission1, L("Permission:MyPermission1"));

        AddPageManagementPermission(rootGroup);
        IdentityManagementPermission(rootGroup);
    }

    private static void AddPageManagementPermission(PermissionGroupDefinition rootGroup)
    {
        var pageManagement = rootGroup.AddPermission(CommercePermissions.Pages.Default, L("Permission:PageManagement"));
        pageManagement.AddChild(CommercePermissions.Pages.Create, L("Permission:PageManagement:Create"));
        pageManagement.AddChild(CommercePermissions.Pages.Update, L("Permission:PageManagement:Update"));
        pageManagement.AddChild(CommercePermissions.Pages.Delete, L("Permission:PageManagement:Delete"));
        pageManagement.AddChild(CommercePermissions.Pages.SetAsHomePage, L("Permission:PageManagement:SetAsHomePage"));
    }
    private static void IdentityManagementPermission(PermissionGroupDefinition rootGroup)
    {
        var identityManagement = rootGroup.AddPermission(CommercePermissions.Support.Default, L("Permission:IdentityManagement"));
        identityManagement.AddChild(CommercePermissions.Support.SecurityLogs, L("Permission:IdentityManagement:SecurityLogs"));
        identityManagement.AddChild(CommercePermissions.Support.AuditLoggings, L("Permission:IdentityManagement:AuditLoggings"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CommerceResource>(name);
    }
}
