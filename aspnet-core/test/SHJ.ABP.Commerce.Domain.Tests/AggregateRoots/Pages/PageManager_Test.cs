using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Xunit;

namespace SHJ.ABP.Commerce.AggregateRoots.Pages;

public class PageManager_Test : CommerceDomainTestBase
{
    private readonly PageManager _sut;
    private readonly CommerceTestData _testData;
    private readonly IPageRepository _pageRepository;
    public PageManager_Test()
    {
        _sut = GetRequiredService<PageManager>();
        _testData = GetRequiredService<CommerceTestData>();
        _pageRepository = GetRequiredService<IPageRepository>();
    }

    [Fact]
    public async Task CreateAsync_ShouldWorkProperly_WithNonExistingTitle()
    {
        //arrange
        var title = "My awesome page".ToLower();
        var content = "<h1>My Awesome Page</h1><p>This is my awesome page content!</p>";

        //act
        var page = await _sut.NewAsync(title, content);

        //assert
        page.ShouldNotBeNull();
        page?.Title.ShouldBe(title);
        page?.Content.ShouldBe(content);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowException_WithExistingTitle()
    {
        //arrange
        var title = _testData.Page_1_Title;
        var content = _testData.Page_1_Content;

        //act
        var exception = await Should.ThrowAsync<BusinessException>(async () =>
                            await _sut.NewAsync(title, content));
        //assert
        exception.ShouldNotBeNull();
        exception.Code.ShouldBe(CommerceDomainErrorCodes.Pages.DublicateTitle);
    }

    [Fact]
    public async Task SetHomePageAsync_ShouldWorkProperly_IfExistHomePage()
    {
        //arrange
        var setHomePage = await CreatePageWith(false, "DummyHomePage");
        setHomePage.IsHomePage.ShouldBeFalse();

        //act
        var actual = await _sut.SetHomePageAsync(setHomePage);

        //assert
        actual.IsHomePage.ShouldBeTrue();
    }

    [Fact]
    public async Task SetHomePageAsync_ShouldThrowException_WhenMultipleHomePageExist()
    {
        //arrange
        await CreatePageWith(true);
        await CreatePageWith(true, "index2");
        var pages = await _pageRepository.GetListAsync();
        var setHomePage = pages.First(_ => _.Title == _testData.Page_1_Title);

        //act
        var exception = await Should.ThrowAsync<BusinessException>(async () =>
                    await _sut.SetHomePageAsync(setHomePage));
        //assert

        exception.ShouldNotBeNull();
        exception.Code.ShouldBe(CommerceDomainErrorCodes.Pages.CanBeOnlyHomePage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPage_WhenGetPage()
    {

        //arrange
        string title = "Dummt-HOME-PAGE".ToLower();
        var page = await CreatePageWith(false, title);
        //act

        var actual = await _sut.GetByIdAsync(page.Id);

        //assert


        actual.Title.ShouldBe(title);

    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowExceptione_WhenNotFoundPage()
    {

        //arrange
         Guid idFake = Guid.NewGuid();


        //act
        var exception = await Should.ThrowAsync<BusinessException>(async () =>
                       await _sut.GetByIdAsync(idFake));


        //assert

        exception.ShouldNotBeNull();
        exception.Code.ShouldBe(CommerceDomainErrorCodes.Pages.PageNotFound);

    }








    #region ExteraMethod
    private async Task<Page> CreatePageWith(bool isHomePage = false, string? title = "index")
    {
        var content = "<h1>My Awesome Page</h1><p>This is my awesome page content!</p>";
        var page = await _sut.NewAsync(title.ToLower(), content);
        page.SetIsHomePage(isHomePage);
        await _pageRepository.InsertAsync(page);
        return page;
    }
    #endregion
}
