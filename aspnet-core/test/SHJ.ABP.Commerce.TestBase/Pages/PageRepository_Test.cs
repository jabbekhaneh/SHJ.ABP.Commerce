using Microsoft.VisualBasic;
using SHJ.ABP.Commerce.AggregateRoots.Pages;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace SHJ.ABP.Commerce.Pages;

public class PageRepository_Test<TStartupModule> : CommerceTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly CommerceTestData _testData;
    private readonly IPageRepository _pageRepository;

    protected PageRepository_Test()
    {
        _testData = GetRequiredService<CommerceTestData>();
        _pageRepository = GetRequiredService<IPageRepository>();
    }

   
}
