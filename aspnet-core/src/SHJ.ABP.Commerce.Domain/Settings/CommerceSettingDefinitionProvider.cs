using Volo.Abp.Settings;

namespace SHJ.ABP.Commerce.Settings;

public class CommerceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CommerceSettings.MySetting1));
    }
}
