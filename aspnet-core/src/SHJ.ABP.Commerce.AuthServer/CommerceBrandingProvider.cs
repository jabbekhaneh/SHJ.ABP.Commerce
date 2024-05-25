using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SHJ.ABP.Commerce;

[Dependency(ReplaceServices = true)]
public class CommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Account";
}
