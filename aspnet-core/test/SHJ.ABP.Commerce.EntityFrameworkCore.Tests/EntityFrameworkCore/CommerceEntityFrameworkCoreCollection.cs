using Xunit;

namespace SHJ.ABP.Commerce.EntityFrameworkCore;

[CollectionDefinition(CommerceTestConsts.CollectionDefinitionName)]
public class CommerceEntityFrameworkCoreCollection : ICollectionFixture<CommerceEntityFrameworkCoreFixture>
{

}
