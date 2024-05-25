using SHJ.ABP.Commerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SHJ.ABP.Commerce;

[DependsOn(
    typeof(CommerceEntityFrameworkCoreTestModule)
    )]
public class CommerceDomainTestModule : AbpModule
{

}
