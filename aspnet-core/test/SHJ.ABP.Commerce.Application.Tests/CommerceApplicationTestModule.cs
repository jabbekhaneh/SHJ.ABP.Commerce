using Volo.Abp.Modularity;

namespace SHJ.ABP.Commerce;

[DependsOn(
    typeof(CommerceApplicationModule),
    typeof(CommerceDomainTestModule)
    )]
public class CommerceApplicationTestModule : AbpModule
{

}
